using Goudkoorts.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Goudkoorts.Controller;

namespace Goudkoorts
{
    public class Program
    {
        static void Main(string[] args)
        {
            GoudkoortsController controller = new GoudkoortsController();
            controller.Start();
        }
    }
}
