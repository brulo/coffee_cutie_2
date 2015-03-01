using UnityEngine;
using System.Collections;

public class IngredientDispenser : MonoBehaviour {
	public Ingredient ingredient;
	public IngredientName ingredientName;
	Collider2D drinkCollider = null;
	
	void Start() {
		ingredient = new Ingredient(ingredientName);
	}	

	void OnTriggerEnter2D(Collider2D col) {
		drinkCollider = col;	
	}

	void OnTriggerExit2D(Collider2D col) {
		drinkCollider = null;	
	}

	void OnMouseUp() {
		if(drinkCollider != null) {
			DrinkForCustomer customerDrink = drinkCollider.gameObject.GetComponent<DrinkForCustomer>();
			customerDrink.drink.AddIngredient(ingredient);
		}
	}
}
