using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Configuration;
using inform.Models;
using Newtonsoft.Json;

namespace inform.WebService
{
    public class InFormWebService
    {
        private string apiKey = WebConfigurationManager.AppSettings["InFormWebServiceApiKey"];


        public async Task<T> InvokeRequestResponseService<T>(string passAccuracy, string avgBpm, string numOfSprints, 
            string topSpeed, string numBallTouches) where T : class
        {
            using (var client = new HttpClient())
            {
                var personValues = new[]
                    {
                        new InFormData
                        {
                            Date = DateTime.Now,
                            PassAccuracyInPercentage = Int32.Parse(passAccuracy),
                            AvgBPM = Int32.Parse(avgBpm),
                            NumberOfSprints = Int32.Parse(numOfSprints),
                            TopSpeed = Int32.Parse(topSpeed),
                            BallTouches = Int32.Parse(numBallTouches),
                            InMatchKMRan = 0,
                            InMatchGoals = 0,
                            InMatchAssists = 0,
                            InMatchAvgBPM = 0,
                            InMatchSprints = 0,
                            InMatchTopSpeed = 0,
                            InMatchBallTouches = 0,
                            PerformancePercentage = 0

                        }
                };
                var propertyCount = typeof(InFormData).GetProperties().Count();
                var convertValues = new string[personValues.Count(), propertyCount];
                for (var i = 0; i < convertValues.GetLength(0); i++)
                {
                    convertValues[i, 0] = "value";
                    convertValues[i, 1] = personValues[i].PassAccuracyInPercentage.ToString();
                    convertValues[i, 2] = personValues[i].AvgBPM.ToString();
                    convertValues[i, 3] = personValues[i].NumberOfSprints.ToString();
                    convertValues[i, 4] = personValues[i].TopSpeed.ToString();
                    convertValues[i, 5] = personValues[i].BallTouches.ToString();
                    convertValues[i, 6] = personValues[i].InMatchKMRan.ToString();
                    convertValues[i, 7] = personValues[i].InMatchGoals.ToString();
                    convertValues[i, 8] = personValues[i].InMatchAssists.ToString();
                    convertValues[i, 9] = personValues[i].InMatchAvgBPM.ToString();
                    convertValues[i, 10] = personValues[i].InMatchSprints.ToString();
                    convertValues[i, 11] = personValues[i].InMatchTopSpeed.ToString();
                    convertValues[i, 12] = personValues[i].InMatchBallTouches.ToString();
                    convertValues[i, 13] = personValues[i].PerformancePercentage.ToString();
                }

                var scoreRequest = new
                {
                    Inputs = new Dictionary<string, InFormTable>() {
                        {
                            "InFormInput",
                            new InFormTable()
                            {
                                ColumnNames = new [] {
                                    "Date",
                                    "PassAccuracyInPercentage",
                                    "AvgBPM",
                                    "NumberOfSprints",
                                    "TopSpeed",
                                    "BallTouches",
                                    "InMatchKMRan",
                                    "InMatchGoals",
                                    "InMatchAssists",
                                    "InMatchAvgBPM",
                                    "InMatchSprints",
                                    "InMatchTopSpeed",
                                    "InMatchBallTouches",
                                    "PerformancePercentage" },
                                Values = convertValues
                            }
                        },
                    },
                    GlobalParameters = new Dictionary<string, string>()
                    {
                        { "Append score columns to output", "" }
                    }
                };
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);

                client.BaseAddress = new Uri("https://europewest.services.azureml.net/workspaces/e9cee52eb6544a33a7048158f08c74c1/services/5437961661814332bb2b534bef774a5f/execute?api-version=2.0&details=true");


                HttpResponseMessage response = await client.PostAsJsonAsync("", scoreRequest).ConfigureAwait(false);

                if (response.IsSuccessStatusCode)
                {
                    string result = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    var resultOutcome = JsonConvert.DeserializeObject<T>(result);
                    Debug.WriteLine("Result: {0}", result);
                    return resultOutcome;
                }
                else
                {
                    Debug.WriteLine(string.Format("The request failed with status code: {0}", response.StatusCode));

                    // Print the headers - they include the requert ID and the timestamp, which are useful for debugging the failure
                    Debug.WriteLine(response.Headers.ToString());

                    string responseContent = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    Debug.WriteLine(responseContent);
                    return null;
                }
            }
        }



    }
}