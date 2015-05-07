using UnityEngine;
using System.Collections;

public class HighlightSpriteOnMouseEnter : MonoBehaviour {

	public Color highlightColor = Color.grey;
	public GameObject highlightThis;
	private SpriteRenderer renderer;

	void Start() {
		renderer = highlightThis.GetComponent<SpriteRenderer>();
	}

	void OnMouseEnter() {
		renderer.color = highlightColor;
	}

	void OnMouseExit() {
		renderer.color = Color.white;
	}

}	
