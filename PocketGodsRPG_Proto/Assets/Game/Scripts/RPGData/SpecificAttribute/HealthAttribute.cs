using UnityEngine;
using System.Collections;

public class HealthAttribute: ConcreteAttribute {

	public HealthAttribute(int baseValue, float multiplier): base(baseValue, multiplier) {
		
	}
}
