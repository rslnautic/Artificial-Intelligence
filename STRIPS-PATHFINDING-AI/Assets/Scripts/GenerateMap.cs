using System;
using UnityEngine;
using System.Collections;

public class GenerateMap {

    
    public int rows;
    public int cols;
    public TileType[,] GeneratedMap { get; set; }

    public GameObject BoardGameObject { get; set; }

    [Serializable]
    public enum TileType
    {
        Empty, Wall, Goal, Item
    }
	// Use this for initialization
	public GenerateMap (int rows, int cols, BoardManager board)
	{
	    this.rows = rows;
	    this.cols = cols;
        GeneratedMap = new TileType[cols,rows];

	    for (int r = 0; r < rows; r++)
	    {
	        for (int c = 0; c < cols; c++)
	        {
	            if (board.GridObjects[c, r] == null)
	            {
                    GeneratedMap[c, r] = TileType.Empty;
                }
	            else
	            {
	                
	            
	                if (board.GridObjects[c, r].CompareTag("Goal"))
	                {
	                    GeneratedMap[c,r]=TileType.Goal;
	                }
                    if (board.GridObjects[c, r].CompareTag("Wall"))
                    {
                        GeneratedMap[c, r] = TileType.Wall;
                    }
                    if (board.GridObjects[c, r].CompareTag("Item"))
                    {
                        GeneratedMap[c, r] = TileType.Item;
                    }
                    
                }


            }
        }

        
        
	}
	
    public TileType GetTile(int row, int col)
    {
        if (row > rows || row < 0)
        {
            throw new Exception("Row index out of bound");
        }
        if (col > cols || col < 0)
        {
            throw new Exception("Col index out of bound");
        }

        return GeneratedMap[col, row];
    } 


}
