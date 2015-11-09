using UnityEngine;
using System.Collections;

public interface ISkill {

	/// <summary>
	/// Performs the skill on the specified controllable unit
	/// </summary>
	/// <param name="controllableUnit">Controllable unit.</param>
	void Perform(ControllableUnit controllableUnit);
}
