using UnityEngine;
using System.Collections;

public class ScreenBoundry : MonoBehaviour {
	public int numberOfScreensToMove = 0;
	CameraHandler cameraHandler;

	void Start() {
		cameraHandler = Camera.main.GetComponent<CameraHandler>();
	}
	
	void OnTriggerEnter2D(Collider2D col) {
		Debug.Log("trigger enter");
		GrabbableObject grabbableObject;
		grabbableObject = col.gameObject.GetComponent<GrabbableObject>();
		if(grabbableObject != null) {
			if(grabbableObject.IsHeld) {
				cameraHandler.MoveFromCurrentScreen(numberOfScreensToMove);
			}
		}
	}

}
