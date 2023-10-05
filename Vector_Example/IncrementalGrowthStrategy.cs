using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vector_Example
{
    public class IncrementalGrowthStrategy : IArrayGrowthStrategy
    {
        int growthAmount = 2;
        public IncrementalGrowthStrategy(int growthAmount = 2)
        {
            this.growthAmount = growthAmount;
        }
        public int NewSize(int oldSize)
        {
            return oldSize + growthAmount;
        }
    }
}
