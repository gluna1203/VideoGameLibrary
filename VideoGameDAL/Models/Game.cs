namespace VideoGameDAL.Models
{
    public class Game
    {
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
