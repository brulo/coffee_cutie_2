using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Drink {
	private List<Ingredient> ingredients = new List<Ingredient>();
	private Ingredient cup;
	private string name;
	private int ingredientLimit;
	public string Name { get { return name; } }

	public List<Ingredient> Ingredients {
		get {
			List<Ingredient> allIngredients = ingredients;
			allIngredients.Add(cup);
			return allIngredients;
		}
	}

	public int[] IngredientTypeCounts {
		get {
			int[] typeCounts = new int[IngredientType.GetValues(
					typeof(IngredientType)).Length];
			for(int i = 0; i < typeCounts.Length; i++) {
				typeCounts[i] = 0;
			}
			foreach(Ingredient ingredient in ingredients) { 
				typeCounts[(int)ingredient.Type] += 1;
			}
			return typeCounts;
		}
	}

	public int[] IngredientNameCounts {
		get {
			int[] nameCounts = new int[IngredientName.GetValues(
					typeof(IngredientName)).Length];
			for(int i = 0; i < nameCounts.Length; i++) {
				nameCounts[i] = 0;
			}
			foreach(Ingredient ingredient in ingredients) { 
				nameCounts[(int)ingredient.Name] += 1;
			}
			nameCounts[(int)cup.Name] += 1;
			return nameCounts;
		}
	}
	
	public Drink(Ingredient cup, 
							 List<Ingredient> ingredients,
							 string name,
							 int ingredientLimit) {
		this.cup = cup;
		foreach(Ingredient ingredient in ingredients) {
			AddIngredient(ingredient);
		}
		this.name = name;
		this.ingredientLimit = ingredientLimit;
	}
	
	public Drink(Ingredient cup, 
							 List<Ingredient> ingredients, 
							 string name) : this(cup, 
																	 ingredients, 
																	 name,
																	 0) {}

	public Drink(Ingredient cup, 
							 int ingredientLimit) : this(cup, 
																					 new List<Ingredient>(), 
																					 "",
																					 ingredientLimit) {}
	public Drink(Ingredient cup, 
							 string name) : this(cup, 
																	 new List<Ingredient>(), 
																	 name,
																	 0) {}

	public Drink(Ingredient cup) : this(cup, 
																		  new List<Ingredient>(), 
																		  "",
																			0) {}

	public void RemoveAllIngredients() {
		ingredients = new List<Ingredient>();
	}

	public void AddIngredient(Ingredient ingredient) {
		if(ingredientLimit > 0 && ingredients.Count > ingredientLimit) {
			Debug.Log("Can't add any more ingredients to drink!");
		}
		else {
			Debug.Log("Adding " + ingredient.NameText);
			ingredients.Add(ingredient);
		}
	}
}
