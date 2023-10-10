using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Lab3.Models
{
    [DataContract]
    public class Hateoas
    {
        [DataMember]
        public string allStudents;
        [DataMember]
        public string allXMLStudents;
        [DataMember]
        public string selfStudent;
        [DataMember]
        public string selfXMLStudent;

        public Hateoas(string allStudents, string allXMLStudents, string selfStudent, string selfXMLStudent)
        {
            this.allStudents = allStudents;
            this.allXMLStudents = allXMLStudents;
            this.selfStudent = selfStudent;
            this.selfXMLStudent = selfXMLStudent;
        }

        public Hateoas()
        {
        }
    }
}