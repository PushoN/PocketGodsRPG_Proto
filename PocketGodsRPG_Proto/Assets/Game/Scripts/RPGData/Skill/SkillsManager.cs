using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Repository of all skills that is loaded for the current game. Each skill has an owner.
/// 
/// By: NeilDG
/// </summary>
public class SkillsManager {
	private static SkillsManager sharedInstance = null;

	public static SkillsManager Instance {
		get {
			return sharedInstance;
		}
	}

	private Dictionary<UnitIdentity, Dictionary<string, ISkill>> skillSetTable = new Dictionary<UnitIdentity, Dictionary<string,ISkill>>();

	private SkillsManager() {

	}

	public static void Initialize() {
		sharedInstance = new SkillsManager();
	}

	public static void Destroy() {
		sharedInstance = null;
	}

	public void AddSkill(UnitIdentity owner, string skillUniqueName, ISkill skill) {
		if(this.skillSetTable.ContainsKey(owner)) {
			this.skillSetTable[owner].Add(skillUniqueName, skill);
		}
		else {
			Dictionary<string, ISkill> unitSkillTable = new Dictionary<string, ISkill>();
			unitSkillTable.Add(skillUniqueName, skill);

			this.skillSetTable.Add(owner, unitSkillTable);
		}
	}

	public ISkill GetSkill(UnitIdentity owner, string skillUniqueName) {
		if(this.skillSetTable.ContainsKey(owner)) {
			Dictionary<string, ISkill> unitSkillSet = this.skillSetTable[owner];

			if(unitSkillSet.ContainsKey(skillUniqueName)) {
				return unitSkillSet[skillUniqueName];
			}
			else {
				Debug.LogError(skillUniqueName + " was not found.");
				return null;
			}
		}
		else {
			Debug.LogError(owner + " was not found in the skills manager. Do they exist?");
			return null;
		}
	}
}
