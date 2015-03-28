using UnityEngine;

public class PourZone : MonoBehaviour {
	Collider2D pourZoneCol;
	Quaternion uprightRotation = Quaternion.Euler(0, 0, 0);
	float uprightThreshold = 1f;

	void Start() {
		pourZoneCol = GetComponent<Collider2D>();
	}

	void Update() {
		Quaternion pourZoneRotation = gameObject.transform.rotation;
		float angleFromUpright = Quaternion.Angle(uprightRotation,
																							pourZoneRotation);
		if((angleFromUpright > -uprightThreshold) && (angleFromUpright < uprightThreshold)) {
			if(!pourZoneCol.enabled) {
				Debug.Log("Pour zone disabled");
				pourZoneCol.enabled = true;
			}
		}
		else {
			if(pourZoneCol.enabled) {
				Debug.Log("Pour zone disabled");
				pourZoneCol.enabled = false;
			}
		}
	}
}
