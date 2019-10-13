using Goudkoorts.Model;
using Goudkoorts.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Goudkoorts.Controller
{
    public class GoudkoortsController
    {
        private Timer aTimer;

        public Game Game { get; set; }

        public GoudkoortsController()
        {
            Game = new Game();
            Game.SetupMap();
        }

        public void Start()
        {
            // Start view
            aTimer = new System.Timers.Timer();
            aTimer.Interval = 2000;

            // Hook up the Elapsed event for the timer. 
            aTimer.Elapsed += new ElapsedEventHandler(Game.MoveCarts);

            // Have the timer fire repeated events (true is the default)
            aTimer.AutoReset = true;

            // Start the timer
            aTimer.Enabled = true;
            PlayGame();
        }

        public void PlayGame()
        {
            Game.SpawnCart();
            GameView gameView = new GameView(Game);
            Game.Start();
            while (Game.IsPlaying)
            {
                gameView.Render();
                char key = Console.ReadKey().KeyChar;
                HandleKeyPress(key.ToString());
            }
        }

        public void HandleKeyPress(string key)
        {
            Random random = new Random();
            int randomInt = random.Next(1, 10);
            if (randomInt == 3)
            {
                // Need to spawn a cart
                //Game.SpawnCart();
            }
            key = key.ToLower();
            List<TrackSwitch> trackSwitches = Game.TrackSwitches;
            trackSwitches = trackSwitches.Where(ts => ts.ListenToCharacter.ToLower().Equals(key)).ToList();

            foreach (var item in trackSwitches)
            {
                item.Switch();
            }
        }
    }
}
