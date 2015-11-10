using UnityEngine;
using System.Collections;

public interface ISkill {

	void Activate();	//when skill has just been selected from UI
	void Deactivate();	//when skill selection has been cancelled

	/// <summary>
	/// Performs the skill on the specified controllable unit
	/// </summary>
	/// <param name="controllableUnit">Controllable unit.</param>
	void Perform(ControllableUnit controllableUnit);

	void Finish();

	string GetSkillName();
}
