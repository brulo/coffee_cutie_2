using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public class Recipe {
	string name;
	public string Name { get { return name; } }
	private int[] typeCounts;
	public int[] TypeCounts { get { return typeCounts; } }
	private int[] specificCounts;
	public Drink drink;
	public List<Ingredient> specificsForCustomerOrder;
	
	IngredientName cup;
	
	public Recipe(string name, 
								IngredientName cup, 
								IngredientType[] ingredientTypes,
								IngredientName[] specificIngredients) {
		this.name = name;
		this.cup = cup;

		// Initialize counting arrays.
		typeCounts = new int[IngredientType.GetValues(
				typeof(IngredientType)).Length];
		for(int i = 0; i < typeCounts.Length; i++) 
			typeCounts[i] = 0;
		specificCounts = new int[IngredientName.GetValues(
				typeof(IngredientName)).Length];
		for(int i = 0; i < specificCounts.Length; i++)
			specificCounts[i] = 0;

		// Count the types and specific ingredients.
		for(int i = 0; i < ingredientTypes.Length; i++)
			typeCounts[(int)ingredientTypes[i]] += 1;
		for(int i = 0; i < specificIngredients.Length; i++)
			specificCounts[(int)specificIngredients[i]] += 1;

		InitializeDrink();
	}

	public void InitializeDrink() {
		List<Ingredient> ingredients = new List<Ingredient>();
		specificsForCustomerOrder = new List<Ingredient>();

		foreach(IngredientType ingType in System.Enum.GetValues(
					typeof(IngredientType))) {
			Ingredient ing = new Ingredient(ingType);
			for(int i = 0; i < typeCounts[(int)ingType]; i++) {
				if(i == 0) {
					specificsForCustomerOrder.Add(ing);
				}
				ingredients.Add(ing);
			}
		}

		foreach(IngredientName ingName in System.Enum.GetValues(
					typeof(IngredientName))) {
			for(int i = 0; i < specificCounts[(int)ingName]; i++) {
				ingredients.Add(new Ingredient(ingName));
			}
		}

		drink = new Drink(new Ingredient(cup),
											ingredients,
											name);
	}

	public string RecipeBookText {
		get {
			string text = name + "\n\n";

			text += "- " + new Ingredient(cup).NameText + "\n";
			
			foreach(IngredientName ingName in System.Enum.GetValues(
						typeof(IngredientName))) {
				int specificCount = specificCounts[(int)ingName];
				if(specificCount > 0) {
						text += "- " + new Ingredient(ingName).NameText;
					if(specificCount > 1) 
						text += " x " + specificCount;
					text += "\n";
				}
			}

			foreach(IngredientType ingType in System.Enum.GetValues(
						typeof(IngredientType))) {
				int typeCount = typeCounts[(int)ingType];
				if(typeCount > 0) {
						text += "- " + new Ingredient(ingType).TypeText;
						if(typeCount > 1) 
							text += " x " + typeCount;
					text += "\n";
				}
			}

			return text;
		}
	}

}
