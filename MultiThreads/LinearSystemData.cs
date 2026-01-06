using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiThreads
{
    public class LinearSystemData
    {
        public double[][] A { get; set; } 
        public double[] B { get; set; }    
        public double Epsilon { get; set; } 
        public int MaxIterations { get; set; }
    }
}
