using UnityEngine;
using System.Collections;
using System.Collections.Generic;


/// <summary>
/// A class that is capable of throwing a MAJOR event. In each MAJOR event, a series of sub-events are executed.
/// All these sub-events should report successfully before proceeding to the next MAJOR event.
/// 
/// By: NeilDG
/// </summary>
public class CyclicBarrierSequence {

	private List<BarrierEvent> eventsTable = new List<BarrierEvent>();

	private int currentIndex = 0;

	public CyclicBarrierSequence() {

	}

	public void CreateMajorEvent(BarrierEvent barrierEvent) {
		this.eventsTable.Add(barrierEvent);
	}

	public void DeleteMajorEvent(BarrierEvent barrierEvent) {
		this.eventsTable.Remove(barrierEvent);
	}

	public void StartExecution() {
		Debug.Log ("[BarrierSequence] Currently executing " +this.eventsTable[currentIndex].GetBarrierEventName());
		this.eventsTable[currentIndex].Execute();
	}

	/// <summary>
	/// Moves to next barrier if the conditions for current MAJOR event has been satified
	/// </summary>
	public void MoveToNextBarrier() {
		if(this.eventsTable[this.currentIndex].HasFinishedSequence()) {
			this.currentIndex++;
		}

		if(this.HasFinished() == false) {
			this.StartExecution();
		}
	}

	public string GetCurrentBarrierName() {
		return this.eventsTable[this.currentIndex].GetBarrierEventName();
	}

	public bool HasFinished() {
		return (this.currentIndex == this.eventsTable.Count);
	}
}
