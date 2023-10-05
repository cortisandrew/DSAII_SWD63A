using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vector_Example
{
    public class DoublingGrowthStrategy : IArrayGrowthStrategy
    {
        public int NewSize(int oldSize)
        {
            return oldSize * 2;
        }
    }
}
