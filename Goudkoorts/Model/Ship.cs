using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goudkoorts.Model
{
    public class Ship
    {
        public int NumberOfDumps { get; set; }

        private Track _track;

        public Track Track
        {
            get
            {
                return _track;
            }
            set
            {
                _track = value;
                if (_track != null)
                {
                    _track.FieldCharacter = "S";
                }
            }
        }
    }
}
