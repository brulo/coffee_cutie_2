using UnityEngine;
using System.Collections;

public class HighlightSpriteOnMouseEnter : MonoBehaviour {

	public Color highlightColor = Color.red;

	void OnMouseEnter() {
		GetComponent<SpriteRenderer>().color = highlightColor;
	}

	void OnMouseExit() {
		GetComponent<SpriteRenderer>().color = Color.white;
	}

}	
