using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goudkoorts.Model
{
    class Game
    {
        public int Score { get; private set; }
        public List<List<Field>> Map;
        public List<TrackSwitch> TrackSwitches { get; set; }
        public Game()
        {

        }
    }
}
