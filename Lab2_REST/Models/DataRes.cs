using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab2_REST.Models
{
    public static class DataRes
    {
        public static int Result;
        public static Stack<int> Stack;

        static DataRes()
        {
            Result = 0;
            Stack = new Stack<int>();
        }
    }
}