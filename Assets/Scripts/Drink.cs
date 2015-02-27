using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Drink {
	List<Ingredient> ingredients = new List<Ingredient>();
	Container container;
	int[] typeCounts;
	int[] ingredientCounts;
	string drinkName;

	public Drink(ContainerName c, string name) {
		container = new Container(c);
		drinkName = name;

		typeCounts = new int[IngredientType.GetValues(typeof(IngredientType)).Length];
		for(int i = 0; i < typeCounts.Length; i++) 
			typeCounts[i] = 0;

		ingredientCounts = new int[IngredientName.GetValues(typeof(IngredientName)).Length];
		for(int i = 0; i < ingredientCounts.Length; i++)
			ingredientCounts[i] = 0;
	}

	public void AddIngredient(Ingredient ingredient) {
		Debug.Log("Adding" + ingredient.GetNameText());
		ingredients.Add(ingredient);
		typeCounts[(int)ingredient.Type] += 1;
		ingredientCounts[(int)ingredient.Name] += 1;
	}

	public int TypeCount(IngredientType type) {
		return typeCounts[(int)type];
	}

	public string RecipeText() {
		string output = drinkName + "\n";
		foreach(IngredientName ingredientName in IngredientName.GetValues(typeof(IngredientName))) {
			Ingredient tempIngredient = new Ingredient(ingredientName);
			int ingredientCount = ingredientCounts[(int)ingredientName];
			if(ingredientCount > 0) {
				output += "- " + tempIngredient.GetNameText();
				if(ingredientCount > 1) {
					output += " x " + ingredientCount;
				}
				output += "\n";
			}
		}
		output += "- " + container.GetTemperatureText(); 
		return output;
	}
}
