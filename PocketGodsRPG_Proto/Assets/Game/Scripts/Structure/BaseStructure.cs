using UnityEngine;
using System.Collections;

/// <summary>
/// Refers to the base structure of the game
/// </summary>
public class BaseStructure : MonoBehaviour {

	[SerializeField] private int tileSizeX = 0; //how many tiles does this structure occupy?
	[SerializeField] private int tileSizeY = 0;

	// Use this for initialization
	void Start () {
	
	}

	public int[] GetTileSize() {
		int[] tileCount = new int[2];
		tileCount[BaseTile.GRID_X] = tileSizeX;
		tileCount[BaseTile.GRID_Y] = tileSizeY;

		return tileCount;
	}
	
}
