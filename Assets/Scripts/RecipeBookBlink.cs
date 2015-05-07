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
		for(int i = 0; i < 3; i++) {
			image.color = Color.grey;
			yield return new WaitForSeconds(.4f);
			image.color = Color.white;
			yield return new WaitForSeconds(.4f);
		}
	}

}
