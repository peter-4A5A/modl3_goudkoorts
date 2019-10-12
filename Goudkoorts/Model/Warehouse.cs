using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goudkoorts.Model
{
    public class Warehouse : Field
    {
        public override string FieldCharacter { get; set; }
        public Track NextTrack { get; set; }

        public Warehouse(string letter)
        {
            FieldCharacter = letter;
        }
    }
}
