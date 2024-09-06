using EFDBoprationAPI.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFDBoprationAPI.Controllers
{
    [Route("API-AvaiableLanguageBooks")]
    [ApiController]
    public class LanguageControler : ControllerBase
    {
        private readonly AppDBContext appdbcontext;

        public LanguageControler(AppDBContext appdbcontext) 
        {
            this.appdbcontext = appdbcontext;
        }

        [HttpGet(Name = "")]

        //Currancy API get Data Sncronuous ways for better performance we used Asyncronuous way:
        public async Task<IActionResult> GetLanguageData()
        {
            var languagenames = await (from rows in appdbcontext.Language
                               select rows.Title).ToListAsync();

          
            return Ok(languagenames);
        }
    }
}
