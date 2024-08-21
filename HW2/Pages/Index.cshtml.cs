using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HW2.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
    }

    public IActionResult OnGetDownloadFile()
    {
        var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "GaribaDadashovaCV.pdf");

        if (System.IO.File.Exists(path))
        {
            return PhysicalFile(path, "application/pdf", "GaribaDadashovaCV.pdf");
        }

        return NotFound();
    }
    
}