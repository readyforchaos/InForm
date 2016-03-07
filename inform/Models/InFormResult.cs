using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace inform.Models
{
    public class InFormResult
    {
        public Results Results { get; set; }
    }

    public class Results
    {
        public InFormOutput InFormOutput { get; set; }
    }

    public class Value
    {
        public List<string> ColumnNames { get; set; }
        public List<string> ColumnTypes { get; set; }
        public List<List<string>> Values { get; set; }
    }

    public class InFormOutput
    {
        public string Type { get; set; }
        public Value Value { get; set; }
    }
}