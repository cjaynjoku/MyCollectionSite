using System.Diagnostics;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyCollectionSite.Models;


namespace MyCollectionSite.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly CollectionItemRepository _repository;

    public HomeController(ILogger<HomeController> logger, CollectionItemRepository repository)
    {
        _logger = logger;
        _repository = repository;

    }

    public IActionResult Index()
    {
        var items = _repository.Get();
        return View(items);
    }

    [HttpGet("/api/items")]
    public ActionResult<IEnumerable<CollectionItem>> GetApi()
    {
        return Ok(_repository.Get());
    }

    [HttpGet("/api/items/{id:int}")]
    public ActionResult<CollectionItem> FindItemApi(int id)
    {
        
            var item = _repository.FindById(id);
            return item == CollectionItem.NotFound ? NotFound() :
            Ok(item);
     
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {

        var exceptionHandlerFeature = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
        var exception = exceptionHandlerFeature.Error;
        ViewBag.StackTrace = exception.StackTrace;
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
