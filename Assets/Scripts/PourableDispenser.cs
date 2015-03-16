using UnityEngine;
using System.Collections;

public class PourableDispenser : StationaryDispenser {
	public float tiltTime = 1f;
	public float untiltTime = 0.5f;
	private bool isTilting = false;
	private bool isUntilting = false;
	private Quaternion defaultRotation = Quaternion.Euler(0,0,0);
	private Quaternion pouringRotation = Quaternion.Euler(0,0,90);
	private float fullPourAngle;

	// Shared lerp variables.
	private Quaternion lerpStartRotation;
	private float lerpStartTime;
	private float lerpTime;

	protected override void Start() {
		base.Start();
		fullPourAngle = Quaternion.Angle(defaultRotation, pouringRotation);
	}

	void Update() {
		if(isTilting) {
			bool finishedLerping = LerpIt(pouringRotation);
			if(finishedLerping) {
				Debug.Log("Finished Tilting");
				isTilting = false;
				Dispense();
			}
		}	
		if(isUntilting) {
			bool finishedLerping = LerpIt(defaultRotation);
			if(finishedLerping) {
				Debug.Log("Finished Untilting");
				isUntilting = false;
			}
		}
	}


	private void StartTilting() {
		lerpStartRotation = gameObject.transform.rotation;
		lerpStartTime = Time.time + Time.deltaTime;
		lerpTime = GetLerpTime(tiltTime, lerpStartRotation, pouringRotation);
		Debug.Log("Tilt Time: " + lerpTime);
		isUntilting = false;
		isTilting = true;
		Debug.Log("Started tilting ingredient");
	}

	private void StartUntilting() {
		lerpStartRotation = gameObject.transform.rotation;
		lerpTime = GetLerpTime(untiltTime, lerpStartRotation, defaultRotation);
		Debug.Log("Untilt Time: " + lerpTime);
		lerpStartTime = Time.time;
		isTilting = false;
		isUntilting = true;
		Debug.Log("Stoped tilting ingredient");
	}

	private float GetLerpTime(float fullTime, 
													 Quaternion currentRotation, 
													 Quaternion desiredRotation) {
		float rotationDifference = Quaternion.Angle(currentRotation, 
																								desiredRotation);
		Debug.Log("difference: " + rotationDifference);
		Debug.Log("full angle: " + fullPourAngle);
		return fullTime * (rotationDifference / fullPourAngle);
	}

	private bool LerpIt(Quaternion desiredRotation) {
			bool finishedLerping;
			float timeElapsed = (Time.time - lerpStartTime);
			float progress = 1 - ( (lerpTime - timeElapsed) / lerpTime );
			if(progress < 1f) {
				gameObject.transform.rotation = Quaternion.Lerp(lerpStartRotation, 
																												desiredRotation, 
																												progress);
				finishedLerping = false;
			}
			else 
				finishedLerping = true;
			return finishedLerping;
	}

	void OnTriggerEnter2D(Collider2D col) {
		if(col.gameObject.tag == "Pour Zone")
			StartTilting();	
	}

	void OnTriggerExit2D(Collider2D col) {
		if(col.gameObject.tag == "Pour Zone")
			StartUntilting();	
	}
}
