using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSArcheologyCalculator.Database.Model
{
    internal class ArtefactCollectionJoin //Many-to-Many
    {
        public Artefact Artefact;
        public Collection Collection;
    }
}
