using Cqrs_Mediator.Application.Abstractions.HttpClientServices;
using Cqrs_Mediator.Application.Features.Product;
using Cqrs_Mediator.presentation.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Cqrs_Mediator.presentation.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IHttpClientServeices _httpClientService;

        public HomeController(ILogger<HomeController> logger, IHttpClientServeices httpClientService)
        {
            _logger = logger;

            _httpClientService = httpClientService;
        }

        public async Task<IActionResult> Index()
        {


            var data = await _httpClientService.PostRequest<List<productsVm>>("/api/Product", HttpMethod.Get);
            return View(data);
        }
        [HttpGet]
        public async Task<IActionResult> CreateProduct(int id)
        {
            if (id <= 0)
            {

                return View();
            }
            else
            {
                var res = await _httpClientService.GetRequestById<productsVm>("/api/Product/GetProductById",id.ToString());
                return View(res);
            }
        }
        [HttpPost]
        public async Task<IActionResult> CreateProduct(productsVm newproduct)
        {
            if (ModelState.IsValid)
            {
                var res = await _httpClientService.PostRequest<productsVm>("/api/Product/DeleteProduct", HttpMethod.Delete,newproduct);

                return View(res);

            }
            return View();
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
