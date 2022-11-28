using VideoGameDAL.Models;

namespace NewGameLib.Models
{
    public class GameDetailsViewModel
    {

        public GameDetailsViewModel(Game game)
        {
            this.Id = game.Id;
            this.ImageUrl = game.ImageUrl;
            this.Title = game.Title;
            this.Platform = game.Platform;
            this.Genre = game.Genre;
            this.Rating = game.Rating;
            this.Year = game.Year;
            this.LoanDate = game.LoanDate;
            this.LoanedTo = game.LoanedTo;
        }
        public int Id { get; set; }
        public string Platform { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public string Rating { get; set; }
        public int Year { get; set; }
        public string ImageUrl { get; set; }
        public string LoanedTo { get; set; }
        public string LoanDate { get; set; }
    }
}
