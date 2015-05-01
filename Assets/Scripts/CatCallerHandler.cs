using UnityEngine;
using System.Collections;

public class CatCallerHandler : MonoBehaviour {
	public GameObject catCallerPrefab;

	void Start() {
		GameObject catCaller = Instantiate(catCallerPrefab);
		catCaller.transform.parent = GameObject.Find("World Position Canvas").transform;
	}
}
