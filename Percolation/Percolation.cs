using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Percolation
{
    public class Percolation
    {
        private readonly bool[,] _open;
        private readonly bool[,] _full;
        private readonly int _size;
        private bool _percolate;

        public Percolation(int size)
        {
            if (size <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(size), size, "Taille de la grille négative ou nulle.");
            }

            _open = new bool[size, size];
            _full = new bool[size, size];
            _size = size;
        }

        private bool IsOpen(int i, int j)
        {
            return _open[i,j];
        }

        private bool IsFull(int i, int j)
        {
            return IsOpen(i, j) ? _full[i,j] : false;
        }

        internal bool Percolate()
        {
            for (int i = 0; i < _size; i++)
            {
                if (IsFull(_size - 1, i))
                    return true;
            }

            return false;
        }

        private List<KeyValuePair<int, int>> CloseNeighbors(int i, int j)
        {
            List<KeyValuePair<int, int>> neighbors = new List<KeyValuePair<int, int>>();

            if (i > 0) 
            {
                neighbors.Add(new KeyValuePair<int, int>(i-1, j));
            }

            if (i < _size-1)
            {
                neighbors.Add(new KeyValuePair<int, int>(i+1, j));
            }

            if (j > 0) 
            {
                neighbors.Add(new KeyValuePair<int, int>(i, j-1));
            }

            if (j < _size-1)
            {
                neighbors.Add(new KeyValuePair<int, int>(i, j+1));
            }

            return neighbors;
        }

        internal void Open(int i, int j)
        {
            List<KeyValuePair<int, int>> neighbors = CloseNeighbors(i, j);

            if (!IsOpen(i, j))
            {
                _open[i, j] = true;

                if (i == 0)
                    _full[i, j] = true;
                else
                {
                    foreach (var neighbor in neighbors)
                    {
                        if (IsFull(neighbor.Key, neighbor.Value))
                        {
                            _full[i, j] = true;
                            break;
                        }
                    }
                }
            }

            if (IsFull(i, j))
            {
                foreach (var neighbor in neighbors) 
                {
                    if (IsOpen(neighbor.Key, neighbor.Value) && !IsFull(neighbor.Key, neighbor.Value)) 
                    {
                        Open(neighbor.Key, neighbor.Value);
                    }
                }
            }
        }
    }
}
