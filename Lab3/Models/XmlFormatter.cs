using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab3.Models
{
    using System.Net.Http.Formatting;
    using System.Net.Http.Headers;
    using System.IO;
    using System.Threading.Tasks;
    using System.Xml.Serialization;
    using System.Net.Http;
    using System.Net;

    public class XmlFormatter : MediaTypeFormatter
    {
        public XmlFormatter()
        {
            SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/xml"));
        }

        public override bool CanReadType(Type type)
        {
            // Указываем, что форматтер может читать указанный тип
            return true;
        }

        public override bool CanWriteType(Type type)
        {
            // Указываем, что форматтер может записать указанный тип
            return true;
        }

        public override async Task WriteToStreamAsync(Type type, object value, Stream writeStream, HttpContent content, TransportContext transportContext)
        {
            // Используем XmlSerializer для сериализации объекта в XML и записи его в выходной поток
            var serializer = new XmlSerializer(type);
            serializer.Serialize(writeStream, value);
            await Task.FromResult(writeStream);
        }
    }

}