using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Goudkoorts.Model
{
    public class Game
    {
        public int Score { get; private set; }
        public List<List<Field>> Map;

        public List<TrackSwitch> TrackSwitches { get; set; }
        public List<Warehouse> WareHouses { get; set; }
        public List<Cart> Carts { get; set; }

        public List<TrackYard> TrackYards { get; set; }

        public TrackDock TrackDock { get; set; }

        public TrackEnd TrackEnd { get; set; }
        public bool IsPlaying { get; set; }
        public Game()
        {
            WareHouses = new List<Warehouse>();
            TrackSwitches = new List<TrackSwitch>();
            Carts = new List<Cart>();
            TrackYards = new List<TrackYard>();

            Map = new List<List<Field>>();
            int index = 0;
            while (index < 12)
            {
                Map.Add(new List<Field>());
                int secondIndex = 0;
                var currentField = Map[index];
                while(secondIndex < 12)
                {
                    currentField.Add(null);
                    secondIndex++;
                }
                index++;
            }
        }

        public void SpawnCart()
        {
            Random random = new Random();
            //int selectedWarehouseIndex = random.Next(0, WareHouses.Count);
            Warehouse SelectedWareHouse = WareHouses[2];
            Track nextWarehouseTrack = SelectedWareHouse.NextTrack;
            if (nextWarehouseTrack.Cart != null)
            {
                return;
            }
            Cart cart = new Cart();
            cart.Track = nextWarehouseTrack;
            nextWarehouseTrack.Cart = cart;
            Carts.Add(cart);
        }

        public void MoveCarts()
        {
            foreach (Cart item in Carts)
            {
                item.Move();
            }
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
            aThirthTrack.IsHorizontal = false;
            aFirst.NextTrack = aSecondTrack;
            aSecondTrack.PreviouseTrack = aFirst;
            aSecondTrack.NextTrack = aThirthTrack;
            aThirthTrack.PreviouseTrack = aSecondTrack;

            // Making track from a to first switch for warehouse B
            Track bFirst = new Track();
            Track bSecondTrack = new Track();
            Track bThirthTrack = new Track();
            bThirthTrack.IsHorizontal = false;
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
            abSwitch.RightTrack = trackBetweenSwitches;
            trackBetweenSwitches.PreviouseTrack = abSwitch;
            aThirthTrack.NextTrack = abSwitch;
            // Making the switch between A and B

            // Making track from warehouse C to first switch
            Track cFirstTrack = new Track();
            whC.NextTrack = cFirstTrack;
            Track cSecondTrack = new Track();
            cFirstTrack.NextTrack = cSecondTrack;
            cSecondTrack.PreviouseTrack = cFirstTrack;
            
            Track cThirthTrack = new Track();
            cSecondTrack.NextTrack = cThirthTrack;
            cThirthTrack.PreviouseTrack = cSecondTrack;
            Track cFourthTrack = new Track();
            cThirthTrack.NextTrack = cFourthTrack;
            cFourthTrack.PreviouseTrack = cThirthTrack;
            Track cFifthTrack = new Track();
            cFourthTrack.NextTrack = cFifthTrack;
            cFifthTrack.PreviouseTrack = cFourthTrack;
            Track cSixthTrack = new Track();
            cSixthTrack.IsHorizontal = false;
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
            cbTwo.IsHorizontal = false;
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
            abcFirst.IsHorizontal = false;
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
            abccRange.UpTrack = abcFith;

            // Track between abbc range k dock
            Track kFirst = new Track();
            abccRange.RightTrack = kFirst;
            kFirst.PreviouseTrack = abcSwitch;
            Track kSecond = new Track();
            kSecond.IsHorizontal = false;
            kFirst.NextTrack = kSecond;
            kSecond.PreviouseTrack = kFirst;
            Track kTirth = new Track();
            kTirth.IsHorizontal = false;
            kSecond.NextTrack = kTirth;
            kTirth.PreviouseTrack = kSecond;
            Track kFourth = new Track();
            kFourth.IsHorizontal = false;
            kTirth.NextTrack = kFourth;
            kFourth.PreviouseTrack = kTirth;
            Track kFith = new Track();
            kFith.IsHorizontal = false;
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
            cRFirst.IsHorizontal = false;
            cRangeSwitch.DownTrack = cRFirst;
            cRFirst.PreviouseTrack = cRangeSwitch;
            Track cRSecond = new Track();
            cRFirst.NextTrack = cRSecond;
            cRSecond.PreviouseTrack = cRFirst;
            Track cRTirth = new Track();
            cRSecond.NextTrack = cRTirth;
            cRTirth.PreviouseTrack = cRSecond;
            Track cRFourth = new Track();
            cRFourth.IsHorizontal = false;
            cRTirth.NextTrack = cRFourth;
            cRFourth.PreviouseTrack = cRTirth;
            Track cRFifth = new Track();
            cRFifth.IsHorizontal = false;
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

            cRangeSwitch.IsInverted = true;
            abcSwitch.IsInverted = true;
            abccRange.IsInverted = false;

            TrackYards.Add(yFirst);
            TrackYards.Add(ySecond);
            TrackYards.Add(yTirth);
            TrackYards.Add(yFourth);
            TrackYards.Add(yFifth);
            TrackYards.Add(ySixth);
            TrackYards.Add(ySeventh);
            TrackYards.Add(yEigth);

            Map[0][1] = yEigth;
            Map[0][2] = ySeventh;
            Map[0][3] = ySixth;
            Map[0][4] = yFifth;
            Map[0][5] = yFourth;
            Map[0][6] = yTirth;
            Map[0][7] = ySecond;
            Map[0][8] = yFirst;
            Map[0][9] = cRSeventh;
            Map[0][10] = cRSixth;
            Map[0][11] = cRFifth;

            Map[1][0] = whC;
            Map[1][1] = cFirstTrack;
            Map[1][2] = cSecondTrack;
            Map[1][3] = cThirthTrack;
            Map[1][4] = cFourthTrack;
            Map[1][5] = cFifthTrack;
            Map[1][6] = cSixthTrack;
            Map[1][7] = null;

            cFourthTrack.Cart = new Cart() { Track = cFourthTrack };

            Map[1][11] = cRFourth;
            Map[1][10] = cRTirth;
            Map[1][9] = cRSecond;
            Map[1][8] = cRFirst;

            Map[2][8] = cRangeSwitch;
            Map[2][7] = ccFirst;
            Map[2][6] = cSwitch;

            Map[3][0] = whB;
            Map[3][1] = bFirst;
            Map[3][2] = bSecondTrack;
            Map[3][3] = bThirthTrack;

            Map[3][5] = cbTwo;
            Map[3][6] = cbOne;
            Map[3][8] = caFirst;
            Map[3][9] = caSecond;

            Map[4][9] = abccRange;
            Map[4][10] = kFirst;
            Map[4][11] = kSecond;
            Map[4][5] = abcSwitch;
            Map[4][4] = trackBetweenSwitches;
            Map[4][3] = abSwitch;

            Map[5][0] = whA;
            Map[5][1] = aFirst;
            Map[5][2] = aSecondTrack;
            Map[5][3] = aThirthTrack;
            Map[5][5] = abcFirst;
            Map[5][6] = abcSecond;
            Map[5][7] = abcTirth;
            Map[5][8] = abcFourth;
            Map[5][9] = abcFith;
            Map[5][11] = kTirth;

            Map[6][11] = kFourth;

            Map[7][11] = kFith;
            Map[7][10] = kSixth;
            Map[7][9] = TrackDock;
            Map[7][8] = EightTrack;
            Map[7][7] = ninthTrack;
            Map[7][6] = tenthTrack;
            Map[7][5] = eleventhTrack;
            Map[7][4] = twelfthTack;
            Map[7][3] = tirtheenthTrach;
            Map[7][2] = fourtheenthTrack;
            Map[7][1] = fiftheenthTrack;
            Map[7][0] = TrackEnd;
            IsPlaying = true;

            foreach (var item in TrackSwitches)
            {
                item.Switch();
            }
        }
    }
}
