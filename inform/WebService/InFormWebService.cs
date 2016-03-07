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
        private string apiKey = WebConfigurationManager.AppSettings["7vUYNtX0bTtsrL8+bMqbJ9W0wGXGxfolBWidCR4LHDJQNdDKkzGHWaI+8iCT3h9cft9KBQPAbEm5cP91edlLbg=="];


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
                    convertValues[i, 0] = personValues[i].Date.Value.ToString("dd.MM.yyyy");
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
                            "input1",
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
                    }
                };
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);

                client.BaseAddress = new Uri("https://ussouthcentral.services.azureml.net/workspaces/033d6f8d8b064d6ea124312bd0177ae2/services/5730cfea87244590bb746f0bfbf3b3f1/execute?api-version=2.0&details=true");


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