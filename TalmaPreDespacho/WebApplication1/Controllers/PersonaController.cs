namespace WebApplication1.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Web.Http;

    /// <summary>
    /// PersonaController
    /// </summary>
    public class PersonaController : ApiController
    {
        [HttpGet]
        public IHttpActionResult getPerson()
        {
            try
            {
                List<Person> list = new List<Person>();
                //list = BL.traerDatos();
                //object obj1 = new { id = "1" };
                //object obj2 = new { id = "2" };

                list.Add(new Person { id= "1"});
                list.Add(new Person { id = "2" });
                //list.Add(obj2);

                return Ok(list);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

        }

        [HttpGet]
        public IHttpActionResult getPersonById(string id)
        {
            try
            {
                return Ok(new Person { id = "1" });
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

        }

        [HttpPost]
        public IHttpActionResult insertPerson([FromBody] Person person)
        {
            try
            {
                return Ok(new { success = true });
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

        }

        [HttpPut]
        public IHttpActionResult updatePerson([FromBody] Person person, [FromUri] string id)
        {
            try
            {
                return Ok(new { success = true });
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

        }

        [HttpDelete]
        public IHttpActionResult deletePerson([FromUri] string id)
        {
            try
            {
                return Ok(new { success = true });
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

        }
    }

    public class Person
    {
        public string id { get; set; }
    }
}
