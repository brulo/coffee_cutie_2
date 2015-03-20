using UnityEngine;
using System.Collections;

public class PourableDispenser : StationaryDispenser {
	public float tiltSpeed = 100f;
	public float timeBetweenDispenses = 0.8f; 

	private bool isTilting = false;
	private bool isUntilting = false;
	private bool isPouring = false;
	private Quaternion defaultRotation = Quaternion.Euler(0, 0, 0);
	private Quaternion pouringRotation = Quaternion.Euler(0, 0, 90);
	private float lastDispenseTime; 

	protected override void Start() {
		base.Start();
	}

	void FixedUpdate() {
		if(isTilting) {
			DoRotateTowards(pouringRotation);
			if(IsDoneRotatingTowards(pouringRotation)) {
				isTilting = false;
				StartPouring();
			}
		}
		if(isUntilting) {
			DoRotateTowards(defaultRotation);
			if(IsDoneRotatingTowards(defaultRotation)) {
				isUntilting = false;
			}
		}
		if(isPouring) {
			float timeElapsed = Time.time - lastDispenseTime;
			if(timeElapsed >= timeBetweenDispenses)
				Pour();
		}
	}
	
	private void DoRotateTowards(Quaternion desiredRotation) {
		float step = tiltSpeed * Time.deltaTime;
		transform.rotation = Quaternion.RotateTowards(transform.rotation, 
																									desiredRotation, 
																									step);
	}

	private bool IsDoneRotatingTowards(Quaternion desiredRotation) {
			float currentAngle = Quaternion.Angle(desiredRotation, 
																						gameObject.transform.rotation);
			if(currentAngle <=0) 
				return true;
			else 
				return false;
	}

	private void StartTilting() {
		isUntilting = false;
		isPouring = false;
		isTilting = true;
		Debug.Log("Started tilting ingredient");
	}

	private void StartUntilting() {
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

	void OnMouseUp() {
		StartUntilting();
	}
}
