using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDamary.CandyCrush
{
    public class CandyMatch
    {
       public  Dictionary<char, List<int>> FindValidClusters(string[] M, int n, int m)
        {
            char[,] grid = new char[n, m];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    grid[i, j] = M[i * m + j][0];
                }
            }

            bool[,] visited = new bool[n, m];
            Dictionary<char, List<int>> clusters = new Dictionary<char, List<int>>();

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (!visited[i, j] && grid[i, j] != 'N') 
                    {
                        List<int> currentCluster = new List<int>();
                        char candyType = grid[i, j];
                        BFS(grid, visited, i, j, candyType, currentCluster, m);

                        if (currentCluster.Count >= 4)
                        {
                            if (!clusters.ContainsKey(candyType))
                            {
                                clusters[candyType] = new List<int>();
                            }
                            clusters[candyType].AddRange(currentCluster);
                        }
                    }
                }
            }

            return clusters;
        }

        static void BFS(char[,] grid, bool[,] visited, int startRow, int startCol, char candyType, List<int> cluster, int m)
        {
            int[] directionsRow = { 0, 1, 0, -1 };
            int[] directionsCol = { 1, 0, -1, 0 };

            Queue<(int, int)> queue = new Queue<(int, int)>();
            queue.Enqueue((startRow, startCol));
            visited[startRow, startCol] = true;

            while (queue.Count > 0)
            {
                (int row, int col) = queue.Dequeue();
                cluster.Add(row * m + col); 

                for (int i = 0; i < 4; i++)
                {
                    int newRow = row + directionsRow[i];
                    int newCol = col + directionsCol[i];

                    if (IsInBounds(newRow, newCol, grid.GetLength(0), grid.GetLength(1)) &&
                        !visited[newRow, newCol] &&
                        grid[newRow, newCol] == candyType)
                    {
                        queue.Enqueue((newRow, newCol));
                        visited[newRow, newCol] = true;
                    }
                }
            }
        }

        static bool IsInBounds(int row, int col, int numRows, int numCols)
        {
            return row >= 0 && row < numRows && col >= 0 && col < numCols;
        }
    }
}
