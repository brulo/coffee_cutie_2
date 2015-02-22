using UnityEngine;
using System.Collections;

public class CursorHandler : MonoBehaviour {
	public Vector2 cursorSize;
	private SpriteRenderer spriteRenderer;
	public Sprite regularSprite;
	public Sprite grabSprite;

	void Start() {
		Screen.showCursor = false;

		spriteRenderer = GetComponent<SpriteRenderer>();
		spriteRenderer.sprite = regularSprite;
	}

	void OnEnable() {
		Grabbable.MouseEnter +=  SetGrabCursor;
		Grabbable.MouseExit += SetRegularCursor;
	}	

	void OnDisable() {
		Grabbable.MouseEnter -= SetGrabCursor;
		Grabbable.MouseExit -= SetRegularCursor;
	}	

	public void SetGrabCursor() {
		spriteRenderer.sprite = grabSprite;
	}

	public void SetRegularCursor() {
		spriteRenderer.sprite = regularSprite;
	}

	void FixedUpdate() {
		Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		Vector3 newPosition = mousePosition;
		newPosition.z = 10;
		gameObject.transform.position = newPosition;
	}

}
