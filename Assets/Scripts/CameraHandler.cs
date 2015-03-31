using UnityEngine;
using System.Collections;

public class CameraHandler : MonoBehaviour {
	private int numberOfScreens = 2;
	private int currentScreen = 0;
	private Vector3[] screenPositions;
	private bool isMoving = false;
	private Vector3 lerpStartPosition;
	private Vector3 lerpEndPosition;
	public float lerpTime = 0.5f;
	private float currentLerpTime;

	void Start() {
		Vector3 screenDimsInPixels = new Vector3(Screen.width, 
																						 Screen.height, 0);
		Vector3 dimsInWorldPoint = Camera.main.ScreenToWorldPoint(
				screenDimsInPixels);
		float xMoveAmount = dimsInWorldPoint.x * 2;

		screenPositions = new Vector3[numberOfScreens];
		for(int i = 0; i < screenPositions.Length; i++) {
			Vector3 currentPosition = transform.position;
			Vector3 newPosition = currentPosition;
			newPosition.x = newPosition.x + (xMoveAmount * i);
			screenPositions[i] = newPosition;
		}
	}

	void FixedUpdate() {
		if(isMoving) {
			bool finishedLerping = LerpIt();
			if(finishedLerping) {
				Debug.Log("Finished moving to screen " + currentScreen);
				isMoving = false;
			}
		}
	}

	private bool LerpIt() {
		bool finishedLerping = false;

		currentLerpTime += Time.deltaTime;
		if(currentLerpTime > lerpTime) {
			currentLerpTime = lerpTime;
			finishedLerping = true;
		}
		float progress = currentLerpTime / lerpTime;
		transform.position = Vector3.Lerp(lerpStartPosition, 
																			lerpEndPosition, 
																			progress);
		return finishedLerping;
	}

	public void MoveFromCurrentScreen(int screensToMove) {
		int newScreen = currentScreen + screensToMove;
		Debug.Log("newScreen " + newScreen);
		if( (newScreen > -1) && (newScreen < numberOfScreens) ) {
			Debug.Log("Begin moving to screen " + newScreen);
			currentLerpTime = 0f;
			lerpStartPosition = transform.position;
			lerpEndPosition = screenPositions[newScreen];

			currentScreen = newScreen;
			isMoving = true;
		}
	}
}
