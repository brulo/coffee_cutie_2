using UnityEngine;
using System.Collections;

public class GrabbableObject : MonoBehaviour {
	private bool isHeld = false;
	public bool IsHeld { get { return isHeld; } }
	private Vector3 mouseOffset;

	public delegate void Trigger();
	public static event Trigger MouseEnter;
	public static event Trigger MouseExit;
	private Rigidbody2D rigidBody;
			
	
	void Start() {
		rigidBody = GetComponent<Rigidbody2D>();
	}

	void FixedUpdate() {
		if(isHeld) {
			Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			Vector3 newPosition = mousePosition - mouseOffset;
			newPosition.z = 0f;
			rigidBody.MovePosition(newPosition);
		}
	}

	void OnMouseEnter() {
		if(MouseEnter != null)
			MouseEnter();
	}

	void OnMouseExit() {
		if(MouseExit != null)
			MouseExit();
	}

	void OnMouseDown() {
		isHeld = true;
		GetMouseOffset();
	}

	void OnMouseUp() {
		isHeld = false;
	}

	void GetMouseOffset() {
		Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		Vector3 currentPosition = gameObject.transform.position;
		mouseOffset = new Vector3(mousePosition.x - currentPosition.x,
															mousePosition.y - currentPosition.y,
															mousePosition.z - currentPosition.z);
	}

}
