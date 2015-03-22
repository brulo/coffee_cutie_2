using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Drink {
	List<Ingredient> ingredients = new List<Ingredient>();
	Container container;
	private int[] typeCounts;
	private int[] ingredientCounts;
	private string name;
	public string Name { get { return name; } }
	

	public Drink(Container container, 
							 List<Ingredient> ingredients,
							 string name) {
		foreach(Ingredient ingredient in ingredients)
			AddIngredient(ingredient);

		this.container = container;
		this.name = name;

		typeCounts = new int[IngredientType.GetValues(typeof(IngredientType)).Length];
		for(int i = 0; i < typeCounts.Length; i++) 
			typeCounts[i] = 0;

		ingredientCounts = new int[IngredientName.GetValues(typeof(IngredientName)).Length];
		for(int i = 0; i < ingredientCounts.Length; i++)
			ingredientCounts[i] = 0;
	}

	public Drink(Container container, string name) : this(container, 
																												new List<Ingredient>(), 
																												name){ 
	}

	public Drink(Container container) : this(container, 
																					 new List<Ingredient>(), 
																					 ""){
	}


	public void AddIngredient(Ingredient ingredient) {
		Debug.Log("Adding " + ingredient.NameText);
		ingredients.Add(ingredient);
		typeCounts[(int)ingredient.Type] += 1;
		ingredientCounts[(int)ingredient.Name] += 1;
	}

	public int TypeCount(IngredientType type) {
		return typeCounts[(int)type];
	}

	// Counts all milk types together
	public string RecipeBookText() {
		string output = name + "\n";
		foreach(IngredientName ingredientName in IngredientName.GetValues(typeof(IngredientName))) {
			Ingredient tempIngredient = new Ingredient(ingredientName);
			int ingredientCount = ingredientCounts[(int)ingredientName];
			if(ingredientCount > 0) {
				output += "- " + tempIngredient.NameText;
				if(ingredientCount > 1) {
					output += " x " + ingredientCount;
				}
				output += "\n";
			}
		}
		output += "- " + container.GetTemperatureText(); 
		return output;
	}

	// Prints out all amounts of all ingredients (probably just for debugging)
	public string SpecificRecipeText() {
		string output = name + "\n";
		foreach(IngredientName ingredientName in IngredientName.GetValues(typeof(IngredientName))) {
			Ingredient tempIngredient = new Ingredient(ingredientName);
			int ingredientCount = ingredientCounts[(int)ingredientName];
			if(ingredientCount > 0) {
				output += "- " + tempIngredient.NameText;
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
