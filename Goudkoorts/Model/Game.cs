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

        public List<TrackYard> TrackYards { get; set; }

        public TrackDock TrackDock { get; set; }

        public TrackEnd TrackEnd { get; set; }
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

            // Track between cRange and abccRange
            Track caFirst = new Track();
            cRangeSwitch.UpTrack = caFirst;
            caFirst.PreviouseTrack = cRangeSwitch;
            Track caSecond = new Track();
            caFirst.NextTrack = caSecond;
            caSecond.PreviouseTrack = caFirst;
            TrackSwitch abccRange = new TrackSwitch("Q");
            TrackSwitches.Add(abccRange);
            abccRange.DownTrack = caSecond;
            caSecond.NextTrack = abccRange;

            // Track between abc switch and abccRange
            Track abcFirst = new Track();
            abcSwitch.UpTrack = abcFirst;
            abcFirst.PreviouseTrack = abcSwitch;
            Track abcSecond = new Track();
            abcFirst.NextTrack = abcSecond;
            abcSecond.PreviouseTrack = abcFirst;
            Track abcTirth = new Track();
            abcSecond.NextTrack = abcTirth;
            abcTirth.PreviouseTrack = abcSecond;
            Track abcFourth = new Track();
            abcTirth.NextTrack = abcFourth;
            abcFourth.PreviouseTrack = abcTirth;
            Track abcFith = new Track();
            abcFourth.NextTrack = abcFith;
            abcFith.PreviouseTrack = abcFourth;
            abcFith.NextTrack = abccRange;
            abccRange.UpTrack = abccRange;

            // Track between abbc range k dock
            Track kFirst = new Track();
            abcSwitch.RightTrack = kFirst;
            kFirst.PreviouseTrack = abcSwitch;
            Track kSecond = new Track();
            kFirst.NextTrack = kSecond;
            kSecond.PreviouseTrack = kFirst;
            Track kTirth = new Track();
            kSecond.NextTrack = kTirth;
            kTirth.PreviouseTrack = kSecond;
            Track kFourth = new Track();
            kTirth.NextTrack = kFourth;
            kFourth.PreviouseTrack = kTirth;
            Track kFith = new Track();
            kFourth.NextTrack = kFith;
            kFith.PreviouseTrack = kFourth;
            Track kSixth = new Track();
            kFith.NextTrack = kSixth;
            kSixth.PreviouseTrack = kFith;
            TrackDock = new TrackDock();
            kSixth.NextTrack = TrackDock;
            TrackDock.PreviouseTrack = kSixth;
            Track EightTrack = new Track();
            TrackDock.NextTrack = EightTrack;
            EightTrack.PreviouseTrack = TrackDock;
            Track ninthTrack = new Track();
            EightTrack.NextTrack = ninthTrack;
            ninthTrack.PreviouseTrack = EightTrack;
            Track tenthTrack = new Track();
            ninthTrack.NextTrack = tenthTrack;
            tenthTrack.PreviouseTrack = ninthTrack;
            Track eleventhTrack = new Track();
            tenthTrack.NextTrack = eleventhTrack;
            eleventhTrack.PreviouseTrack = tenthTrack;
            Track twelfthTack = new Track();
            eleventhTrack.NextTrack = twelfthTack;
            twelfthTack.PreviouseTrack = eleventhTrack;
            Track tirtheenthTrach = new Track();
            twelfthTack.NextTrack = tirtheenthTrach;
            tirtheenthTrach.PreviouseTrack = twelfthTack;
            Track fourtheenthTrack = new Track();
            tirtheenthTrach.NextTrack = fourtheenthTrack;
            fourtheenthTrack.PreviouseTrack = tirtheenthTrach;
            Track fiftheenthTrack = new Track();
            fourtheenthTrack.NextTrack = fiftheenthTrack;
            fiftheenthTrack.PreviouseTrack = fourtheenthTrack;

            TrackEnd = new TrackEnd();
            fiftheenthTrack.NextTrack = TrackEnd;
            TrackEnd.PreviouseTrack = fiftheenthTrack;

            // Track between ccRange switch and before the range
            Track cRFirst = new Track();
            cRangeSwitch.RightTrack = cRFirst;
            cRFirst.PreviouseTrack = cRangeSwitch;
            Track cRSecond = new Track();
            cRFirst.NextTrack = cRSecond;
            cRSecond.PreviouseTrack = cRFirst;
            Track cRTirth = new Track();
            cRSecond.NextTrack = cRTirth;
            cRTirth.PreviouseTrack = cRSecond;
            Track cRFourth = new Track();
            cRTirth.NextTrack = cRFourth;
            cRFourth.PreviouseTrack = cRTirth;
            Track cRFifth = new Track();
            cRFourth.NextTrack = cRFifth;
            cRFifth.PreviouseTrack = cRFourth;
            Track cRSixth = new Track();
            cRFifth.NextTrack = cRSixth;
            cRSixth.PreviouseTrack = cRFifth;
            Track cRSeventh = new Track();
            cRSixth.NextTrack = cRSeventh;
            cRSeventh.PreviouseTrack = cRSixth;

            // The range from right to left
            TrackYard yFirst = new TrackYard();
            cRSeventh.NextTrack = yFirst;
            yFirst.PreviouseTrack = yFirst;
            TrackYard ySecond = new TrackYard();
            yFirst.NextTrack = ySecond;
            ySecond.PreviouseTrack = yFirst;
            TrackYard yTirth = new TrackYard();
            ySecond.NextTrack = yTirth;
            yTirth.PreviouseTrack = ySecond;
            TrackYard yFourth = new TrackYard();
            yTirth.NextTrack = yFourth;
            yFourth.PreviouseTrack = yTirth;
            TrackYard yFifth = new TrackYard();
            yFourth.NextTrack = yFifth;
            yFifth.PreviouseTrack = yFourth;
            TrackYard ySixth = new TrackYard();
            yFifth.NextTrack = ySixth;
            ySixth.PreviouseTrack = yFifth;
            TrackYard ySeventh = new TrackYard();
            ySixth.NextTrack = ySeventh;
            ySeventh.PreviouseTrack = ySixth;
            TrackYard yEigth = new TrackYard();
            ySeventh.NextTrack = yEigth;
            yEigth.PreviouseTrack = ySeventh;

            TrackYards.Add(yFirst);
            TrackYards.Add(ySecond);
            TrackYards.Add(yTirth);
            TrackYards.Add(yFourth);
            TrackYards.Add(yFifth);
            TrackYards.Add(ySixth);
            TrackYards.Add(ySeventh);
            TrackYards.Add(yEigth);
        }
    }
}
