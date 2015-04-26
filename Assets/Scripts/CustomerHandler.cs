using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CustomerHandler : MonoBehaviour {
	private Recipe recipeToMake;
	private RecipeBook recipeBook = new RecipeBook();

	void OnTriggerEnter2D(Collider2D col) {
		if(col.gameObject.tag == "Drink") { 
			/* if(!col.gameObject.GetComponent<GrabbableObject>().IsHeld) { */
				SubmitDrink(col.gameObject.GetComponent<DrinkForCustomer>().drink);
			/* } */
		}
	}

	void Start() {
		GetNewDrinkToMake();
		Debug.Log(DrinkOrderText());
	}	

	void SubmitDrink(Drink drink) {
		if(IsTheDrinkToMake(drink)) {
			Debug.Log("Drink is correct!");
		}
		else {
			Debug.Log("Drink is not correct...");
		}
	}

	void GetNewDrinkToMake() {
		recipeToMake = recipeBook.RandomRecipe;
		// randomize the appropriate ingredients
		recipeToMake.InitializeDrink(); 	
	}

	public string DrinkOrderText() {
		string output = "Could I get a ";
		output += recipeToMake.Name.ToLower();
		output += " with";
		foreach(Ingredient ing in recipeToMake.specificsForCustomerOrder) {
			output += " " +  ing.NameText.ToLower();
			Debug.Log(ing.NameText);
		}
		output += " please?";
		return output;
	}

	public bool IsTheDrinkToMake(Drink drink) {
		int[] drinkCount = drink.IngredientNameCounts;
		int[] toMakeCount = recipeToMake.drink.IngredientNameCounts;
		foreach(IngredientName ingName in System.Enum.GetValues(
					typeof(IngredientName))) {
			if(toMakeCount[(int)ingName] - drinkCount[(int)ingName] != 0) {
				Debug.Log(ingName.ToString());
				return false;
			}
		}
		return true;
	}

}
