﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RSArcheologyCalculator.Database.Model;

namespace RSArcheologyCalculator.Database.DAL
{
    internal class CSVDatabase : IDatabase
    {
        private List<Artefact> Artefacts = new List<Artefact>();
        private List<Collection> Collections = new List<Collection>();
        private List<Collector> Collectors = new List<Collector>();
        private List<Material> Materials = new List<Material>();
        private List<ArtefactCollectionJoin> ArtefactCollectionJoins = new List<ArtefactCollectionJoin>();
        private List <ArtefactMaterialJoin> ArtefactMaterialJoins = new List<ArtefactMaterialJoin>();

        private void ParseArtefactCSV(string file)
        {
            //stupidproofing
            Artefacts = new List<Artefact>();
            
            string[] lines = File.ReadAllLines(file); //Creates an array of the Row values
            foreach(string line in lines)
            {
                if (String.IsNullOrEmpty(line))
                {
                    continue;
                }
                string[] elements = line.Split(',');
                Artefacts.Add(Artefact.CreateArtefact(elements));
            }
        }
        /*
        public enum MaterialIdx
        {
            "Third Age iron",
            "Samite silk",
            "White oak",
            "Goldrune",
            "Orthenglass",
            "Vellum",
            "Leather scraps",
            "Soapstone",
            "Animal furs",
            "Fossilised bone",
            "Zarosian insignia",
            "Imperial steel",
            "Ancient vis",
            "Tyrian purple",
            "Blood of Orcus",
            "Cadmium red",
            "Chaotic brimstone",
            "Demonhide",
            "Eye of Dagon",
            "Hellfire metal",
            "Keramos",
            "White marble",
            "Cobalt blue",
            "Everlight silvthril",
            "Star of Saradomin",
            "Stormguard steel",
            "Wings of War",
            "Armadylean yellow",
            "Aetherium alloy",
            "Quintessence",
            "Malachite green",
            "Mark of the Kyzaj",
            "Vulcanised rubber",
            "Warforged bronze",
            "Yu'biusk clay",
            "Compass rose",
            "Felt",
            "Dragon metal",
            "Carbon black",
            "Orgone"

        }*/

        private void ParseArtefactMaterialJoinCSV(string file)
        {
            /*
             * Idx Key //Create enumeration
             * [0] Artefact Name
             * [1] Third Age iron
             * [2] Samite silk
             * [3] White oak
             * [4] Goldrune
             * [5] Orthenglass
             * [6] Vellum
             * [7] Leather scraps
             * [8] Soapstone
             * [9] Animal furs
             * [10] Fossilised bone
             * [11] Zarosian insignia
             * [12] Imperial steel
             * [13] Ancient vis
             * [14] Tyrian purple
             * [15] Blood of Orcus
             * [16] Cadmium red
             * [17] Chaotic brimstone
             * [18] Demonhide
             * [19] Eye of Dagon
             * [20] Hellfire metal
             * [21] Keramos
             * [22] White marble
             * [23] Cobalt blue
             * [24] Everlight silvthril
             * [25] Star of Saradomin
             * [26] Stormguard steel
             * [27] Wings of War
             * [28] Armadylean yellow
             * [29] Aetherium alloy
             * [30] Quintessence
             * [31] Malachite green
             * [32] Mark of the Kyzaj
             * [33] Vulcanised rubber
             * [34] Warforged bronze
             * [35] Yu'biusk clay
             * [36] Compass rose
             * [37] Felt
             * [38] Dragon metal
             * [39] Carbon black
             * [40] Orgone
             * [41] Extra Material
             * [42] Extra Material Quantity
            */
            string[] lines = File.ReadAllLines(file);

            foreach (string line in lines)
            {
                if (String.IsNullOrEmpty(line))
                {
                    continue;
                }
                string[] elements = line.Split(',');

                if (elements.Length<43) //Expecting 1 Artefact Name, 40 materials, 1 Extra Material, 1 Extra Material Quantity
                {
                    //Something to catch the formatting error
                }


                //Here, we parse all columns as per the values indicated in the idx key above.
                string ArtefactName = elements[0];

                for (int i = 1; i<elements.Length; i++)
                {
                    if (String.IsNullOrEmpty(elements[i]))
                    {
                        continue;
                    }
                    if (int.Parse(elements[i]) > 0)
                    {
                        //Something to make the i value (which would be the column in the CSV) correspond to the Material string. Enumeration?
                        //whatever value that has been parsed will be the Material Quantity.
                        int MaterialQuantity = int.Parse(elements[i]);
                    }
                }
                
                foreach (string element in elements)
                {
                    if (String.IsNullOrEmpty(element)) continue;
                    if (int.Parse(element) == 0) continue;

                }

                ArtefactMaterialJoins.Add(ArtefactMaterialJoin.CreateArtefactMaterialJoin(elements));
            }
        }

        public CSVDatabase(string dir)
        {
            //NtS: Need to create a CSV for each class required by IDatabase.
            ParseArtefactCSV(Path.Combine(dir, "Artefacts.csv"));
        }


        public List<Artefact> GetAllArtefacts()
        {
            return Artefacts;
        }

        public List<Collection> GetAllCollections()
        {
            return Collections;
        }

        public List<Material> GetAllMaterial()
        {
            return Materials;
        }

        public List<ArtefactCollectionJoin> GetArtefacts(Collection collection)
        {
            throw new NotImplementedException();
        }

        public List<ArtefactMaterialJoin> GetMaterials(Artefact artefact)
        {
            throw new NotImplementedException();
        }
    }
}
