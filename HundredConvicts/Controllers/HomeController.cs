using HundredConvicts.Domain;
using HundredConvicts.Models;
using HundredConvicts.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HundredConvicts.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        IBoxService _boxService;

        public HomeController(ILogger<HomeController> logger, IBoxService boxService)
        {
            _logger = logger;
            _boxService = boxService;
        }

        public IActionResult Index(int numberOfConvicts = 100)
        {         
            var boxes = _boxService.CreateBoxes(numberOfConvicts);
            var convictHistories = new List<ConvictHistory>();

            for (int i = 0; i < numberOfConvicts; i++)
            {
                convictHistories.Add(
                    new ConvictHistory 
                    { 
                        ConvictIndex = i, 
                        FirstTry = _boxService.CreateSequenceTry(i,boxes) 
                    });                
            }

            var viewModel = new IndexViewModel() 
            { 
                Boxes = boxes,
                ConvictHistories = convictHistories
            };
            
            return View(viewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
