using Lab3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Lab3.Controllers
{
    public class ErrorController : ApiController
    {
        // GET: Error
        [Route("api/Error/{code}")]
        public IHttpActionResult Get(int code)
        {
            ErrorDetails errorDetails;
            switch (code)
            {
                case 4500:
                    errorDetails = new ErrorDetails(4500, "Server error");
                    break;
                case 4444:
                    errorDetails = new ErrorDetails(4444, "Model is invalid");
                    break;
                case 4404:
                    errorDetails = new ErrorDetails(4404, "Not found");
                    break;
                default:
                    errorDetails = new ErrorDetails(4321, "Unknown error code");
                    break;
            }
            return Ok(errorDetails);
        }
    }
}