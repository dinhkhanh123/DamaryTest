using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DragonHatch : MonoBehaviour
{
    void Start()
    {
      
        int[,] matrix = new int[5, 5];
        int counter = 0;
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                matrix[i, j] = counter++;
            }
        }

        
        string[] clusters = { "X;6,7,11,12,16", "D;13,14,18,23" };

        
        List<int> middleValues = new List<int>();

        foreach (string cluster in clusters)
        {
            string[] parts = cluster.Split(';');
            if (parts.Length != 2)
            {
                Debug.Log("Invalid format: " + cluster);
                continue;
            }

            string[] indices = parts[1].Split(',');
            List<int> sortedIndices = SortIndicesByMatrixOrder(matrix, indices);

          
            int middleValue = GetMiddleValue(sortedIndices);
            middleValues.Add(middleValue);
        }

        
        Debug.Log("Output: [" + string.Join(", ", middleValues) + "]");
    }

    public List<int> SortIndicesByMatrixOrder(int[,] matrix, string[] indices)
    {
       
        List<(int index, int row, int col)> coordinates = indices
            .Select(index => int.Parse(index))
            .Select(idx => (idx, row: idx / matrix.GetLength(1), col: idx % matrix.GetLength(1)))
            .ToList();

       
        var sortedCoordinates = coordinates
            .OrderBy(coord => coord.col)  
            .ThenBy(coord => coord.row)   
            .ToList();

        
        return sortedCoordinates.Select(coord => coord.index).ToList();
    }

    public int GetMiddleValue(List<int> sortedIndices)
    {
        int count = sortedIndices.Count;
        if (count == 0)
        {
            throw new System.InvalidOperationException("The list is empty, cannot determine the middle value.");
        }

        
        int middleIndex = count / 2;
        return sortedIndices[middleIndex];
    }
}