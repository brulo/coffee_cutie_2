// Requires RotatableObject and RotatableObject.
using UnityEngine;
using System.Collections;

public class RotateUprightOnGrab : MonoBehaviour {
	private RotatableObject rotatable;
	private GrabbableObject grabbable;
	private Quaternion uprightRotation = Quaternion.Euler(0, 0, 0);

	void Start() {
		rotatable = GetComponent<RotatableObject>();
		rotatable.DesiredRotation = uprightRotation;
		grabbable = GetComponent<GrabbableObject>();
	}

	void FixedUpdate() {
		if(grabbable.IsHeld)
			rotatable.RotateTowardDesired = true;
		else
			rotatable.RotateTowardDesired = false;
	}
}
