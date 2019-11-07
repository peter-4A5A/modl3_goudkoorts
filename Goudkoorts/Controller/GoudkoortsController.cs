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
        private bool _blockSwitchMovement;
        private Random _random;
        public Game Game { get; set; }

        public GoudkoortsController()
        {
            _blockSwitchMovement = false;
            Game = new Game();
            Game.SetupMap();
            _random = new Random();
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
            _blockSwitchMovement = true;
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

            
            int randomInt = _random.Next(1, 5);
            if (randomInt == 2)
            {
                // Need to spawn a cart
                Game.SpawnCart();
            }
            if(randomInt == 3)
            {
                Game.SpawnShip();
            }
            _gameView.Render();
            if (_timer.Interval > 200)
            {
                _timer.Interval *= 0.98;
            }
            _blockSwitchMovement = false;
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
            if (_blockSwitchMovement)
            {
                return;
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
