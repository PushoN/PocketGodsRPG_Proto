using UnityEngine;
using System.Collections;

public class BattleSystemHandler : MonoBehaviour {

	private static BattleSystemHandler sharedInstance = null;
	public static BattleSystemHandler Instance {
		get {
			return sharedInstance;
		}
	}
	

	// Use this for initialization
	void Start () {
		
	}
}
