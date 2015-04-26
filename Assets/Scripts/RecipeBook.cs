using UnityEngine;
using System.Collections;

public class RecipeBook {
	private Recipe[] allRecipes = new Recipe[] {
		glassOfMilk, chocolateMilk, sweetMilk
	};
	public Recipe[] AllRecipes { 
		get { return allRecipes; } 
	}
	public Recipe RandomRecipe {
		get { 
			return allRecipes[Random.Range(0, allRecipes.Length)]; 
		} 
	}

	public static Recipe glassOfMilk = new Recipe("Glass of Milk",
			IngredientName.ColdCup,
			new IngredientType[] {
				IngredientType.Milk 
			},
			new IngredientName[] {
			}
	);

	public static Recipe chocolateMilk = new Recipe("Chocolate Milk",
			IngredientName.ColdCup,
			new IngredientType[] {
				IngredientType.Milk 
			},
			new IngredientName[] {
				IngredientName.MochaSyrup
			}
	);

	public static Recipe sweetMilk = new Recipe("Sweet Milk",
			IngredientName.ColdCup,
			new IngredientType[] {
				IngredientType.Milk 
			},
			new IngredientName[] {
				IngredientName.RegularSyrup
			}
	);
}
