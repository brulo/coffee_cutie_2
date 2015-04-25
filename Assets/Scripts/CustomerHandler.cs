using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CustomerHandler : MonoBehaviour {
	private Recipe recipeToMake;
	private RecipeBook recipeBook = new RecipeBook();

	void Start() {
		GetNewDrinkToMake();
		Debug.Log(DrinkOrderText());
	}	

	void SubmitDrink() {
	}

	void GetNewDrinkToMake() {
		int drinkIndex = Random.Range(0, recipeBook.AllRecipes.Length);
		recipeToMake = recipeBook.AllRecipes[drinkIndex];
		recipeToMake.InitializeDrink();
	}

	public string DrinkOrderText() {
		string output = "Could I get a ";
		output += recipeToMake.Name;
		output += " with";
		foreach(Ingredient ing in recipeToMake.specificsForCustomerOrder) {
			output += " " +  ing.NameText;
			Debug.Log(ing.NameText);
		}
		output += " please?";
		return output;
	}
}
