using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CustomerHandler : MonoBehaviour {
	private Recipe recipeToMake;
	private RecipeBook recipeBook = new RecipeBook();

	void OnTriggerEnter2D(Collider2D col) {
		if(col.gameObject.tag == "Drink") { 
			/* if(!col.gameObject.GetComponent<GrabbableObject>().IsHeld) { */
			/* } */
			SubmitDrink(col.gameObject.GetComponent<DrinkForCustomer>().drink);
		}
	}

	void Start() {
		GetNewDrinkToMake();
		Debug.Log(DrinkOrderText());
	}	

	void SubmitDrink(Drink drink) {
		Debug.Log(CustomerResponse(drink));
		if(CustomerResponse(drink) == "Perfect, thanks!") {
			// add money or something
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

	public string CustomerResponse(Drink drink) {
		// determine errors (if any)
		int[] drinkCount = drink.IngredientNameCounts;
		int[] toMakeCount = recipeToMake.drink.IngredientNameCounts;

		List<Ingredient> didntWant = new List<Ingredient>();
		List<Ingredient> notEnough = new List<Ingredient>();
		List<Ingredient> tooMuch = new List<Ingredient>();

		foreach(IngredientName ingName in System.Enum.GetValues(
					typeof(IngredientName))) {
			if(toMakeCount[(int)ingName] - drinkCount[(int)ingName] > 0) {
				if(ingName != IngredientName.HotCup | 
						ingName != IngredientName.ColdCup | 
						ingName != IngredientName.EspressoCup) {
					notEnough.Add(new Ingredient(ingName));
				}
			}
			else if(toMakeCount[(int)ingName] - drinkCount[(int)ingName] < 0) {
				if(toMakeCount[(int)ingName] == 0) {
					if(ingName != IngredientName.HotCup | 
							ingName != IngredientName.ColdCup | 
							ingName != IngredientName.EspressoCup) {
						didntWant.Add(new Ingredient(ingName));
					}
				}
				else { 
					tooMuch.Add(new Ingredient(ingName));
				}
			}
		}

		// construct customer response string
		if(didntWant.Count == 0 & 
				notEnough.Count == 0 && 
				tooMuch.Count == 0 & 
				drink.cup != recipeToMake.drink.cup) {
			return "Perfect, thanks!";
		}
		else {
			string complaints = "Umm... ";
			if(tooMuch.Count > 0) {
				int count = 0;
				complaints += "This has too much ";
				foreach(Ingredient ing in tooMuch) {
					count++;
					complaints += ing.NameText.ToLower();
					if(tooMuch.Count - count > 1) {
						complaints += ", ";
					}
					else if(tooMuch.Count - count > 0) {
						complaints += " and ";
					}
					else if(notEnough.Count > 0 | didntWant.Count > 0) {
						complaints += ", ";
					}
				}
			}
			if(notEnough.Count > 0) {
				int count = 0;
				if(tooMuch.Count < 1) {
					complaints += "This ";
				}
				complaints += "doesn't have enough ";
				foreach(Ingredient ing in notEnough) {
					count++;
					complaints += ing.NameText.ToLower();
					if(notEnough.Count - count > 1) {
						complaints += ", ";
					}
					else if(notEnough.Count - count > 0) {
						complaints += " and ";
					}
					else if(didntWant.Count > 0) {
						complaints += ", ";
					}
				}
			}
			if(didntWant.Count > 0) {
				int count = 0;
				if(tooMuch.Count > 0 | notEnough.Count > 0) {
					complaints += "and ";
				}
				complaints += "I didn't ask for any ";
				foreach(Ingredient ing in didntWant) {
					count++;
					complaints += ing.NameText.ToLower();
					if(didntWant.Count - count > 1) {
						complaints += ", ";
					}
					else if(didntWant.Count - count > 0) {
						complaints += " or ";
					}
				}
			}
			complaints += "! ";
			if(drink.cup.Name != recipeToMake.drink.cup.Name) {
				if(tooMuch.Count > 0 | notEnough.Count > 0 | didntWant.Count > 0) {
					complaints += "Also, this is supposed to come in a ";
				}
				else {
					complaints += "This is supposed to come in a ";
				}
				complaints += recipeToMake.drink.cup.NameText.ToLower();
			}
			return complaints;
		}
	}
}
