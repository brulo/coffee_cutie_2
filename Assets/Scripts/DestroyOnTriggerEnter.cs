using UnityEngine;
using System.Collections;

public class DestroyOnTriggerEnter : MonoBehaviour {
	void OnTriggerEnter2D(Collider2D col) {
		if(col.gameObject.tag == "Drink") {
			Destroy(col.gameObject);
		}
	}
}
