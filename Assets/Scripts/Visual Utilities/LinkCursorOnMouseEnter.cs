using UnityEngine;
using System.Collections;

public class MouseGrabbable : MonoBehaviour {

	public delegate void Trigger();
	public static event Trigger OnMouseEnterGrabbable;
	public static event Trigger OnMouseExitGrabbable;

	void OnMouseEnter() {
		if(OnMouseEnterGrabbable != null)
			OnMouseEnterGrabbable();
	}

	void OnMouseExit() {
		if(OnMouseEnterGrabbable != null)
			OnMouseExitGrabbable();
	}
}
