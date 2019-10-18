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
        }
    }
}
