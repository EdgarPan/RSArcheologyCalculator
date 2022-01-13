using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSArcheologyCalculator.Database.Model
{
    internal class Collection
    {
        public string Collection_Name;
        //public Collector Collector; //NPC
        public string Collector;
        public int Chronotes; //Rewarded for Completion of Collection
        public string FirstTimeReward;
        public string RepeatReward;

        public static Collection CreateCollection(string [] fields)
        {
            string Collection_Name = fields[0];
            string Collector = fields[1];
            int.TryParse(fields[2], out int Chronotes);
            string FirstTimeReward = fields[3];
            string RepeatReward = fields[4];

            Collection collection = new Collection()
            {
                Collection_Name = Collection_Name,
                Collector = Collector,
                Chronotes = Chronotes,
                FirstTimeReward = FirstTimeReward,
                RepeatReward = RepeatReward
            };

            return collection;
        }
        public static Collection CreateCollection(string Collection_Name, string Collector, int Chronotes, string FirstTimeReward, string RepeatReward)
        {

            Collection collection = new Collection()
            {
                Collection_Name = Collection_Name,
                Collector = Collector,
                Chronotes = Chronotes,
                FirstTimeReward = FirstTimeReward,
                RepeatReward = RepeatReward
            };

            return collection;
        }
    }
}
