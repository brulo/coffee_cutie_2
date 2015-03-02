using UnityEngine;
using System.Collections;

public class StationaryDispenserButton : MonoBehaviour {
	StationaryDispenser dispenser;

	void Start() {
		dispenser = gameObject.transform.parent.gameObject.GetComponent<StationaryDispenser>();
	}

	void OnMouseUp() {
		dispenser.Dispense();
	}
}
