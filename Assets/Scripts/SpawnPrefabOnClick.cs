using UnityEngine;
using System.Collections;

public class SpawnPrefabOnClick : MonoBehaviour {
	public GameObject prefab;

	void OnMouseUp() {
		Instantiate(prefab, transform.position, Quaternion.identity);
	}
}
