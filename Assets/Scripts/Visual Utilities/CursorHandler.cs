using UnityEngine;
using System.Collections;

public class CursorHandler : MonoBehaviour {

	public Vector2 cursorSize;
	private SpriteRenderer spriteRenderer;
	public Sprite regularSprite;
	public Sprite grabSprite;

	void Start() {
		Cursor.visible = false;

		spriteRenderer = GetComponent<SpriteRenderer>();
		spriteRenderer.sprite = regularSprite;
	}

	void OnEnable() {
		GrabbableObject.MouseEnter +=  SetGrabCursor;
		GrabbableObject.MouseExit += SetRegularCursor;
	}	

	void OnDisable() {
		GrabbableObject.MouseEnter -= SetGrabCursor;
		GrabbableObject.MouseExit -= SetRegularCursor;
	}	

	public void SetGrabCursor() {
		spriteRenderer.sprite = grabSprite;
	}

	public void SetRegularCursor() {
		spriteRenderer.sprite = regularSprite;
	}

	void FixedUpdate() {
		// Update sprite's position to mouse location.
		Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		Vector3 newPosition = mousePosition;
		newPosition.z = 10;
		gameObject.transform.position = newPosition;
	}

}
