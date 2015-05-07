using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RecipeBookBlink : MonoBehaviour {
	private Image image;

	void Start() {
		image = GetComponent<Image>();
		StartCoroutine(BlinkImage());
	}

	IEnumerator BlinkImage() {
<<<<<<< HEAD
		for(int i = 0; i < 3; i++) {
=======
		for(int i = 0; i < 5; i++) {
>>>>>>> 1acd5c016a48fbd1b57e9aa691f7bf0d07599c62
			image.color = Color.grey;
			yield return new WaitForSeconds(.4f);
			image.color = Color.white;
			yield return new WaitForSeconds(.4f);
		}
	}

}
