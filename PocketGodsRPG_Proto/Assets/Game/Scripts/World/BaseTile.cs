using UnityEngine;
using System.Collections;

/// <summary>
/// Represents a base tile for the world terrain
/// </summary>
public class BaseTile : MonoBehaviour {

	public const int GRID_X = 0;
	public const int GRID_Y = 1;

	private int gridX;
	private int gridY;

	/// <summary>
	/// Gets the grid. 0 index for X-coord. 1 index for Y-coord
	/// </summary>
	/// <returns>The grid.</returns>
	public int[] GetGrid() {
		int[] grid = new int[2];
		grid[GRID_X] = this.gridX;
		grid[GRID_Y] = this.gridY;

		return grid;
	}

	public int GetGridX() {
		return this.gridX;
	}

	public int GetGridY() {
		return this.gridY;
	}

	/// <summary>
	/// Returns the real world coordinates
	/// </summary>
	/// <returns>The real world coordinates.</returns>
	public Vector3 GetRealWorldCoordinates() {
		return this.transform.localPosition;
	}

	/// <summary>
	/// Sets a new uniform scale for the tile
	/// </summary>
	/// <param name="scale">Scale.</param>
	public void SetTileSize(float scale) {
		Vector3 newScale = new Vector3(scale,scale,1);
		this.transform.localScale = newScale;
	}

	public float GetTileScale() {
		return this.transform.localScale.x;
	}
}
