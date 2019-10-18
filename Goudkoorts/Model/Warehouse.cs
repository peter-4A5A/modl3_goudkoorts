using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goudkoorts.Model
{
    public class Warehouse : Track
    {
        public override string FieldCharacter { get; set; }

        public Warehouse(string letter)
        {
            FieldCharacter = letter;
        }
    }
}
