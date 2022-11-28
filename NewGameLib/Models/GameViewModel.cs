using VideoGameDAL.Models;

namespace NewGameLib.Models
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
