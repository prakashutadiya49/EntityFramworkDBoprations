using DbOperationsWithEFCoreApp.Data;
using EFDBoprationAPI.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace EFDBoprationAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        private readonly AppDBContext _appdbcontext;

        public BookController(AppDBContext appdbcontext)
        {
            _appdbcontext = appdbcontext;
        }


        //add single book at once
        [HttpPost("AddSinglebook")]
        public async Task<IActionResult> AddNewBook([FromBody] Book? model)
        {
            if (model == null)
            {
                return BadRequest("Book model is required.");
            }

            // Check if the LanguageId exists in the database
            var languageExists = await _appdbcontext.Language.AnyAsync(l => l.Id.Equals(model.LanguageId));
            if (!languageExists)
            {
                return BadRequest("Invalid LanguageId.");
            }

            _appdbcontext.Book.Add(model);
            await _appdbcontext.SaveChangesAsync();

            return Ok(model);
        }

        //add multiplebooks

        [HttpPost("Addmultiplebooks")]
        public async Task<IActionResult> AddnewBooks([FromBody] List<Book> models)
        {
            if (models == null)
            {
                return BadRequest("Book model is required.");
            }
            _appdbcontext.AddRange(models);
            await _appdbcontext.SaveChangesAsync();


            return Ok(models);
        }

        //add author details when book is added.

        [HttpPost("AddBookWithauthor")]

        public async Task<IActionResult> AddBookWithAuthor([FromBody] Book bookwithauthor)
        {
            if (bookwithauthor == null)
            {
                return BadRequest("Book model is required.");
            }
            _appdbcontext.AddRange(bookwithauthor);
            await _appdbcontext.SaveChangesAsync();


            return Ok(bookwithauthor);
        }

        //update book table existing record

        [HttpPut("{bookId}")]
        public async Task<IActionResult> UpdateBook([FromRoute] int bookId, [FromBody] Book model)
        {
            var book = _appdbcontext.Book.FirstOrDefault(x => x.Id == bookId);
            if (book == null)
            {
                return NotFound();
            }

            book.Title = model.Title;
            book.Description = model.Description;
            book.NoOfPages = model.NoOfPages;

            await _appdbcontext.SaveChangesAsync();

            return Ok(model);
        }

        [HttpPut("")]
        public async Task<IActionResult> UpdateBookWithSingleQuery([FromBody] Book model)
        {
            _appdbcontext.Entry(model).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _appdbcontext.SaveChangesAsync();

            return Ok(model);
        }

        [HttpPut("bulk")]
        public async Task<IActionResult> UpdateBookInBulk()
        {
            await _appdbcontext.Book
                .Where(x => x.NoOfPages == 100)
                .ExecuteUpdateAsync(x => x
            .SetProperty(p => p.Description, p => p.Title + " This is book description 2")
            .SetProperty(p => p.Title, p => p.Title + " updated 2")
            //.SetProperty(p => p.NoOfPages, 100)
            );
            return Ok();
        }

        [HttpDelete("{bookId}")]
        public async Task<IActionResult> DeleteBookByIdAsync([FromRoute] int bookId)
        {
            var book = new Book { Id = bookId };
            _appdbcontext.Entry(book).State = EntityState.Deleted;
            await _appdbcontext.SaveChangesAsync();
             

            //var book = await appDbContext.Books.FindAsync(bookId);

            //if (book == null)
            //{
            //    return NotFound();
            //}
            //appDbContext.Books.Remove(book);
            //await appDbContext.SaveChangesAsync();

            return Ok();
        }


        [HttpDelete("bulk")]
        public async Task<IActionResult> DeleteBooksinBulkAsync()
        {
            //var book = new Book { Id = bookId };
            //appDbContext.Entry(book).State = EntityState.Deleted;
            //await appDbContext.SaveChangesAsync();

            var books = await _appdbcontext.Book.Where(x => x.Id < 8).ExecuteDeleteAsync();

            return Ok();
        }
    }

}

