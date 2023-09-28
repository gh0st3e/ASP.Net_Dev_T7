using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.Results;
using Newtonsoft.Json;

namespace Lab2_REST.Controllers
{
    
    public class StackController : ApiController
    {
        [ResponseType(typeof(object))]
        [HttpGet]
        public IHttpActionResult GetResult()
        {
            try
            {
                int lastStackItem = 0;
                if (Models.DataRes.Stack.Count > 0)
                {
                    lastStackItem = Models.DataRes.Stack.Peek();
                }
                int res = Models.DataRes.Result + lastStackItem;
                var data = new { res, Models.DataRes.Stack };
                return Ok(data);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
           
        }

        [HttpPost]
        public IHttpActionResult PostResult(int result)
        {
            try
            {
                Models.DataRes.Result = result;
                int lastStackItem = 0;
                if (Models.DataRes.Stack.Count > 0)
                {
                    lastStackItem = Models.DataRes.Stack.Peek();
                }
                int res = Models.DataRes.Result + lastStackItem;
                var data = new { res, Models.DataRes.Stack };
                return Ok(data);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
            
        }

        [HttpPut]
        public IHttpActionResult PutStack(int add)
        {
            try
            {
                Models.DataRes.Stack.Push(add);
                int res = Models.DataRes.Result + Models.DataRes.Stack.Peek();
                var data = new { res, Models.DataRes.Stack };
                return Ok(data);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

        }

        [HttpDelete]
        public IHttpActionResult DeleteStack()
        {
            try
            {
                Models.DataRes.Stack.Pop();
                int lastStackItem = 0;
                if (Models.DataRes.Stack.Count > 0)
                {
                    lastStackItem = Models.DataRes.Stack.Peek();
                }
                int res = Models.DataRes.Result + lastStackItem;
                var data = new { res, Models.DataRes.Stack };
                return Ok(data);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
