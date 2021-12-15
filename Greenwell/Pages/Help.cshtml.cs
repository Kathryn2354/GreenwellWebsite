using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Greenwell.Pages.help_page
{
    public class HelpModel : PageModel
    {
        private readonly ILogger<HelpModel> _Logger;

        public HelpModel(ILogger<HelpModel> logger) 
        {
            _Logger = logger;
        }

        public void OnGet()
        {

        }
    }
}
