using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CandyMatch : MonoBehaviour
{
    private string[] candyMatrix = new string[]
     {
        "X", "T", "D", "L", "N",
        "L", "X", "X", "C", "X",
        "D", "X", "X", "D", "D",
        "T", "X", "T", "D", "L",
        "L", "C", "L", "D", "L"
     };

   
    public const int rows = 5; 
    public const int columns = 5; 

    void Start()
    {
        if (candyMatrix.Length != rows * columns)
        {
            return;
        }

        Dictionary<char, List<int>> validClusters = FindValidClusters(candyMatrix, rows, columns);

        if (validClusters.Count == 0)
        {
            Debug.Log("Null");
        }
        else
        {
            foreach (var pair in validClusters)
            {
                Debug.Log($"Candy type '{pair.Key}' has {pair.Value.Count} elements: {string.Join(",", pair.Value)}");
            }
        }
    }

    Dictionary<char, List<int>> FindValidClusters(string[] M, int n, int m)
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
                if (!visited[i, j] && grid[i, j] != 'N') // Skip 'N' and not visited
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

    void BFS(char[,] grid, bool[,] visited, int startRow, int startCol, char candyType, List<int> cluster, int m)
    {
        int[] directionsRow = { 0, 1, 0, -1 }; // Move right, down, left, up
        int[] directionsCol = { 1, 0, -1, 0 };

        Queue<(int, int)> queue = new Queue<(int, int)>();
        queue.Enqueue((startRow, startCol));
        visited[startRow, startCol] = true;

        while (queue.Count > 0)
        {
            (int row, int col) = queue.Dequeue();
            cluster.Add(row * m + col); // Add index to cluster

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

    bool IsInBounds(int row, int col, int numRows, int numCols)
    {
        return row >= 0 && row < numRows && col >= 0 && col < numCols;
    }
}
