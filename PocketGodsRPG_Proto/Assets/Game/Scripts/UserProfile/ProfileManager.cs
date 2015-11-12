using UnityEngine;
using System.Collections;

/// <summary>
/// Represents the manager for list of profiles available
/// </summary>
public class ProfileManager : MonoBehaviour {

	private static ProfileManager sharedInstance = null;
	public ProfileManager Instance {
		get {
			if(sharedInstance == null) {
				sharedInstance = new ProfileManager();
			}
		}
	}

	private ProfileManager() {

	}
}
