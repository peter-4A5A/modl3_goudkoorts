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
            Track trackBetweenSwitches = new Track();
            abSwitch.NextTrack = trackBetweenSwitches;
            trackBetweenSwitches.PreviouseTrack = abSwitch;
            // Making the switch between A and B

            // Making track from warehouse C to first switch
            Track cFirstTrack = new Track();
            whC.NextTrack = cFirstTrack;
            Track cSecondTrack = new Track();
            cFirstTrack.NextTrack = cSecondTrack;
            cSecondTrack.PreviouseTrack = cFirstTrack;
            Track cThirthTrack = new Track();
            cThirthTrack.PreviouseTrack = cSecondTrack;
            Track cFourthTrack = new Track();
            cThirthTrack.NextTrack = cFourthTrack;
            cFourthTrack.PreviouseTrack = cThirthTrack;
            Track cFifthTrack = new Track();
            cFourthTrack.NextTrack = cFifthTrack;
            cFifthTrack.PreviouseTrack = cFourthTrack;
            Track cSixthTrack = new Track();
            cFifthTrack.NextTrack = cSixthTrack;
            cSixthTrack.PreviouseTrack = cFifthTrack;

            TrackSwitch cSwitch = new TrackSwitch("E");
            TrackSwitches.Add(cSwitch);
            cSixthTrack.NextTrack = cSwitch;
            cSwitch.DownTrack = cSixthTrack;

            // Making track ab switch and C switch
            TrackSwitch abcSwitch = new TrackSwitch("R");
            TrackSwitches.Add(abcSwitch);
            trackBetweenSwitches.NextTrack = abcSwitch;
            abcSwitch.LeftTrack = trackBetweenSwitches;

            Track cbOne = new Track();
            cbOne.PreviouseTrack = cSwitch;
            cSwitch.UpTrack = cbOne;

            Track cbTwo = new Track();
            cbOne.NextTrack = cbTwo;
            cbTwo.PreviouseTrack = cbOne;
            cbTwo.NextTrack = abcSwitch;
            abcSwitch.DownTrack = cbTwo;

            // Track between cSwitch and cRange
            Track ccFirst = new Track();
            ccFirst.PreviouseTrack = cSwitch;
            cSwitch.RightTrack = ccFirst;
            TrackSwitch cRangeSwitch = new TrackSwitch("T");
            TrackSwitches.Add(cRangeSwitch);
            cRangeSwitch.LeftTrack = ccFirst;
            ccFirst.NextTrack = cRangeSwitch;

        }
    }
}
