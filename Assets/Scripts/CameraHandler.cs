using UnityEngine;
using System.Collections;

public class CameraHandler : MonoBehaviour {
	public int numberOfScreens = 2;
	private int currentScreen = 0;
	public float moveAmount;

	void Start() {
		Vector3 thing = new Vector3(Screen.width, Screen.height, 0);

		Vector3 point = Camera.main.ScreenToWorldPoint(thing);
		moveAmount = point.x * 2;
	}

	public void MoveLeftAScreen() {
		if(currentScreen > 0) {
			Debug.Log("move left");
			MoveCameraX(-moveAmount);
			currentScreen--;
		}
	}

	public void MoveRightAScreen() {
		if(currentScreen < numberOfScreens - 1) {
			Debug.Log("move right");
			MoveCameraX(moveAmount);
			currentScreen++;
		}
	}

	public void MoveCameraX(float moveAmount) {
		Debug.Log("moved");
		Vector3 currentPosition = transform.position;
		Vector3 newPosition = currentPosition;
		newPosition.x = newPosition.x + moveAmount;
		transform.position = newPosition;
	}
}
