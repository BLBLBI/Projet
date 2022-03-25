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
            double[] value = new double[t];
            double std = 0d;

            for (int i = 0; i < t; i++)
            {
                value[i] = PercolationValue(size);
            }

            data.Mean = value.Average();

            for (int i = 0; i < t; i++)
            {
                std = Math.Pow(data.Mean - value[i], 2);
            }

            data.StandardDeviation = Math.Sqrt(std/size);

            data.RelativeStd = data.StandardDeviation/data.Mean;

            return data;
        }

        public double PercolationValue(int size)
        {
            Random rnd = new Random();
            Percolation p = new Percolation(size);

            double open = 0d;
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

            return open/(double)(size*size);
        }
    }
}
