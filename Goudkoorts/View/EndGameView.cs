using Goudkoorts.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goudkoorts.View
{
    public class EndGameView
    {
        private Game _game;
        public EndGameView(Game game)
        {
            _game = game;
        }

        public void Render()
        {
            Console.WriteLine("=========================");
            Console.WriteLine("= Het spel is afgelopen =");
            Console.WriteLine("= U heeft " + _game.Score + " punten gehaald");
            Console.WriteLine("=========================");
        }
    }
}
