using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSArcheologyCalculator.Database.Model
{
    internal class ArtefactCollectionJoin //Many-to-Many
    {
        //public Artefact Artefact;
        //public Collection Collection;

        public string Artefact_Name;
        public string Collection_Name;

        public static ArtefactCollectionJoin CreateArtefactCollectionJoin(string [] fields, Artefact artefact)
        {
            string Artefact_Name = fields[0];
            string Collection_Name = fields[1];

            ArtefactCollectionJoin artefactCollectionJoin = new ArtefactCollectionJoin()
            {
                Artefact_Name = Artefact_Name,
                Collection_Name = Collection_Name
            };
        }
    }
}
