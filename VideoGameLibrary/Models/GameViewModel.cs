using VideoGameDAL.Models;

namespace VideoGameLibrary.Models
{
    public class GameViewModel
    {
        public List<Game> Games { get; set; }

        public GameViewModel()
        {
            this.Games = new List<Game>();
        }
    }
}
