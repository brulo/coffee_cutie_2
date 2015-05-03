using UnityEngine;
using System.Collections;

public class CatCallerHandler : MonoBehaviour {
	public GameObject catCallerPrefab;
	public GameState gameState;
	private float timeBetweenSummons = 30f;

	void Start() {
		gameState = GameObject.Find("Game State").GetComponent<GameState>();
		StartCoroutine(SummonLoop(timeBetweenSummons));
	}
	
	public void SummonCatcaller() {
		GameObject catCaller = Instantiate(catCallerPrefab);
		catCaller.transform.parent = GameObject.Find("World Position Canvas").transform;
	}

	IEnumerator SummonLoop(float seconds) {
		while(true) {
			yield return new WaitForSeconds(seconds);
			SummonCatcaller();
		}
	}

}
