using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RSArcheologyCalculator.Database.Model;

namespace RSArcheologyCalculator.Database.DAL
{
    public class CSVDatabase : IDatabase //for testing, needs public, but otherwise use internal (which is public within project only)
    {
        private List<Artefact> Artefacts = new List<Artefact>();
        private List<Collection> Collections = new List<Collection>();
        private List<Collector> Collectors = new List<Collector>();
        private List<Material> Materials = new List<Material>();
        private List<ArtefactCollectionJoin> ArtefactCollectionJoins = new List<ArtefactCollectionJoin>();
        private List <ArtefactMaterialJoin> ArtefactMaterialJoins = new List<ArtefactMaterialJoin>();

        private void ParseArtefactCSV(string file, bool clear_old_list)
        {
            //Assumes we're generating a fresh list of Artefact... not sure if we actually want to do that though.
            if (clear_old_list) Artefacts = new List<Artefact>();
            
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

        private void ParseArtefactCSV(string file)
        {
            ParseArtefactCSV(file, false);
        }
        
        private void ParseMaterialCSV(string file, bool clear_old_list)
        {
            if (clear_old_list) Materials = new List<Material>();

            string[] lines = File.ReadAllLines(file);
            foreach(string line in lines)
            {
                if (String.IsNullOrEmpty(line))
                {
                    continue;
                }
                string[] elements = line.Split(',');
                Materials.Add(Material.CreateMaterial(elements));
            }
        }

        private void ParseMaterialCSV(string file)
        {
            ParseMaterialCSV(string file, false);
        }

        private void ParseCollectionCSV(string file)
        {
            Collections = new List<Collection>();

            string[] lines = File.ReadAllLines(file);

            foreach(string line in lines)
            {
                if(String.IsNullOrEmpty(line))
                {
                    continue;
                }
                string[] elements = line.Split(',');
                Collections.Add(Collection.CreateCollection(elements));
            }
        }

        private enum MaterialIdx
        {
            Third_Age_iron,
            Samite_silk,
            White_oak,
            Goldrune,
            Orthenglass,
            Vellum,
            Leather_scraps,
            Soapstone,
            Animal_furs,
            Fossilised_bone,
            Zarosian_insignia,
            Imperial_steel,
            Ancient_vis,
            Tyrian_purple,
            Blood_of_Orcus,
            Cadmium_red,
            Chaotic_brimstone,
            Demonhide,
            Eye_of_Dagon,
            Hellfire_metal,
            Keramos,
            White_marble,
            Cobalt_blue,
            Everlight_silvthril,
            Star_of_Saradomin,
            Stormguard_steel,
            Wings_of_War,
            Armadylean_yellow,
            Aetherium_alloy,
            Quintessence,
            Malachite_green,
            Mark_of_the_Kyzaj,
            Vulcanised_rubber,
            Warforged_bronze,
            Yubiusk_clay,
            Compass_rose,
            Felt,
            Dragon_metal,
            Carbon_black,
            Orgone

        }

        private void ParseArtefactMaterialJoinCSV(string file)
        {
            //Todo: Check whether Artefacts list and Materials list is actually populated

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

            string[] DEFAULT_MATERIALS_LIST =
            {
                "Artefact",
                "Third_Age_iron",
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
                "Wings of war",
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
                "Orgone",
                "Extra Material",
                "Quantity"
            };

            string[] MaterialsList = new string[DEFAULT_MATERIALS_LIST.Length];

            Array.Copy(DEFAULT_MATERIALS_LIST, MaterialsList, DEFAULT_MATERIALS_LIST.Length);

            foreach (string line in lines)
            {
                if (String.IsNullOrEmpty(line))
                {
                    continue;
                }
                string[] elements = line.Split(',');

                string Artefact_Name = elements[0];

                if (Artefact_Name.Contains("Artefact")) //Checks first entry in row, if it contains "Artefact", then we know we're defining new set of Materials
                {
                    Array.Copy(elements, MaterialsList, elements.Length);
                    continue;
                }

                /*
                if (MaterialsList.Any("Extra Material".Contains)) //Not sure if just MaterialsList.Contains("Extra Material") would have sufficed.
                //Apparently longer version is (MaterialsList.Any(s => "Extra Material".Contains(s)))
                //https://stackoverflow.com/questions/2912476/using-c-sharp-to-check-if-string-contains-a-string-in-string-array
                {

                }
                //Tried using IndexOf instead, below.
                */


                //This sector deals with any Extra Materials that may be listed within CSV. Also flags index for parser in next sector to skip.
                //Assumes that CSV will only contain one instance of Extra Material and Quantity. Otherwise, create new column entries with Extra Materials listed at top.
                int idxExtraMat = Array.IndexOf(MaterialsList, "Extra Material");
                int idxExtraQuant = Array.IndexOf(MaterialsList, "Quantity");

                if (idxExtraMat != -1 && idxExtraQuant != -1)
                {
                    if (!elements[idxExtraMat].Equals("None"))
                    {
                        if(int.TryParse(elements[idxExtraQuant], out int Quant))
                        {
                            ArtefactMaterialJoin.CreateArtefactMaterialJoin(Artefact_Name, elements[idxExtraMat], Quant, Artefacts, Materials);
                            
                            
                            //Instead of this
                            ArtefactMaterialJoin newArtefactMaterialJoin = new ArtefactMaterialJoin()
                            {
                                Artefact_Name = Artefact_Name,
                                Material_Name = elements[idxExtraMat],
                                Quantity = Quant
                            };
                            ArtefactMaterialJoins.Add(newArtefactMaterialJoin);
                        }
                    }
                }


                for (int i = 1; i<elements.Length; i++) //i starts a 1 to skip the Artefact Name
                {
                    if (i == idxExtraMat || i == idxExtraQuant)
                    {
                        continue;
                        //Skip the Columns for the Extra Material.
                    }
                    bool isMatNumber = int.TryParse(elements[i], out int Quantity);

                    if (isMatNumber)
                    {
                        if (Quantity > 0) //Not sure if C# shortcircuits, so putting this within boolean check just to be safe.
                        {
                            ArtefactMaterialJoin newArtefactMaterialJoin = new ArtefactMaterialJoin()
                            {
                                Artefact_Name = Artefact_Name,
                                Material_Name = MaterialsList[i],
                                Quantity = Quantity
                            };
                            ArtefactMaterialJoins.Add(newArtefactMaterialJoin);
                        }
                    }
                    else
                    {
                        //Something to log this error in data?
                        //ToDo: Add a logging system
                    }
                    
                }


                /* Old version that I might get rid of

                if (elements.Length<43) //Expecting 1 Artefact Name, 40 materials, 1 Extra Material, 1 Extra Material Quantity
                {
                    //Something to catch the formatting error
                }


                //Here, we parse all columns as per the values indicated in the idx key above.
                string ArtefactName = elements[0];

                for (int i = 1; i<elements.Length-2; i++)
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
                        string MaterialName = ((MaterialIdx) (i - 1)).ToString(); //The Materials Name will not match those in the CSV due to enumeration limitations, gotta find a way to fix.

                        ArtefactMaterialJoin new_entry = new ArtefactMaterialJoin()
                        {
                            Artefact_Name = ArtefactName,
                            Material_Name = MaterialName,
                            Quantity = MaterialQuantity
                        };

                        ArtefactMaterialJoins.Add(new_entry);
                    }
                }
                

                ArtefactMaterialJoins.Add(ArtefactMaterialJoin.CreateArtefactMaterialJoin(elements));
                */
            }
        }

        public CSVDatabase(string dir)
        {
            //NtS: Need to create a CSV for each class required by IDatabase.
            ParseArtefactCSV(Path.Combine(dir, "Artefacts.csv"));
            ParseMaterialCSV(Path.Combine(dir, "Materials.csv"));
            ParseArtefactMaterialJoinCSV(Path.Combine(dir, "ArtefactMaterialJoin.csv"));



            /*General process:
             * Create Materials, Artefact, Collection as a base list
             * Create Joins that will add matching Materials and Artefacts references to each other; i.e. it'll modify Materials, Artefact, Collection to include references to the other elements.
             *  todo: modify joins to also have a removal function
             */
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
