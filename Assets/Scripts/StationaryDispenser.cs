using UnityEngine;
using System.Collections;

public class StationaryDispenser : MonoBehaviour {
	public Droplet dropletPrefab;

	public Ingredient ingredient;
	public IngredientName ingredientName;
	Collider2D drinkCollider = null; 

	void Start() {
		ingredient = new Ingredient(ingredientName);
	}	

	void OnTriggerEnter2D(Collider2D col) {
		if(col.gameObject.tag == "Drink") 
			drinkCollider = col;	
	}

	void OnTriggerExit2D(Collider2D col) {
		if(col.gameObject.tag == "Drink")
			drinkCollider = null;	
	}

	public void Dispense() {
		Droplet droplet = Instantiate(dropletPrefab, gameObject.transform.position, Quaternion.identity) as Droplet;
		droplet.ingredient = ingredient;
		Debug.Log(droplet.ingredient);
	}

}
