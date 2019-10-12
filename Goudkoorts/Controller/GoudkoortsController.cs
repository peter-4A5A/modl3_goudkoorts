using Goudkoorts.Model;
using Goudkoorts.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goudkoorts.Controller
{
    public class GoudkoortsController
    {
        public Game Game { get; set; }

        public GoudkoortsController()
        {
            Game = new Game();
            Game.SetupMap();
        }

        public void Start()
        {
            // Start view
            PlayGame();
        }

        public void PlayGame()
        {
            GameView gameView = new GameView(Game);
            while (Game.IsPlaying)
            {
                gameView.Render();
                Console.ReadLine();
            }
        }
    }
}
