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
            StartGameView startGameView = new StartGameView();
            startGameView.Render();
            // Start view
            _timer = new Timer();
            _timer.Interval = 2000;

            // Hook up the Elapsed event for the timer.
            _timer.Elapsed += HandleTimervalTimer;

            // Have the timer fire repeated events (true is the default)
            _timer.AutoReset = true;
            _timer.Enabled = true;
            // Start the timer
            PlayGame();
        }

        public void HandleTimervalTimer(object source, ElapsedEventArgs e)
        {
            try
            {
                Game.MoveCarts();
            }
            catch (Exception)
            {
                Game.IsPlaying = false;
                _timer.Enabled = false;
                ShowEndGameView();
                return;
            }

            Random random = new Random();
            int randomInt = random.Next(1, 5);
            if (randomInt == 3)
            {
                // Need to spawn a cart
                Game.SpawnCart();
            }
            if(randomInt == 5)
            {
                Game.SpawnShip();
            }
            _gameView.Render();
            if (_timer.Interval > 200)
            {
                _timer.Interval *= 0.98;
            }

        }

        public void PlayGame()
        {
            Game.SpawnCart();
            _gameView = new GameView(Game);
            _gameView.Render();

            while (Game.IsPlaying)
            {
                char key = Console.ReadKey().KeyChar;
                HandleKeyPress(key.ToString());
                _gameView.Render();

                Game.MoveCarts();
            }
            _timer.Enabled = false;
        }

        public void ShowEndGameView()
        {
            EndGameView endView = new EndGameView(Game);
            endView.Render();
            Console.ReadLine();
        }

        public void HandleKeyPress(string key)
        {
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
