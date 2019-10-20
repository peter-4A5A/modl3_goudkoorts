using Goudkoorts.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goudkoorts.View
{
    public class StartGameView : IView
    {
        public void Render()
        {
            Console.Clear();
            Console.WriteLine("+---------------------------------------+");
            Console.WriteLine("|  Welkom bij Goudkoorts                |");
            Console.WriteLine("|                                       |");
            Console.WriteLine("|  Gebruiksaanwijzingen                 |");
            Console.WriteLine("|  Je kan een wissel verwisselen        |");
            Console.WriteLine("|  Dit gaat met verschillende characters|");
            Console.WriteLine("|  Namelijk die je ziet in het voorbeeld|");
            Console.WriteLine("|  De warehouses zijn: A,B en C         |");
            Console.WriteLine("|  De wissels zijn te bedienen me:      |");
            Console.WriteLine("|  W, R, E, T, Q                        |");
            Console.WriteLine("|  De x is het einde                    |");
            Console.WriteLine("|  k is het dock en een S staat         |");
            Console.WriteLine("|  Voor het schip                       |");
            Console.WriteLine("|  De map ziet er als het volgende uit  |");
            Console.WriteLine("x--------k-|");
            Console.WriteLine("           |");
            Console.WriteLine("A--| |---- |");
            Console.WriteLine("   W-R   Q-|");
            Console.WriteLine("B--| |- --  ");
            Console.WriteLine("      E-T   ");
            Console.WriteLine("C-----| |--|");
            Console.WriteLine(" ________--|");
            Console.ReadKey();
        }
    }
}
