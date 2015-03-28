using UnityEngine;
using System.Collections;

public class Droplet : MonoBehaviour {
	public Ingredient ingredient;

	void OnCollisionEnter2D(Collision2D col) {
		if(col.gameObject.tag == "Drink") { 
			Quaternion drinkRotation = col.gameObject.transform.rotation;
			Quaternion uprightRotation = Quaternion.Euler(0, 0, 0);
			float angleFromUpright = Quaternion.Angle(uprightRotation,
																								drinkRotation);
			if( (angleFromUpright > -5f) & (angleFromUpright < 5f) ) {
				Debug.Log("Droplet hit drink!");
				col.gameObject.GetComponent<DrinkForCustomer>().drink.AddIngredient(ingredient);
				Destroy(this.gameObject);
			}
		}
		else if(col.gameObject.tag == "Counter") {
			Debug.Log("Droplet hit counter!");
			Destroy(this.gameObject);
		}
		else {
			Debug.Log("Droplet hit something! (Not drink or counter)");
			Destroy(this.gameObject);
		}
	}
}
