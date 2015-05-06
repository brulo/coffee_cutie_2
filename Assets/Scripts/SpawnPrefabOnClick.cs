using UnityEngine;
using System.Collections;

public class SpawnPrefabOnClick : MonoBehaviour {
	public GameObject prefab;
	private AudioSource audioSource;

	void Start() {
		audioSource = GetComponent<AudioSource>();
	}

	void OnMouseUp() {
		GameObject go = Instantiate(prefab, transform.position, Quaternion.identity) as GameObject;
		GameObject round = GameObject.Find("Round");
		go.transform.parent = round.transform;
		audioSource.Play();
	}
}
