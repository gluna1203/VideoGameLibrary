using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;
using VideoGameDAL;
using VideoGameDAL.Data;
using VideoGameDAL.Models;
using VideoGameLibrary.Models;

namespace VideoGameLibrary.Controllers
{
    public class GameController : Controller
    {
        //static GameViewModel currentView = new GameViewModel();
        //IGameDAL dal = new StaticGameDAL();

        private readonly IGameDAL dal;

        public GameController(IGameDAL dal, VideoGameContext context)
        {
            this.dal = new EFVideoGameDal(context);
        }

        public IActionResult Index()
        {
            ViewBag.WelcomeMessage = "Welcome To The Game Collection Library!";
            return View();
        }

        /*public IActionResult GameCollection()
        {
            GameViewModel model = new GameViewModel();
            model.Games = dal.GetAllProducts();
            return View(model);
        }*/

        public IActionResult GameCollection(GameViewModel model)
        {
            model.Games.Clear();
            model.Games = dal.GetAllProducts();
            return View(model);
        }

        public IActionResult GameDetails(int id)
        {
            Game currentGame = dal.GetAllProducts().Find(x => x.Id == id);

            // Create a GameDetailsViewModel
            // Set it up with the details the View Needs about your game
            GameDetailsViewModel game = new GameDetailsViewModel(currentGame);
            return View(game);
        }


        [HttpPost]
        public IActionResult GameDetails(int id, string name)
        {
            //Edit this so they can return a game
            GameViewModel model = new GameViewModel();

            var index = dal.GetAllProducts().FindIndex(x => x.Id == id);
            var date = DateTime.Now.ToString("MM/dd/yyyy");

            if (string.IsNullOrEmpty(dal.GetAllProducts()[index].LoanedTo))
            {

                dal.GetAllProducts()[index].LoanDate = date;
                dal.GetAllProducts()[index].LoanedTo = name;
            }
            else
            {
                dal.GetAllProducts()[index].LoanDate = "";
                dal.GetAllProducts()[index].LoanedTo = "";
            }

            model.Games = dal.GetAllProducts();

            return View("GameCollection", model);
        }

        public IActionResult GameAddDelete()
        {
            return View();
        }

        [HttpPost]
        public IActionResult GameAddDelete(string Id, string imageURL, string Title, string Rating, string Platform, string Genre, string Year)
        {
            GameViewModel model = new GameViewModel();

            if (Id != null)
            {
                int id;
                bool isNumeric = int.TryParse(Id, out id);
                dal.DeleteProduct(id);
                model.Games = dal.GetAllProducts();
                return View("GameCollection",model);
            } else
            {
                int year;
                bool isNumeric = int.TryParse(Year, out year);
                Game newGame = new Game()
                {
                    ImageUrl = imageURL,
                    Title = Title,
                    Rating = Rating,
                    Platform = Platform,
                    Genre = Genre,
                    Year = year
                };
                dal.AddProduct(newGame);
                model.Games = dal.GetAllProducts();
                return View("GameCollection", model);
            }
        }


        [HttpPost]
        public IActionResult GameSearch(string titleVal, string genreVal, string platVal, string esrbVal)
        {
            GameViewModel model = new GameViewModel();
            if (genreVal == null && platVal == null && esrbVal == null)
            {
                model.Games = dal.ProductSearch(titleVal);
            }

            if(genreVal != null && platVal != null && esrbVal != null)
            {
                model.Games = dal.ProductFilter(platVal, genreVal, esrbVal);
            }

            if (genreVal != null && platVal == null && esrbVal == null)
            {
                model.Games = dal.ProductFilter("", genreVal, "");
            }

            if (genreVal == null && platVal != null && esrbVal == null)
            {
                model.Games = dal.ProductFilter(platVal, "", "");
            }

            if (genreVal == null && platVal == null && esrbVal != null)
            {
                model.Games = dal.ProductFilter("", "", esrbVal);
            }
            return View(model); //View(Collection, Model)
        }

        public IActionResult GameEdit(int id)
        {
            Game currentGame = dal.GetAllProducts().Find(x => x.Id == id);

            // Create a GameDetailsViewModel
            // Set it up with the details the View Needs about your game
            GameDetailsViewModel game = new GameDetailsViewModel(currentGame);

            return View(game);
        }

        [HttpPost]
        public IActionResult GameEdited(string OriginalTitle, string imageURL, string Title, string Rating, string Platform, string Genre, int year)
        {

            GameViewModel model = new GameViewModel();

            dal.EditGame(OriginalTitle, Platform, Title, Genre, Rating, year, imageURL);
        

            model.Games = dal.GetAllProducts();
            return View("GameCollection", model);
        }
    }
}
