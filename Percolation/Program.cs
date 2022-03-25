using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Percolation
{
    class Program
    {
        static void Main(string[] args)
        {
            PercolationSimulation p = new PercolationSimulation();
            PclData data = new PclData();

            data = p.MeanPercolationValue(5, 10);

            Console.WriteLine($"mean {data.Mean} std {data.StandardDeviation} rstd {data.RelativeStd}");
        }
    }
}
