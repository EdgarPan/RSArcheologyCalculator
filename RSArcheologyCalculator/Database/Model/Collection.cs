using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSArcheologyCalculator.Database.Model
{
    internal class Collection
    {
        public string Name;
        public Collector Collector; //NPC
        public int Chronotes; //Rewarded for Completion of Collection
        public string FirstTimeReward;
        public string RepeatReward;
    }
}
