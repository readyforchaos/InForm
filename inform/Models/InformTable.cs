using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace inform.Models
{
    public class InFormTable
    {
        public string[] ColumnNames { get; set; }
        public string[,] Values { get; set; }
    }
}