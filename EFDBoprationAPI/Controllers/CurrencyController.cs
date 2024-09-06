using EFDBoprationAPI.Data;
using Microsoft.AspNetCore.Mvc;

//this is a asp.net Web Api Concept to get Data first We need Dbcontext object(1.create by new keyword 2.by dependancy injection)
//implemnt action method
namespace EFDBoprationAPI.Controller
{
    [Route ("[controller]")]
    [ApiController]
    public class CurrencyController : ControllerBase
    {
        private readonly AppDBContext appdbcontext;

        public CurrencyController(AppDBContext appdbcontext) {
            this.appdbcontext = appdbcontext;
        }

        //this is a action method:

        [HttpGet(Name ="GetLanguageData")]
        public IActionResult GetlanguageData()
        {
            /*
             * in real life we can not call database Directly from Controller 
             * for that we create seprate layer and call this layer from controler for securty and effectivey managed.
             * 
             */

            //here we directly call Database and Write logic to get Data

            var LanguageTableData=this.appdbcontext.Language.ToList();

            return Ok(LanguageTableData);
            

            //comment unnessasary:
        }
    }
}
