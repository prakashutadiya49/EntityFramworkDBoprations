using DbOperationsWithEFCoreApp.Data;
using EFDBoprationAPI.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Runtime.CompilerServices;

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


        // get single record by passing parameter: 
        [HttpGet("{id:int}")]
        //Currancy API get Data Sncronuous ways for better performance we used Asyncronuous way:
        public async Task<IActionResult> GetLanguageDataAsync([FromRoute] int id)
        {
            var languagenames = await (from rows in appdbcontext.Language
                               select rows.Title).ToListAsync();

            var singlerecord = await appdbcontext.Language.FindAsync(id);
                    
            return Ok(singlerecord);
        }


        //get record by name pass in route parameter:
        //[HttpGet("{name:alpha}")]
        //public async Task<IActionResult> GetPassLangDataAsync([FromRoute] string name)
        //{
        //    //var singlelangdata = await appdbcontext.Language.Where(l => l.Title == name).FirstAsync();   //not avaiable throw exception

        //    var singlelangdata= await appdbcontext.Language.FirstOrDefaultAsync(l => l.Title == name);  //if not available return defult value 
        //    return Ok(singlelangdata);
        //}




        //get record by passing two or more parameter:
        [HttpGet("{name}/{discription}")]
        public async Task<IActionResult> GetbymultipleparaData([FromRoute] string name,string discription)
        {
            //var result = await appdbcontext.Language.SingleAsync(l => l.Title == name && l.Description == discription); //if single record match pass parameter then return else throw exception.

            var result = await appdbcontext.Language.SingleOrDefaultAsync(l => l.Title == name && l.Description == discription); // //if not available return defult value and if dubicate records then throw exception
            return Ok(result);
        }



        //pass parameter in query not fromroute.
        [HttpGet("{name}")]
        public async Task<IActionResult> GetBypassingInQueryAsync([FromRoute] string name, [FromQuery] string? discription)
        {

            //if we not pass discription then also give data.
            var result = await appdbcontext.Language.FirstOrDefaultAsync(
                l => l.Title == name 
                && (string.IsNullOrEmpty(discription) || l.Description == discription)); // //if not available return defult value and if dubicate records then throw exception
            return Ok(result);
        }

        //getdata when multiple ids pass in body in form of list: 
        [HttpPost("allenteridsdata")]
        public async Task<IActionResult> GetSpacificIDSData([FromBody] List<int> Ids)
        {
            var result = await appdbcontext.Language.Where(l => Ids.Contains(l.Id)).ToListAsync();
            return Ok(result);
        }

        //getdata when multiple namesoflanguage or title pass in body in form of list: 
        [HttpPost("allentertitlesdata")]
        public async Task<IActionResult> GetSpacificIDSData([FromBody] List<string> titles)
        {
            var result = await appdbcontext.Language.Where(l => titles.Contains(l.Title)).ToListAsync();
            return Ok(result);
        }

        //only spacific column select and pass data to another table.(language table first two column data pass=>languagedatatransfertable
        //for that pass ids in bodty which data you went to pass.
        [HttpPost("GetSpacifiColumnDatTransfer")]
        public async Task<IActionResult> GetspacificcolumsData([FromBody] List<int> Ids)
        {
            // Fetch the data from the database language based on the provided IDs
            // Prepare the new records to be added
            var languages = await appdbcontext.Language
                .Where(l => Ids.Contains(l.Id)).Select(l => new languagedatatransfertable()
                {
                    languagename = l.Title,
                }).ToListAsync();


            //add returns records in languagedatatransfertable 
            await appdbcontext.languagedatatransfertable.AddRangeAsync(languages);

            //save changes are required to update database

            await appdbcontext.SaveChangesAsync();

            //return which object added in another table
            return Ok(languages);
        }

    }
}