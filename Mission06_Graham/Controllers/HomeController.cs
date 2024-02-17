using Microsoft.AspNetCore.Mvc;
using Mission06_Graham.Models;
using System.Diagnostics;

namespace Mission06_Graham.Controllers
{
    public class HomeController : Controller
    {
        private EnterMovieContext _context;

        public HomeController(EnterMovieContext temp) //constructor
        {
            _context = temp;
        }
        //link to index page view
        public IActionResult Index()
        {
            return View();
        }

        //link to get to know view
        public IActionResult GetToKnow()
        {
            return View();
        }

        [HttpGet]
        public IActionResult EnterMovie()
        {
            return View();
        }

        // saves the info to the database
        [HttpPost]
        public IActionResult EnterMovie(EnterMovie response)
        {
            // check if the requried data was given
            if (!ModelState.IsValid) 
            {
                return View(response);
            }
            else
            {
                //moves on to store the data if the required data was given
                _context.Applications.Add(response); // add record to database
                _context.SaveChanges();

                return View("Confirmation", response);
            }

            
        }

    }
}
