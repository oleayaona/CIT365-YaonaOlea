using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyScriptureJournal.Data;
using MyScriptureJournal.Models;

namespace MyScriptureJournal.Pages.Scriptures
{
    public class IndexModel : PageModel
    {
        private readonly MyScriptureJournal.Data.MyScriptureJournalContext _context;

        public IndexModel(MyScriptureJournal.Data.MyScriptureJournalContext context)
        {
            _context = context;
        }

        public IList<Scripture> Scripture { get;set; }

        // Search feature vars
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }

        public SelectList Books { get; set; }
        public SelectList Dates { get; set; }

        [BindProperty(SupportsGet = true)]
        public string ScriptureBook { get; set; }

        [BindProperty(SupportsGet = true)]
        public string ScriptureEntryDate { get; set; }

        // Sort
        [BindProperty(SupportsGet = true)]
        public string Sort { get; set; }

        //
        public async Task OnGetAsync()
        {
            // Get all scriptures
            var scriptures = from m in _context.Scripture
                         select m;

            if (!string.IsNullOrEmpty(SearchString))
            {
                scriptures = scriptures.Where(s => s.Note.Contains(SearchString));
            }

            // Get all books
            IQueryable<string> scriptureQuery = from m in _context.Scripture
                                            orderby m.Book
                                            select m.Book;

            if (!string.IsNullOrEmpty(ScriptureBook))
            {
                scriptures = scriptures.Where(x => x.Book == ScriptureBook);
                
            }

            // Sort
            if (!string.IsNullOrEmpty(Sort))
            {
                Console.WriteLine("Sort selection is: " + Sort);
                switch (Sort)
                {
                    case "Date_Desc":
                        scriptures = scriptures.OrderByDescending(s => s.EntryDate);
                        break;
                    case "Date_Asc":
                        scriptures = scriptures.OrderBy(s => s.EntryDate);
                        break;
                    case "Book":
                        scriptures = scriptures.OrderBy(s => s.Book);
                        break;
                    default:
                        scriptures = scriptures.OrderByDescending(s => s.EntryDate);
                        break;
                }
            }


            // Populate select inputs
            Books = new SelectList(await scriptureQuery.Distinct().ToListAsync());

            Scripture = await scriptures.ToListAsync();
        }
    }
}
