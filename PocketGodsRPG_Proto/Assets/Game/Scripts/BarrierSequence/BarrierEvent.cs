using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BarrierEvent {

	private string eventName;
	private List<ASequence> sequenceList = new List<ASequence>();

	public BarrierEvent(string eventName) {
		this.eventName = eventName;
	}

	public void AddSequence(ASequence sequence) {
		this.sequenceList.Add(sequence);
	}

	//executes specified sequences
	public void Execute() {
		foreach(ASequence sequence in this.sequenceList) {
			sequence.Execute();
		}
	}

	public bool HasFinishedSequence() {
		foreach(ASequence sequence in this.sequenceList) {
			if(sequence.IsFinished() == false) {
				return false;
			}
		}

		return true;
	}

	public string GetBarrierEventName() {
		return this.eventName;
	}
}

public abstract class ASequence {

	protected CyclicBarrierSequence barrierSequence;
	private bool finished = false;

	public ASequence(CyclicBarrierSequence barrierSequence) {
		this.barrierSequence = barrierSequence;
	}

	public abstract void Execute();
	public void ReportFinished() {
		this.finished = true;
		this.barrierSequence.MoveToNextBarrier();
	}
	
	public bool IsFinished() {
		return this.finished;
	}
}
