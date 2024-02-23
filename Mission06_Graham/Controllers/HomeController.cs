using Microsoft.AspNetCore.Mvc;
using Mission06_Graham.Models;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;

// Define the namespace for the HomeController
namespace Mission06_Graham.Controllers
{
    // Define the HomeController class that inherits from Controller
    public class HomeController : Controller
    {
        private EnterMovieContext _context; // Declare a private variable for the database context

        // Constructor that initializes the database context with the injected EnterMovieContext instance
        public HomeController(EnterMovieContext temp)
        {
            _context = temp;
        }

        // Action method for the Index view, which serves as the default page
        public IActionResult Index()
        {
            return View(); // Returns the Index view
        }

        // Action method for the GetToKnow view, providing information about the application or its creators
        public IActionResult GetToKnow()
        {
            return View(); // Returns the GetToKnow view
        }

        // GET request handler for entering a new movie, displays the form to the user
        [HttpGet]
        public IActionResult EnterMovie()
        {
            ViewBag.Categories = _context.Categories.ToList(); // Passes categories to the view for selection
            return View("EnterMovie", new EnterMovie()); // Returns the EnterMovie view with a new EnterMovie model
        }

        // POST request handler for submitting a new movie, saves the movie to the database
        [HttpPost]
        public IActionResult EnterMovie(EnterMovie response)
        {
            // Checks if the submitted form data is valid
            if (!ModelState.IsValid)
            {
                ViewBag.Categories = _context.Categories.ToList(); // Refreshes categories in case of invalid submission
                return View(response); // Returns the view with the previously entered data for corrections
            }
            else
            {
                _context.Movies.Add(response); // Adds the new movie to the database context
                _context.SaveChanges(); // Saves changes to the database

                ViewBag.Categories = _context.Categories.ToList(); // Refreshes categories for the confirmation view

                return View("Confirmation", response); // Returns the Confirmation view with the entered movie data
            }
        }

        // Action method for viewing the list of movies, utilizing LINQ to include category data
        public IActionResult Index1()
        {
            var movies = _context.Movies.Include(x => x.Category).ToList(); // Retrieves all movies with their categories
            return View(movies); // Returns the view with the list of movies
        }

        // GET request handler for editing a movie, pre-populates the form with existing movie data
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var recordToEdit = _context.Movies.Single(x => x.MovieId == id); // Finds the movie by ID
            ViewBag.Categories = _context.Categories.ToList(); // Passes categories to the view for selection

            return View("EnterMovie", recordToEdit); // Returns the EnterMovie view with the movie data to edit
        }

        // POST request handler for updating a movie in the database
        [HttpPost]
        public IActionResult Edit(EnterMovie updatedInfo)
        {
            _context.Update(updatedInfo); // Updates the movie data in the database context
            _context.SaveChanges(); // Saves changes to the database

            return RedirectToAction("Index1"); // Redirects to the movie list view after updating
        }

        // GET request handler for deleting a movie, displays confirmation before deletion
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var recordToDelete = _context.Movies.Single(x => x.MovieId == id); // Finds the movie by ID

            return View(recordToDelete); // Returns the view for confirming the deletion with the movie data
        }

        // POST request handler for deleting a movie from the database
        [HttpPost]
        public IActionResult Delete(EnterMovie application)
        {
            _context.Movies.Remove(application); // Removes the movie from the database context
            _context.SaveChanges(); // Saves changes to the database

            return RedirectToAction("Index1"); // Redirects to the movie list view after deletion
        }
    }
}
