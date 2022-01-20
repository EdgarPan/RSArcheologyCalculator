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
        Artefact Artefact;
        Material Material;

        /*
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
        */

        public static ArtefactMaterialJoin CreateArtefactMaterialJoin(string Artefact_Name, string Material_Name, int Quantity, List<Artefact> Artefacts, List<Material> Materials)
        {
            //Creates and adds 

            Artefact artefact = Artefact.GetArtefact(Artefact_Name,Artefacts);
            Material material = Material.CreateMaterial(Material_Name, Materials);

            ArtefactMaterialJoin artefactMaterialJoin = new ArtefactMaterialJoin()
            {
                Artefact_Name = Artefact_Name,
                Material_Name = Material_Name,
                Quantity = Quantity,
                Artefact = artefact,
                Material = material
            };

            return CreateArtefactMaterialJoin(artefact, material, Quantity);
        }

        public static ArtefactMaterialJoin CreateArtefactMaterialJoin(Artefact Artefact, Material Material, int Quantity)
        {
            string Artefact_Name = Artefact.Name;
            string Material_Name = Material.Name;
        }
    }
}
