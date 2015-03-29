using UnityEngine;
using System.Collections;

public class CameraHandler : MonoBehaviour {
	public int numberOfScreens = 2;
	private int currentScreen = 0;
	private float xMoveAmount;
	private bool isMoving = false;

	private Vector3 lerpStartPosition;
	private Vector3 lerpEndPosition;

	private float lerpTime = 1f;
	private float currentLerpTime;

	void Start() {
		Vector3 screenDimsInPixels = new Vector3(Screen.width, 
																						 Screen.height, 0);
		Vector3 dimsInWorldPoint = Camera.main.ScreenToWorldPoint(
				screenDimsInPixels);
		xMoveAmount = dimsInWorldPoint.x * 2;
	}

	void Update() {
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

			currentScreen = newScreen;
			isMoving = true;

			currentLerpTime = 0f;

			lerpStartPosition = transform.position;

			Vector3 currentPosition = transform.position;
			Vector3 newPosition = currentPosition;
			newPosition.x = newPosition.x + (xMoveAmount * screensToMove);
			lerpEndPosition = newPosition;
		}
	}
}
