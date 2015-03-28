// Requires RotatableObject and RotatableObject.
using UnityEngine;
using System.Collections;

public class PourableDispenser : StationaryDispenser {
	public float tiltSpeed = 100f;
	public float timeBetweenDispenses = 0.8f; 

	private bool isTilting = false;
	private bool isUntilting = false;
	private bool isPouring = false;
	private Quaternion defaultRotation = Quaternion.Euler(0, 0, 0);
	private Quaternion pourRotation = Quaternion.Euler(0, 0, 90);
	private float lastDispenseTime; 

	private RotatableObject rotatable;
	private GrabbableObject grabbable;

	protected override void Start() {
		base.Start();
		rotatable = GetComponent<RotatableObject>();
		grabbable = GetComponent<GrabbableObject>();
	}

	void FixedUpdate() {
		if(grabbable.IsHeld) {
			rotatable.RotateTowardDesired = true;
			if(isTilting) {
				if(rotatable.CurrentAngleFromDesired == 0) {
					isTilting = false;
					StartPouring();
				}
			}
			if(isUntilting) {
				if(rotatable.CurrentAngleFromDesired == 0) {
					isUntilting = false;
				}
			}
			if(isPouring) {
				float timeElapsed = Time.time - lastDispenseTime;
				if(timeElapsed >= timeBetweenDispenses)
					Pour();
			}
		}
		else 
			rotatable.RotateTowardDesired = false;
	}
	
	private void StartTilting() {
		rotatable.DesiredRotation = pourRotation;
		isUntilting = false;
		isPouring = false;
		isTilting = true;
		Debug.Log("Started tilting ingredient");
	}

	private void StartUntilting() {
		rotatable.DesiredRotation = defaultRotation;
		isTilting = false;
		isPouring = false;
		isUntilting = true;
		Debug.Log("Stoped tilting ingredient");
	}

	private void StartPouring() {
		isPouring = true;
		Pour();
	}

	private void Pour() {
		Dispense();
		lastDispenseTime = Time.time;
	}


	// Callbacks
	void OnTriggerEnter2D(Collider2D col) {
		if(col.gameObject.tag == "Pour Zone")
			StartTilting();	
	}

	void OnTriggerExit2D(Collider2D col) {
		if(col.gameObject.tag == "Pour Zone")
			StartUntilting();	
	}
}
