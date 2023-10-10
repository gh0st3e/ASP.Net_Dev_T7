using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Runtime.Serialization;
using System.Security.Policy;
using System.Text;
using System.Web.Helpers;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.UI.WebControls;
using System.Web.WebPages;
using System.Xml.Serialization;
using Lab3.Models;
using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Lab3.Controllers
{
    public class StudentsController : ApiController
    {
        private DatabaseContext db = new DatabaseContext();

        [ResponseType(typeof(Student))]
        [Route("api/Students/{id}")]
        [Route("api/Students.json/{id}")]
        [Route("api/Students.xml/{id}")]
        [Route("api/Students.{ext}/{id}")]
        public HttpResponseMessage GetStudent(int? id)
        {
            try
            {
                var student = db.Students.Where(stud => stud.Id == id).FirstOrDefault();
                if (student.Name == null){
                    throw new Exception("No such student");
                }
                string linkStudent = Request.RequestUri.GetLeftPart(UriPartial.Path);

                string extension = Request.RequestUri.GetLeftPart(UriPartial.Path);

                if (extension.Contains(".json"))
                {
                    student._links = new Hateoas(
                        linkStudent.Substring(0, linkStudent.LastIndexOf("/")),
                        linkStudent.Substring(0, linkStudent.LastIndexOf("/")) + ".xml/",
                        linkStudent,
                        linkStudent.Substring(0, linkStudent.LastIndexOf("/")) + ".xml/" + id
                    );

                    string json = JsonConvert.SerializeObject(student);
                    return new HttpResponseMessage()
                    {
                        Content = new StringContent(json, Encoding.UTF8, "application/json")
                    };
                }

                else if (extension.Contains(".xml"))
                {
                    student._links = new Hateoas(
                        linkStudent.Substring(0, linkStudent.LastIndexOf(".")),
                        linkStudent.Substring(0, linkStudent.LastIndexOf(".")) + ".xml/",
                        linkStudent.Substring(0, linkStudent.LastIndexOf(".")) + "/" + id,
                        linkStudent.Substring(0, linkStudent.LastIndexOf(".")) + ".xml/" + id
                    );

                    var xmlSerializer = new XmlSerializer(typeof(Student));
                    var xmlStringWriter = new System.IO.StringWriter();
                    xmlSerializer.Serialize(xmlStringWriter, student);
                    return new HttpResponseMessage()
                    {
                        Content = new StringContent(xmlStringWriter.ToString(), Encoding.UTF8, "application/xml")
                    };
                }
                else
                {
                    student._links = new Hateoas(
                        linkStudent.Substring(0, linkStudent.LastIndexOf("/")),
                        linkStudent.Substring(0, linkStudent.LastIndexOf("/")) + ".xml/",
                        linkStudent,
                        linkStudent.Substring(0, linkStudent.LastIndexOf("/")) + ".xml/" + id
                    );
                    string json = JsonConvert.SerializeObject(student);
                    return new HttpResponseMessage()
                    {
                        Content = new StringContent(json, Encoding.UTF8, "application/json")
                    };
                }
            }
            catch (Exception ex)
            {
                //return Content(HttpStatusCode.BadRequest, new Error(4500, Request.RequestUri.GetLeftPart(UriPartial.Authority)));
                var error = new Error(4500, Request.RequestUri.GetLeftPart(UriPartial.Authority));
                string jsonError = JsonConvert.SerializeObject(error);

                return new HttpResponseMessage()
                {
                    Content = new StringContent(jsonError, Encoding.UTF8, "application/json")
                };
            }
        }

        [ResponseType(typeof(Student))]
        [Route("api/Students.json")]
        [Route("api/Students.xml")]
        [Route("api/Students.{ext}")]
        [Route("api/Students")]
        public HttpResponseMessage GetStudents(
            [FromUri] int? limit = null,
            [FromUri] int? offset = null,
            [FromUri] int? minID = Int32.MinValue,
            [FromUri] int? maxID = Int32.MaxValue,
            [FromUri] int? order = null,
            [FromUri] string like = "",
            [FromUri] string globalLike = "",
            [FromUri] string columns = "")
        {
            int defaultLimit = 5;
            int defaultOffset = 0;

            int actualLimit = limit ?? defaultLimit;
            int actualOffset = offset ?? defaultOffset;

            string sqlQuery = "";
            var students = new List<Student>();

            if (globalLike == "")
            {
                sqlQuery += "SELECT * FROM Students " +
                    "WHERE Students.Id BETWEEN @P0 AND @P1 " +
                    "AND Students.Name like '%' + @P2 + '%' ";
                if (order != null)
                {
                    sqlQuery += "ORDER BY Students.Name ";
                }
                else
                {
                    sqlQuery += "ORDER BY Students.ID ";
                }

                sqlQuery += "OFFSET @P3 ROWS FETCH NEXT @P4 ROWS ONLY ";

                students = db.Students.SqlQuery(sqlQuery, minID, maxID, like, actualOffset, actualLimit).ToList();
            }
            else
            {
                sqlQuery += "SELECT * FROM Students " +
                    "WHERE Students.Id BETWEEN @P0 AND @P1 " +
                    "AND (CONCAT(Id,Name,Phone)) LIKE '%' + @P2 + '%' ";
                if (order != null)
                {
                    sqlQuery += "ORDER BY Students.Name ";
                }
                else
                {
                    sqlQuery += "ORDER BY Students.ID ";
                }

                sqlQuery += "OFFSET @P3 ROWS FETCH NEXT @P4 ROWS ONLY ";

                students = db.Students.SqlQuery(sqlQuery, minID, maxID, globalLike, actualOffset, actualLimit).ToList();

            }

            if (columns != "")
            {
                columns = columns.ToLower();
                if (!columns.Contains("name"))
                    students.ForEach(x => x.Name = null);
                if (!columns.Contains("phone"))
                    students.ForEach(x => x.Phone = null);
            }

            string linkStudents = Request.RequestUri.GetLeftPart(UriPartial.Path);



            string extension = Request.RequestUri.GetLeftPart(UriPartial.Path);

            if (extension.Contains(".json"))
            {
                students.ForEach(student => student._links = new Hateoas(
                    linkStudents,
                    linkStudents + ".xml/",
                    linkStudents + "/" + student.Id,
                    linkStudents + ".xml/" + student.Id)
                );

                string json = JsonConvert.SerializeObject(students);
                return new HttpResponseMessage()
                {
                    Content = new StringContent(json, Encoding.UTF8, "application/json")
                };
            }

            else if (extension.Contains(".xml"))
            {

                students.ForEach(student => student._links = new Hateoas(
                    linkStudents.Substring(0, linkStudents.LastIndexOf(".")),
                    linkStudents.Substring(0, linkStudents.LastIndexOf(".")) + ".xml/",
                    linkStudents.Substring(0, linkStudents.LastIndexOf(".")) + "/" + student.Id,
                    linkStudents.Substring(0, linkStudents.LastIndexOf(".")) + ".xml/" + student.Id)
                );

                var xmlSerializer = new XmlSerializer(typeof(List<Student>));
                var xmlStringWriter = new System.IO.StringWriter();
                xmlSerializer.Serialize(xmlStringWriter, students);
                return new HttpResponseMessage()
                {
                    Content = new StringContent(xmlStringWriter.ToString(), Encoding.UTF8, "application/xml")
                };
            }
            else
            {
                students.ForEach(student => student._links = new Hateoas(
                    linkStudents,
                    linkStudents + ".xml/",
                    linkStudents + "/" + student.Id,
                    linkStudents + ".xml/" + student.Id)
                );

                string json = JsonConvert.SerializeObject(students);
                return new HttpResponseMessage()
                {

                    Content = new StringContent(json, Encoding.UTF8, "application/json")
                };
            }

        }

        // POST: api/Students
        [ResponseType(typeof(Student))]
        [Route("api/Students")]
        [Route("api/Students.json")]
        [Route("api/Students.xml")]
        public HttpResponseMessage PostStudent(Student student)
        {
            if (!ModelState.IsValid)
            {
                var error = new Error(4444, Request.RequestUri.GetLeftPart(UriPartial.Authority));
                string jsonError = JsonConvert.SerializeObject(error);
                return new HttpResponseMessage()
                {
                    Content = new StringContent(jsonError, Encoding.UTF8, "application/json")
                };
            }

            db.Students.Add(student);
            db.SaveChanges();
            string linkStudent = Request.RequestUri.GetLeftPart(UriPartial.Path);

            string extension = Request.RequestUri.GetLeftPart(UriPartial.Path);

            if (extension.Contains(".json"))
            {
                student._links = new Hateoas(
                    linkStudent.Substring(0, linkStudent.LastIndexOf("/")),
                    linkStudent.Substring(0, linkStudent.LastIndexOf("/")) + ".xml/",
                    linkStudent + "/" + student.Id,
                    linkStudent.Substring(0, linkStudent.LastIndexOf("/")) + ".xml/" + student.Id
                );

                string json = JsonConvert.SerializeObject(student);
                return new HttpResponseMessage()
                {
                    Content = new StringContent(json, Encoding.UTF8, "application/json")
                };
            }

            else if (extension.Contains(".xml"))
            {
                student._links = new Hateoas(
                        linkStudent.Substring(0, linkStudent.LastIndexOf(".")),
                        linkStudent.Substring(0, linkStudent.LastIndexOf(".")) + ".xml/",
                        linkStudent.Substring(0, linkStudent.LastIndexOf(".")) + "/" + student.Id,
                        linkStudent.Substring(0, linkStudent.LastIndexOf(".")) + ".xml/" + student.Id
                    );

                var xmlSerializer = new XmlSerializer(typeof(Student));
                var xmlStringWriter = new System.IO.StringWriter();
                xmlSerializer.Serialize(xmlStringWriter, student);
                return new HttpResponseMessage()
                {
                    Content = new StringContent(xmlStringWriter.ToString(), Encoding.UTF8, "application/xml")
                };
            }
            else
            {
                string json = JsonConvert.SerializeObject(student);
                return new HttpResponseMessage()
                {

                    Content = new StringContent(json, Encoding.UTF8, "application/json")
                };
            }
        }


        // PUT: api/Students/5
        [ResponseType(typeof(Student))]
        [Route("api/Students/{id}")]
        [Route("api/Students.json/{id}")]
        [Route("api/Students.xml/{id}")]
        [Route("api/Students.{ext}/{id}")]
        public HttpResponseMessage PutStudent(int id, Student student)
        {
            if (!ModelState.IsValid)
            {
                var error = new Error(4444, Request.RequestUri.GetLeftPart(UriPartial.Authority));
                string jsonError = JsonConvert.SerializeObject(error);
                return new HttpResponseMessage()
                {
                    Content = new StringContent(jsonError, Encoding.UTF8, "application/json")
                };
            }

            db.Entry(student).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentExists(id))
                {
                    var error = new Error(4404, Request.RequestUri.GetLeftPart(UriPartial.Authority));
                    string jsonError = JsonConvert.SerializeObject(error);
                    return new HttpResponseMessage()
                    {
                        Content = new StringContent(jsonError, Encoding.UTF8, "application/json")
                    };

                }
                else
                {
                    throw;
                }
            }
            string linkStudent = Request.RequestUri.GetLeftPart(UriPartial.Path);
            student._links = new Hateoas(linkStudent.Substring(
                    0, linkStudent.LastIndexOf("/")),
                    linkStudent.Substring(0, linkStudent.LastIndexOf("/")) + ".xml/",
                    linkStudent,
                    linkStudent.Substring(0, linkStudent.LastIndexOf("/")) + ".xml/" + id);

            string extension = Request.RequestUri.GetLeftPart(UriPartial.Path);

            if (extension.Contains(".json"))
            {
                student._links = new Hateoas(
                        linkStudent.Substring(0, linkStudent.LastIndexOf("/")),
                        linkStudent.Substring(0, linkStudent.LastIndexOf("/")) + ".xml/",
                        linkStudent,
                        linkStudent.Substring(0, linkStudent.LastIndexOf("/")) + ".xml/" + id
                    );

                string json = JsonConvert.SerializeObject(student);
                return new HttpResponseMessage()
                {
                    Content = new StringContent(json, Encoding.UTF8, "application/json")
                };
            }

            else if (extension.Contains(".xml"))
            {
                student._links = new Hateoas(
                        linkStudent.Substring(0, linkStudent.LastIndexOf(".")),
                        linkStudent.Substring(0, linkStudent.LastIndexOf(".")) + ".xml/",
                        linkStudent.Substring(0, linkStudent.LastIndexOf(".")) + "/" + id,
                        linkStudent.Substring(0, linkStudent.LastIndexOf(".")) + ".xml/" + id
                    );

                var xmlSerializer = new XmlSerializer(typeof(Student));
                var xmlStringWriter = new System.IO.StringWriter();
                xmlSerializer.Serialize(xmlStringWriter, student);
                return new HttpResponseMessage()
                {
                    Content = new StringContent(xmlStringWriter.ToString(), Encoding.UTF8, "application/xml")
                };
            }
            else
            {
                student._links = new Hateoas(
                        linkStudent.Substring(0, linkStudent.LastIndexOf("/")),
                        linkStudent.Substring(0, linkStudent.LastIndexOf("/")) + ".xml/",
                        linkStudent,
                        linkStudent.Substring(0, linkStudent.LastIndexOf("/")) + ".xml/" + id
                    );

                string json = JsonConvert.SerializeObject(student);
                return new HttpResponseMessage()
                {

                    Content = new StringContent(json, Encoding.UTF8, "application/json")
                };
            }
        }

        // DELETE: api/Students/5
        [ResponseType(typeof(Student))]
        [Route("api/Students/{id}")]
        [Route("api/Students.json/{id}")]
        [Route("api/Students.xml/{id}")]
        [Route("api/Students.{ext}/{id}")]
        public HttpResponseMessage DeleteStudent(int id)
        {
            Student student = db.Students.Find(id);
            if (student == null)
            {
                var error = new Error(4444, Request.RequestUri.GetLeftPart(UriPartial.Authority));
                string jsonError = JsonConvert.SerializeObject(error);
                return new HttpResponseMessage()
                {
                    Content = new StringContent(jsonError, Encoding.UTF8, "application/json")
                };

            }

            db.Students.Remove(student);
            db.SaveChanges();

            string linkStudent = Request.RequestUri.GetLeftPart(UriPartial.Path);
            student._links = new Hateoas(linkStudent.Substring(
                    0, linkStudent.LastIndexOf("/")),
                    linkStudent.Substring(0, linkStudent.LastIndexOf("/")) + ".xml/",
                    linkStudent,
                    linkStudent.Substring(0, linkStudent.LastIndexOf("/")) + ".xml/" + id);

            string extension = Request.RequestUri.GetLeftPart(UriPartial.Path);

            if (extension.Contains(".json"))
            {
                student._links = new Hateoas(
                        linkStudent.Substring(0, linkStudent.LastIndexOf("/")),
                        linkStudent.Substring(0, linkStudent.LastIndexOf("/")) + ".xml/",
                        linkStudent,
                        linkStudent.Substring(0, linkStudent.LastIndexOf("/")) + ".xml/" + id
                    );

                string json = JsonConvert.SerializeObject(student);
                return new HttpResponseMessage()
                {
                    Content = new StringContent(json, Encoding.UTF8, "application/json")
                };
            }

            else if (extension.Contains(".xml"))
            {
                student._links = new Hateoas(
                        linkStudent.Substring(0, linkStudent.LastIndexOf(".")),
                        linkStudent.Substring(0, linkStudent.LastIndexOf(".")) + ".xml/",
                        linkStudent.Substring(0, linkStudent.LastIndexOf(".")) + "/" + id,
                        linkStudent.Substring(0, linkStudent.LastIndexOf(".")) + ".xml/" + id
                    );

                var xmlSerializer = new XmlSerializer(typeof(Student));
                var xmlStringWriter = new System.IO.StringWriter();
                xmlSerializer.Serialize(xmlStringWriter, student);
                return new HttpResponseMessage()
                {
                    Content = new StringContent(xmlStringWriter.ToString(), Encoding.UTF8, "application/xml")
                };
            }
            else
            {
                student._links = new Hateoas(
                        linkStudent.Substring(0, linkStudent.LastIndexOf("/")),
                        linkStudent.Substring(0, linkStudent.LastIndexOf("/")) + ".xml/",
                        linkStudent,
                        linkStudent.Substring(0, linkStudent.LastIndexOf("/")) + ".xml/" + id
                    );

                string json = JsonConvert.SerializeObject(student);
                return new HttpResponseMessage()
                {

                    Content = new StringContent(json, Encoding.UTF8, "application/json")
                };
            }
        }

        private bool StudentExists(int id)
        {
            return db.Students.Count(e => e.Id == id) > 0;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}