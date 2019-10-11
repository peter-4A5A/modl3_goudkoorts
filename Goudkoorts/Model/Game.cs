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
        public List<Warehouse> WareHouses { get; set; }
        public List<Cart> Carts { get; set; }
        public Game()
        {

        }

        public void SetupMap()
        {
            Warehouse whA = new Warehouse("A");
            Warehouse whB = new Warehouse("B");
            Warehouse whC = new Warehouse("C");
            WareHouses.Add(whA);
            WareHouses.Add(whB);
            WareHouses.Add(whC);

            // Making track from a to first switch for warehouse A
            Track aFirst = new Track();
            Track aSecondTrack = new Track();
            Track aThirthTrack = new Track();
            aFirst.NextTrack = aSecondTrack;
            aSecondTrack.PreviouseTrack = aFirst;
            aSecondTrack.NextTrack = aThirthTrack;
            aThirthTrack.PreviouseTrack = aSecondTrack;

            // Making track from a to first switch for warehouse B
            Track bFirst = new Track();
            Track bSecondTrack = new Track();
            Track bThirthTrack = new Track();
            bFirst.NextTrack = bSecondTrack;
            bSecondTrack.PreviouseTrack = bFirst;
            bSecondTrack.NextTrack = bThirthTrack;
            bThirthTrack.PreviouseTrack = bSecondTrack;

            whA.NextTrack = aFirst;
            whB.NextTrack = bFirst;

            TrackSwitch abSwitch = new TrackSwitch("W");
            TrackSwitches.Add(abSwitch);
            abSwitch.UpTrack = aThirthTrack;
            abSwitch.DownTrack = bThirthTrack;
            Track trackBetwwenSwitches = new Track();
            abSwitch.NextTrack = trackBetwwenSwitches;
            trackBetwwenSwitches.PreviouseTrack = abSwitch;
            // Making the switch between A and B
        }
    }
}
