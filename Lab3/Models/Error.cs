using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab3.Models
{
    public class Error
    {
        public int code;
        public Link _links;

        public Error(int code, string link)
        {
            this.code = code;
            this._links = new Link(link + "/api/error/" + code);
        }

        public class Link
        {
            public string details;

            public Link(string details)
            {
                this.details = details;
            }
        }
    }
}