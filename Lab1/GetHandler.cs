using Newtonsoft.Json;
using System;
using System.Web;
using System.Web.SessionState;

namespace Lab1
{
    public class GetHandler : IHttpHandler, IRequiresSessionState
    {
        /// <summary>
        /// Вам потребуется настроить этот обработчик в файле Web.config вашего 
        /// веб-сайта и зарегистрировать его с помощью IIS, чтобы затем воспользоваться им.
        /// см. на этой странице: https://go.microsoft.com/?linkid=8101007
        /// </summary>
        #region Члены IHttpHandler

        public bool IsReusable
        {
            // Верните значение false в том случае, если ваш управляемый обработчик не может быть повторно использован для другого запроса.
            // Обычно значение false соответствует случаю, когда некоторые данные о состоянии сохранены по запросу.
            get { return true; }
        }

        public void ProcessRequest(HttpContext context)
        {
            HttpRequest request = context.Request;
            HttpResponse response = context.Response;

            response.AddHeader("Content-Type", "application/json");

            try
            {
                if (context.Session["SessionData"] == null)
                {
                    DataRes initDataRes = new DataRes();
                    context.Session["SessionData"] = initDataRes;
                }

                var SessionData = context.Session["SessionData"];
                DataRes dataRes = (DataRes)SessionData;
                //DataRes dataRes = JsonConvert.DeserializeObject<DataRes>(sessionData);

                DataRes responseDataRes = new DataRes();
                responseDataRes.Stack = dataRes.Stack;
                responseDataRes.Result = dataRes.Result;

                int lastStackItem = 0;

                if (dataRes.Stack.Count > 0)
                {
                    lastStackItem = dataRes.Stack.Peek();
                }

                responseDataRes.Result = GlobalResult.Result + lastStackItem;

                response.StatusCode = 200;
                response.Write(JsonConvert.SerializeObject(responseDataRes, Formatting.Indented));
            }
            catch (Exception ex)
            {
                response.StatusCode = 500;
                ErrorRes errorRes = new ErrorRes(ex.Message, 500);
                response.Write(JsonConvert.SerializeObject(errorRes));
            }
            
        }

        #endregion
    }
}
