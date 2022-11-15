using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGameDAL.Models;

namespace VideoGameDAL
{
    public interface IGameDAL
    {
        List<Game> GetAllProducts();
        List<Game> ProductSearch(string keyword);
        List<Game> ProductFilter(string name, string genre, string esrb);
        void DeleteProduct(int productId);
        int AddProduct(Game newProduct);
        void EditGame(string OriginalTitle, string Platform, string NewTitle, string Genre, string Rating, int Year, string ImageUrl);
    }
}
