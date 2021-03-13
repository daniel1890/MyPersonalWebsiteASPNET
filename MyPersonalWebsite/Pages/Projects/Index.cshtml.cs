using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyPersonalWebsite.Data;
using MyPersonalWebsite.Models;

namespace MyPersonalWebsite.Pages.Projects
{
    public class IndexModel : PageModel
    {
        private readonly MyPersonalWebsite.Data.MyPersonalWebsiteContext _context;

        public IndexModel(MyPersonalWebsite.Data.MyPersonalWebsiteContext context)
        {
            _context = context;
        }

        public IList<Project> Project { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }

        public SelectList ProgrammeerTalen { get; set; }

        [BindProperty(SupportsGet = true)]
        public string ProgrammeerTaal { get; set; }

        public async Task OnGetAsync()
        {
            // Gebruik Linq om lijst van genres te verkrijgen.
            IQueryable<string> programmeerTaalQuery = from p in _context.Project
                                                      orderby p.ProgrammeerTaal
                                                      select p.ProgrammeerTaal;

            // Gebruik linq om de projecten verkrijgbaar te maken en daarna door de lijst te filteren met de "SearchString".
            var projects = from p in _context.Project
                           select p;

            if (!string.IsNullOrEmpty(SearchString))
            {
                projects = projects.Where(s => s.Titel.Contains(SearchString));
            }

            if (!string.IsNullOrEmpty(ProgrammeerTaal))
            {
                projects = projects.Where(p => p.ProgrammeerTaal == ProgrammeerTaal);
            }

            ProgrammeerTalen = new SelectList(await programmeerTaalQuery.Distinct().ToListAsync());
            Project = await projects.ToListAsync();
        }
    }
}