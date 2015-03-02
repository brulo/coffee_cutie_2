using UnityEngine;
using System.Collections;

public class Droplet : MonoBehaviour {
	public Ingredient ingredient;

	void OnCollisionEnter2D(Collision2D col) {
		if(col.gameObject.tag == "Drink") { 
			col.gameObject.GetComponent<DrinkForCustomer>().drink.AddIngredient(ingredient);
			Destroy(this.gameObject);
		}
		else if(col.gameObject.tag == "Counter") {
			Debug.Log("Droplet hit counter!");
			Destroy(this.gameObject);
		}
	}

}
