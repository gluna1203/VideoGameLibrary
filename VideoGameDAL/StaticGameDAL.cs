using VideoGameDAL.Models;

namespace VideoGameDAL
{
    public class StaticGameDAL : IGameDAL
    {
        List<Game> games = new List<Game>
        {
            new Game() { Id=1,Title= "Tom Clancy's Rainbow Six Siege", Platform="Xbox One, Playstation, PC", Genre= "Tactical shooter", Rating="M", Year=2015, LoanDate=new DateTime(2015,12,31).ToString("MM/dd/yyyy"), LoanedTo="Gabriel", ImageUrl= "https://upload.wikimedia.org/wikipedia/en/4/47/Tom_Clancy%27s_Rainbow_Six_Siege_cover_art.jpg" },
            new Game() { Id=2,Title="Assassin's Creed Odyssey", Platform="Xbox One, Playstation, PC", Genre= "Adventure game", Rating="M", Year=2018, LoanDate="", LoanedTo="", ImageUrl= "https://image.api.playstation.com/cdn/EP0001/CUSA09303_00/HXxek19ysMe9h1WjkasfIcovCjlbBitz.png" },
            new Game() { Id=3,Title= "Super Smash Bros.", Platform="Nintendo Switch", Genre = "Cooperative game theory, Crossover", Rating="E10+", Year=2018, LoanDate=new DateTime(2018,12,31).ToString("MM/dd/yyyy"), LoanedTo="Gabriel", ImageUrl= "https://ssb.wiki.gallery/images/thumb/1/15/Super_Smash_Bros_Ultimate_Box_Art.png/1200px-Super_Smash_Bros_Ultimate_Box_Art.png" },
            new Game() { Id=4,Title="Hitman 3", Platform="Xbox One, Playstation, PC, Nintendo Switch, Google Stadia", Genre= "Stealth game", Rating="M", Year=2021, LoanDate=new DateTime(2021,12,31).ToString("MM/dd/yyyy"), LoanedTo="Gabriel", ImageUrl= "https://cdn1.epicgames.com/ed55aa5edc5941de92fd7f64de415793/offer/EGS_HITMAN3_IOInteractiveAS_S2-1200x1600-b285fb6eb586113c9479ff33ed646b69.jpg" },
            new Game() { Id=5,Title= "Paper Mario: The Thousand-Year Door", Platform="GameCube", Genre="Action Game", Rating="E", Year=2004, LoanDate="", LoanedTo="", ImageUrl= "https://m.media-amazon.com/images/I/61Q05FCGB9L.jpg" }
        };

        public int AddProduct(Game newProduct)
        {
            newProduct.Id = games.Max(p => p.Id) + 1;
/*            foreach (Game temp in games)
            {
                if(temp.Id == newProduct.Id)
                {
                    newProduct.Id = newProduct.Id + 1;
                }
            }*/
            games.Add(newProduct);
            return newProduct.Id;
        }

        public void DeleteProduct(int productId)
        {
            games.RemoveAt(productId-1);
        }

        public void EditGame(string OriginalTitle, string Platform, string NewTitle, string Genre, string Rating, int Year, string ImageUrl)
        {
            throw new NotImplementedException();
        }

        public List<Game> GetAllProducts()
        {
            return games;
        }

        public List<Game> ProductFilter(string platform, string genre, string esrb)
        {
            platform = platform.ToLower();
            genre = genre.ToLower();
            esrb = esrb.ToLower();

            var results = new List<Game>();

            if (genre != null && platform != null && esrb != null)
            {
                results = games.Where((game) => game.Genre.ToLower().Contains(genre) &&
                                                game.Platform.ToLower().Contains(platform) &&
                                                game.Rating.ToLower().Contains(esrb)).ToList();
            }

            if (genre != "" && platform == "" && esrb == "")
            {
                results = games.Where((game) => game.Genre.ToLower().Contains(genre)).ToList();
            }

            if (genre == "" && platform != "" && esrb == "")
            {
                results = games.Where((game) => game.Platform.ToLower().Contains(platform)).ToList();
            }

            if (genre == "" && platform == "" && esrb != "")
            {
                results = games.Where((game) => game.Rating.ToLower().Contains(esrb)).ToList();
            }

            return results;
        }

        public List<Game> ProductSearch(string keyword)
        {
            keyword = keyword.ToLower();

            // Use LINQ to fitler the products by keyword
            var results = games.Where((game) => game.Title.ToLower().Contains(keyword));

            return results.ToList();
        }
    }
}