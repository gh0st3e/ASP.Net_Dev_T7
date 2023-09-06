using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab1
{
    public class ErrorRes
    {
        public string ErrorMsg;
        public int Code;
        
        public ErrorRes(string errorMsg, int code)
        {
            ErrorMsg = errorMsg;
            Code = code;
        }
    }
}