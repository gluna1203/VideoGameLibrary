using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGameDAL.Models;

namespace VideoGameDAL.Data
{
    public class DbInitializer
    {

        public static void Initialize(VideoGameContext context)
        {
            context.Database.EnsureCreated();
            SetupProducts(context);
        }

        public static void SetupProducts(VideoGameContext context)
        {
            // Have we already setup products?
            // We only want to do this once!
            if (context.Games.Any())
            {
                return;
            }

            var products = new Game[]
            {
            new Game() { Title= "Tom Clancy's Rainbow Six Siege", Platform="Xbox One, Playstation, PC", Genre= "Tactical shooter", Rating="M", Year=2015, LoanDate=new DateTime(2015,12,31).ToString("MM/dd/yyyy"), LoanedTo="Gabriel", ImageUrl= "https://upload.wikimedia.org/wikipedia/en/4/47/Tom_Clancy%27s_Rainbow_Six_Siege_cover_art.jpg" },
            new Game() { Title="Assassin's Creed Odyssey", Platform="Xbox One, Playstation, PC", Genre= "Adventure game", Rating="M", Year=2018, LoanDate="", LoanedTo="", ImageUrl= "https://image.api.playstation.com/cdn/EP0001/CUSA09303_00/HXxek19ysMe9h1WjkasfIcovCjlbBitz.png" },
            new Game() { Title= "Super Smash Bros.", Platform="Nintendo Switch", Genre = "Cooperative game theory, Crossover", Rating="E10+", Year=2018, LoanDate=new DateTime(2018,12,31).ToString("MM/dd/yyyy"), LoanedTo="Gabriel", ImageUrl= "https://ssb.wiki.gallery/images/thumb/1/15/Super_Smash_Bros_Ultimate_Box_Art.png/1200px-Super_Smash_Bros_Ultimate_Box_Art.png" },
            new Game() { Title="Hitman 3", Platform="Xbox One, Playstation, PC, Nintendo Switch, Google Stadia", Genre= "Stealth game", Rating="M", Year=2021, LoanDate=new DateTime(2021,12,31).ToString("MM/dd/yyyy"), LoanedTo="Gabriel", ImageUrl= "https://cdn1.epicgames.com/ed55aa5edc5941de92fd7f64de415793/offer/EGS_HITMAN3_IOInteractiveAS_S2-1200x1600-b285fb6eb586113c9479ff33ed646b69.jpg" },
            new Game() { Title= "Paper Mario: The Thousand-Year Door", Platform="GameCube", Genre="Action Game", Rating="E", Year=2004, LoanDate="", LoanedTo="", ImageUrl= "https://m.media-amazon.com/images/I/61Q05FCGB9L.jpg" }
            };

            foreach (var product in products)
            {
                context.Games.Add(product); // Tell context to add more products
            }
            context.SaveChanges(); // Products are saved once this method is called
        }
    }
}
