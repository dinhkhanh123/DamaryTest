using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDamary.DragonHatch
{
    public class DragonHatch
    {
        public int[] GetSortedIndices(int[,] matrix, int[] indices)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

          
            var indexedPositions = indices.Select(index => new
            {
                Index = index,
                Row = index / cols,
                Col = index % cols
            }).ToList();

         
            var sortedIndexedPositions = indexedPositions
                .OrderBy(p => p.Col)  
                .ThenBy(p => p.Row)   
                .ToList();

          
            return sortedIndexedPositions.Select(p => p.Index).ToArray();
        }


       public int GetMiddleIndex(int[] sortedIndices)
        {
            int length = sortedIndices.Length;

            int midIndex = length / 2;

            return sortedIndices[midIndex];
        }
    }
}
