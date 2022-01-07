using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSArcheologyCalculator.Database.Model
{
    internal class ArtefactMaterialJoin //Many-to-Many
    {
        public string Artefact_Name;
        public string Material_Name;
        public int Quantity;

        public static ArtefactMaterialJoin CreateArtefactMaterialJoin(string[] fields)
        {
            string Artefact_Name = fields[0];
            string Material_Name = fields[1];
            int Quantity = int.Parse(fields[2]);

            ArtefactMaterialJoin artefactmaterialjoin = new ArtefactMaterialJoin()
            {
                Artefact_Name = Artefact_Name,
                Material_Name = Material_Name,
                Quantity = Quantity
            };
            return artefactmaterialjoin;
        }

    }
}
