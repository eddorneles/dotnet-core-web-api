using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using webapi01.Model;
using webapi01.Services;

namespace webapi01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private IPersonService personService;

        public PersonsController( IPersonService service ){
            this.personService = service;
        }
        
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return Ok( this.personService.FindAll() );
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(long id)
        {
            var person = this.personService.FindById( id );
            if( person== null ){
                return NotFound();
            }
            return Ok( person );
        }//END Get()

        // POST api/values
        [HttpPost]
        public ActionResult Post([FromBody] Person person)
        {
            if( person == null ) return BadRequest();
            return new ObjectResult( this.personService.Create( person ) );
        }//END Post()

        // PUT api/values/5
        [HttpPut("{id}")]
        public ActionResult Put( [FromBody] Person person )
        {
            if( person == null ) return BadRequest();
            return new ObjectResult( this.personService.Create( person ) );
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id){
            this.personService.Delete( id );
            return NoContent();
        }//END Delete()
    }
}
