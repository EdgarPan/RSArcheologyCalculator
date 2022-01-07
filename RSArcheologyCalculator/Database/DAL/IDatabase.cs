using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RSArcheologyCalculator.Database.Model;

namespace RSArcheologyCalculator.Database.DAL
{
    internal interface IDatabase
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns>Returns a list of all Artefacts in Database.</returns>
        List<Artefact> GetAllArtefacts();

        /// <summary>
        /// 
        /// </summary>
        /// <returns>Returns a list of all Collections in Database.</returns>
        List<Collection> GetAllCollections();

        /// <summary>
        /// 
        /// </summary>
        /// <returns>Returns a list of all Materials in Database</returns>
        List<Material> GetAllMaterial();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="artefact">The Artefact you want the Materials (and quantity) for.</param>
        /// <returns>Returns a List of the Materials and Quantity required to restore an Artefact.</returns>
        List<ArtefactMaterialJoin> GetMaterials(Artefact artefact);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="collection">The Collection you want the list of Artefacts for.</param>
        /// <returns>Returns a List of Artefacts required to complete a Collection.</returns>
        List<ArtefactCollectionJoin> GetArtefacts(Collection collection);
    }
}
