using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using URLConverter.Models;
using System.Web;
using static URLConverter.UrlDTO.UrlDataAccess;

namespace URLConverter.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }


        public IActionResult Index()
        {
            var url = new List<URLConverterModel>();
            try
            {
                url = LoaduRLConverters();


            }
            catch (Exception ex)
            {
                TempData["error"] = "Error loading results";
                _logger.LogError(ex.Message + ex.StackTrace);
            }

            ViewBag.url = url;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult insertUrl(URLConverterModel model)
        {
            try
            {
                if (string.IsNullOrEmpty(model.UrlOriginal))
                    throw new ArgumentException("URL invalid! Please try again!");  //ideally we would use our custom exception class

                model.NewUrl = sha256(model.UrlOriginal);
                InsertQuery(model);

                TempData["message"] = "URL Converted!"; 
            }
            catch (ArgumentException ex)
            {
                TempData["error"] = ex.Message;
            }
            catch (Exception ex)
            {
                TempData["error"] = "unexpeted error occured, please contact support";
                _logger.LogError(ex.Message + ex.StackTrace);
            }
            return RedirectToAction("Index");

        }

        //[Route("Home/R/{hashURL}")]
        [Route("{hashURL}")]
        public IActionResult RedirectToURL(string hashURL)
        {
            if (string.IsNullOrEmpty(hashURL))
                return RedirectToAction("Index");
            var redirectURL = new URLConverterModel();

            try
            {
               redirectURL = LoadSelectUrl(hashURL);

                string url = redirectURL.UrlOriginal.ToString();
                if (String.IsNullOrEmpty(url))
                    return RedirectToAction("Index");

            return Redirect(url);
            }
            catch (Exception ex)
            {
                TempData["error"] = "unexpeted error occured, please contact support";
                _logger.LogError(ex.Message + ex.StackTrace);
            }
            return RedirectToAction("Index");
        }

        public static string sha256(string randomString)
        {
            var crypt = new System.Security.Cryptography.SHA256Managed();
            var hash = new StringBuilder();

            byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(randomString));
            foreach (byte theByte in crypto)
            {
                hash.Append(theByte.ToString("x2"));
            }
            return hash.ToString().Remove(8);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
