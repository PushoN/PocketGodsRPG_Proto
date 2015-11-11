using UnityEngine;
using System.Collections;

/// <summary>
/// Represents a player that controls the battle system
/// </summary>
public interface IPlayer {
	void OnStartTurn();
	void DoAction();
	void OnFinishedTurn();
}
