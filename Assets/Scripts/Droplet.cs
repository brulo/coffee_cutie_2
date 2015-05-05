using UnityEngine;
using System.Collections;

public class Droplet : MonoBehaviour {
	public Ingredient ingredient;
	public float uprightThreshold = 5f;

	void OnCollisionEnter2D(Collision2D col) {
		if(col.gameObject.tag == "Drink") { 
			Quaternion drinkRotation = col.gameObject.transform.rotation;
			Quaternion uprightRotation = Quaternion.Euler(0, 0, 0);
			float angleFromUpright = Quaternion.Angle(uprightRotation,
																								drinkRotation);
			if( (angleFromUpright > -uprightThreshold) & (angleFromUpright < uprightThreshold) ) {
				Drink drink = col.gameObject.GetComponent<DrinkForCustomer>().drink;
				if(drink.CanAddIngredient(ingredient)) {
					Debug.Log(drink.CanAddIngredient(ingredient));
					Debug.Log("Droplet hit drink!");
					drink.AddIngredient(ingredient);
					/* col.gameObject.GetComponent<DrinkAnimator>().UpdateRenderer(drink); */
					DrinkAnimator drinkAnimator = col.gameObject.GetComponent<DrinkAnimator>();
					drinkAnimator.UpdateRenderer();
					Destroy(this.gameObject);
				}
			}
		}
		else if(col.gameObject.tag == "Counter") {
			Debug.Log("Droplet hit counter!");
			Destroy(this.gameObject);
		}
	}
}
