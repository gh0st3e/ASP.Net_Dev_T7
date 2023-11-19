using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;

namespace Lab4
{
    [ScriptService] // Веб служба может быть вызвана из скрипта
    [WebService(Namespace = "http://LDI/", Description = "WebService")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Чтобы разрешить вызывать веб-службу из скрипта с помощью ASP.NET AJAX, раскомментируйте следующую строку. 
    // [System.Web.Script.Services.ScriptService]
    public class Simplex : System.Web.Services.WebService
    {
        [WebMethod(Description = "Returns sum of two integers", MessageName = "Add")]
        public int Add(int x, int y)
        {
            return x + y;
        }


        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        [WebMethod(Description = "Returns sum of two integers (JSON)", MessageName = "AddS")]
        public string AddS(InputData data)
        {
            int x = data.x;
            int y = data.y;
            int result = x + y;

            return JsonConvert.SerializeObject(result);
        }

        [WebMethod(Description = "Returns concat of string and double", MessageName = "Concat")]

        public string Concat(string s, double d)
        {
            return string.Concat(s, d);
        }

        [WebMethod(Description = "Returns object A", MessageName = "Sum")]
        public A Sum(A a1, A a2)
        {
            string notification = "";
            using (var stream = new MemoryStream())
            using (var textWriter = new StreamWriter("D:\\Study\\PIS\\Lab4\\bodylog.xml"))
            {
                var request = HttpContext.Current.Request;
                request.InputStream.Seek(0, SeekOrigin.Begin);
                request.InputStream.CopyTo(stream);
                notification = Encoding.UTF8.GetString(stream.ToArray());
                textWriter.Write(notification);
            }
            A model = new A();
            model.s = string.Concat(a1.s, a2.s);
            model.k = a1.k + a2.k;
            model.f = a1.f + a2.f;
            return model;
        }

        [WebMethod]
        public string HelloWorld()
        {
            return "Привет всем!";
        }

        [WebMethod(Description = "Returns the HTML content of Query.html", MessageName = "GetQueryPage")]
        public string GetQueryPage()
        {
            string filePath = Server.MapPath("~/Query.html"); // Укажите путь к вашему файлу HTML
            string htmlContent = File.ReadAllText(filePath);
            return htmlContent;
        }

    }
}
