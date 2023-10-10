using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab3.Models
{
    public class ErrorDetails
    {
        public int code;
        public string message;

        public ErrorDetails(int code, string message)
        {
            this.code = code;
            this.message = message;
        }
    }
}