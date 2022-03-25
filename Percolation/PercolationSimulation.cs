using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Percolation
{
    public struct PclData
    {
        /// <summary>
        /// Moyenne 
        /// </summary>
        public double Mean { get; set; }
        /// <summary>
        /// Ecart-type
        /// </summary>
        public double StandardDeviation { get; set; }

        public double RelativeStd { get; set; }
    }

    public class PercolationSimulation
    {
        public PclData MeanPercolationValue(int size, int t)
        {
            PclData data = new PclData();



            return data;
        }

        public double PercolationValue(int size)
        {
            Random rnd = new Random();
            Percolation p = new Percolation(size);

            int open = 0;
            int x, y;

            while (!p.Percolate()) 
            {
                x = rnd.Next(0, size);
                y = rnd.Next(0, size);

                if (!p.IsOpen(x, y))
                {
                    p.Open(x, y);
                    open++;
                }
            }

            return open/(size*size);
        }
    }
}
