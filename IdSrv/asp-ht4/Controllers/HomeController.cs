using asp_ht4.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using asp_ht4.Services;
using IdentityModel.Client;

namespace asp_ht4.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITokenService _tokenService;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ITokenService tokenService, ILogger<HomeController> logger)
        {
            _tokenService = tokenService;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            using (var client = new HttpClient())
            {
                var tokenResponse = await _tokenService.GetToken("ASP_hometask1.read");

                client.SetBearerToken(tokenResponse.AccessToken);

                var result = client 
                    .GetAsync("https://localhost:5445/swagger")
                    .Result;

                if (result.IsSuccessStatusCode)
                {
                    var model = result.Content.ReadAsStringAsync().Result;

                    return View();
                }
                else
                {
                    throw new Exception("Opps, sth has gone wrong");
                }
            }

            
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