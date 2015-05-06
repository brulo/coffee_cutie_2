using UnityEngine;
using System.Collections;

public class SpawnPrefabOnClick : MonoBehaviour {
	public GameObject prefab;

	void OnMouseUp() {
		GameObject go = Instantiate(prefab, transform.position, Quaternion.identity) as GameObject;
		GameObject round = GameObject.Find("Round");
		go.transform.parent = round.transform;
	}
}
