using UnityEngine;
using System.Collections;
public class RotatableObject : MonoBehaviour {
	private Quaternion desiredRotation; 
	public Quaternion DesiredRotation { 
		get { return desiredRotation; }
		set { desiredRotation = value; }
	}

	private float rotateSpeed = 100f;
	public float RotateSpeed {
		get { return rotateSpeed; }
		set { rotateSpeed = value; }
	}

	public float CurrentAngleFromDesired { 
		get { return Quaternion.Angle(desiredRotation, 
																  gameObject.transform.rotation);
		} 
	}

	private bool rotateTowardDesired = false;
	public bool RotateTowardDesired { 
		get { return rotateTowardDesired; } 
		set { rotateTowardDesired = value; }
	}

	void Start() {
		desiredRotation = gameObject.transform.rotation;
	}

	void FixedUpdate() {
		if(rotateTowardDesired) {
			if(CurrentAngleFromDesired != 0) {
				float step = rotateSpeed * Time.deltaTime;
				transform.rotation = Quaternion.RotateTowards(transform.rotation, 
																											desiredRotation, 
																											step);
			}
		}
	}

}
