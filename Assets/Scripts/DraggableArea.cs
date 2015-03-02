using UnityEngine;
using System.Collections;

public class DraggableArea : MonoBehaviour {
	public delegate void Trigger();
	public static event Trigger MouseEnter;
	public static event Trigger MouseExit;

	private static bool isInArea;
	public static bool IsInArea { get { return isInArea; } }

	void OnMouseEnter() {
		isInArea = true;
		if(MouseEnter != null)
			MouseEnter();
	}

	void OnMouseExit() {
		isInArea = false;
		if(MouseExit != null)
			MouseExit();
	}

}
