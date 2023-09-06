using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab1
{
    public class DataRes
    {
        public int Result;
        [JsonProperty(Order = 1)]
        public Stack<int> Stack;

        public DataRes()
        {
            Result = 0;
            Stack = new Stack<int>();
        }
    }
}