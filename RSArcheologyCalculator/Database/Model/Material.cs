using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSArcheologyCalculator.Database.Model
{
    internal class Material
    {
        public string Name;
        public string Faction;
        public int Level;
        //public int Price; //ToDo: Somehow acquire data automatically from RSGE. Update later.

        public static Material CreateMaterial(string[] fields)
        {
            string Name = fields[0];
            string Faction = fields[1];
            int Level = int.Parse(fields[2]);

            Material material = new Material()
            {
                Name = Name,
                Faction = Faction,
                Level = Level
            };
            return material;
        }
    }
}
