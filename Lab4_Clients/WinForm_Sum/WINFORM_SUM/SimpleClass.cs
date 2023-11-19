using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WINFORM_SUM
{
    public class SimpleClass
    {
        public string str { get; set; }
        public int numberInt { get; set; }
        public float numberFloat { get; set; }

        public string formSOAP(SimpleClass otherObject)
        {
            string SOAP = "<?xml version=\"1.0\" encoding=\"utf-8\"?>\n" +
"<soap:Envelope xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\">\n" +
"  <soap:Body>\n" +
"    <Sum xmlns='http://LDI/'>\n" +
"      <a1>\n" +
"        <s>" + this.str +"</s>\n" +
"        <k>" + this.numberInt + "</k>\n" +
"        <f>" + this.numberFloat.ToString().Replace(",", ".") + "</f>\n" +
"      </a1>\n" +
"      <a2>\n" +
"        <s>" + otherObject.str + "</s>\n" +
"        <k>" + otherObject.numberInt + "</k>\n" +
"        <f>" + otherObject.numberFloat.ToString().Replace(",", ".") + "</f>\n" +
"      </a2>\n" +
"    </Sum>\n" +
"  </soap:Body>\n" +
"</soap:Envelope>";
            return SOAP;
        }
    }
}
