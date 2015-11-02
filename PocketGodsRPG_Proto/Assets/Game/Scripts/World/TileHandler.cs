using UnityEngine;
using System.Collections;

public class TileHandler : MonoBehaviour {

	private static TileHandler sharedInstance = null;
	public static TileHandler Instance {
		get {
			return sharedInstance;
		}
	}

	[SerializeField] private BaseTile[] tilePrefabList;

	private BaseTile[,] tileData;
	private Vector3 origin = Vector3.zero;

	void Awake() {
		sharedInstance = this;
	}

	// Use this for initialization
	void Start () {
		BuilderSetupHandler.RegisterEventReceiver(BuilderSetupHandler.BuilderStateType.SETUP_TILE, this.SetupWorldWithPlaceholderTileset);

		this.tileData = new BaseTile[GameConstants.TILE_COUNT_X, GameConstants.TILE_COUNT_Y];
	}

	/// <summary>
	/// Setups the world with placeholder tileset using a top-down approach. Anchor is upper-left.
	/// </summary>
	private void SetupWorldWithPlaceholderTileset() {

		int posX = 0;
		int posZ = 0;

		for(int col = 0; col < GameConstants.TILE_COUNT_Y; col++) {

			for(int row = 0; row < GameConstants.TILE_COUNT_X; row++) {
				//randomize tile selection
				BaseTile baseTile = GameObject.Instantiate(this.tilePrefabList[Random.Range(0, this.tilePrefabList.Length)]) as BaseTile;
				baseTile.transform.SetParent(this.transform);

				Vector3 tilePos = origin;
				tilePos.x += posX;
				tilePos.z += posZ;

				baseTile.transform.localPosition = tilePos;
				baseTile.gameObject.name = "Tile["+row+"]["+col+"]";

				posX += GameConstants.REAL_TILE_SIZE_X;
			}

			posX = 0;
			posZ -= GameConstants.REAL_TILE_SIZE_Y;
		}

		BuilderSetupHandler.Instance.SetState(BuilderSetupHandler.BuilderStateType.SETUP_STRUCTURE);
	}
}
