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
        private Timer _timer;
        private GameView _gameView;

        public Game Game { get; set; }

        public GoudkoortsController()
        {
            Game = new Game();
            Game.SetupMap();
        }

        public void Start()
        {
            // Start view
            _timer = new System.Timers.Timer();
            _timer.Interval = 2000;

            // Hook up the Elapsed event for the timer.
            //_timer.Elapsed += HandleTimervalTimer;

            // Have the timer fire repeated events (true is the default)
            _timer.AutoReset = true;

            // Start the timer
            PlayGame();
        }

        public void HandleTimervalTimer(object source, ElapsedEventArgs e)
        {
            Game.MoveCarts();
            
            _gameView.Render();
        }

        public void PlayGame()
        {
            Game.SpawnCart();
            _gameView = new GameView(Game);
            _timer.Enabled = true;
            while (Game.IsPlaying)
            {
                char key = Console.ReadKey().KeyChar;
                HandleKeyPress(key.ToString());
                HandleTimervalTimer(null, null);
            }
            _timer.Enabled = false;
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
            _gameView.Render();
        }
    }
}
