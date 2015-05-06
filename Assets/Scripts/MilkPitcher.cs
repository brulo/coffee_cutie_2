// Requires RotatableObject and RotatableObject.
using UnityEngine;
using System.Collections;

public class MilkPitcher : PourableDispenser {
	private bool hasMilk = false;
	public bool HasMilk { get { return hasMilk; } }
	private bool isFoam = false;

	public void AddMilk(Ingredient ing) {
		if(ing.Type == IngredientType.Milk) {
			ingredient = ing;
			hasMilk = true;
			isFoam = false;
			Debug.Log("added milk");
		}
	}

	public bool SteamMilk() {
		if(hasMilk) {
			isFoam = true;
			if(ingredient.Name == IngredientName.TwoPercentMilk) {
				ingredient = new Ingredient(IngredientName.SteamedTwoPercentMilk);
			}
			else if(ingredient.Name == IngredientName.NonFatMilk) {
				ingredient = new Ingredient(IngredientName.SteamedNonFatMilk);
			}
			else if(ingredient.Name == IngredientName.NonFatMilk) {
				ingredient = new Ingredient(IngredientName.SteamedSoyMilk);
			}
			Debug.Log("added " + ingredient.NameText);
			return true;
		}
		else {
			Debug.Log("couldnt add steam, no milk");
			return false;
		}
	}

	// Overwrite PourableDispenser's Pour()
	private void Pour() {
		if(hasMilk) {
			Debug.Log("lkksjfa;lsdkf");
			Dispense();
			hasMilk = false;
			isFoam = false;
			lastDispenseTime = Time.time;
		}
	}
}
