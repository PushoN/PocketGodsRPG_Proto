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

	void Awake() {

	}

	// Use this for initialization
	void Start () {
		BuilderSetupHandler.RegisterEventReceiver(BuilderSetupHandler.BuilderStateType.SETUP_TILE, this.SetupWorldWithPlaceholderTileset);
	}

	private void SetupWorldWithPlaceholderTileset() {

	}
}
