using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGameDAL.Data;
using VideoGameDAL.Models;
using static Microsoft.Extensions.Logging.EventSource.LoggingEventSource;

namespace VideoGameDAL
{
    public class EFVideoGameDal : IGameDAL
    {

        VideoGameContext context;

        public EFVideoGameDal(VideoGameContext context)
        {
            this.context = context;
        }

        public void SaveContextChanges(VideoGameContext context)
        {
            context.SaveChanges();
        }

        public int AddProduct(Game newProduct)
        {
            newProduct.LoanDate = "";
            newProduct.LoanedTo = "";
            context.Games.Add(newProduct);
            context.SaveChanges();
            return newProduct.Id;
        }

        public void DeleteProduct(int productId)
        {
            var productToDelete = context.Games.Where(p => p.Id == productId).FirstOrDefault();
            context.Games.Remove(productToDelete);
            context.SaveChanges();
        }

        public List<Game> GetAllProducts()
        {
            context.SaveChanges();
            return context.Games.ToList();
        }

        public List<Game> ProductFilter(string platform, string genre, string esrb)
        {
            platform = platform.ToLower();
            genre = genre.ToLower();
            esrb = esrb.ToLower();

            var results = new List<Game>();

            if (genre != null && platform != null && esrb != null)
            {
                results = context.Games.Where((game) => game.Genre.ToLower().Contains(genre) &&
                                                game.Platform.ToLower().Contains(platform) &&
                                                game.Rating.ToLower().Contains(esrb)).ToList();
            }

            if (genre != "" && platform == "" && esrb == "")
            {
                results = context.Games.Where((game) => game.Genre.ToLower().Contains(genre)).ToList();
            }

            if (genre == "" && platform != "" && esrb == "")
            {
                results = context.Games.Where((game) => game.Platform.ToLower().Contains(platform)).ToList();
            }

            if (genre == "" && platform == "" && esrb != "")
            {
                results = context.Games.Where((game) => game.Rating.ToLower().Contains(esrb)).ToList();
            }

            return results;
        }

        public List<Game> ProductSearch(string keyword)
        {
            keyword = keyword.ToLower();

            // Use LINQ to fitler the products by keyword
            var results = context.Games.Where((game) => game.Title.ToLower().Contains(keyword));

            return results.ToList();
        }

        public void EditGame(string OriginalTitle, string Platform, string NewTitle, string Genre, string Rating, int Year, string ImageUrl)
        {
            OriginalTitle = OriginalTitle.ToLower();

            // Use LINQ to fitler the products by keyword
            var results = context.Games.Where((game) => game.Title.ToLower().Contains(OriginalTitle)).ToList();
            foreach (var game in results)
            {
                game.Year = Year;
                game.Platform = Platform;
                game.Title = NewTitle;
                game.Rating = Rating;
                game.ImageUrl = ImageUrl;
                game.Genre = Genre;
                context.Games.Update(game);
            }
            context.SaveChanges();
        }
    }
}
