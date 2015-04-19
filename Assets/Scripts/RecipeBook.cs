using System.Collections;

public class RecipeBook {
	private Recipe[] allRecipes = new Recipe[] {
		GlassOfMilk, GlassOfRegularSyrup 
	};
	public Recipe[] AllRecipes { get { return allRecipes; } }

	public static Recipe GlassOfMilk {
		get {
			IngredientName cup = IngredientName.ColdCup;

			IngredientType[] ingredientTypes = new IngredientType[] { 
				IngredientType.Milk 
			};

			IngredientName[] specificIngredients = new IngredientName[] { 
			};

			Recipe recipe = new Recipe("Glass of Milk",
																 cup,
																 ingredientTypes,
																 specificIngredients);
			return recipe;
		}
	}

	public static Recipe GlassOfRegularSyrup {
		get {
			IngredientName cup = IngredientName.ColdCup;

			IngredientType[] ingredientTypes = new IngredientType[] { 
			};

			IngredientName[] specificIngredients = new IngredientName[] { 
				IngredientName.RegularSyrup, IngredientName.RegularSyrup 
			};

			Recipe recipe = new Recipe("Glass of Syrup",
																 cup,
																 ingredientTypes,
																 specificIngredients);
			return recipe;
		}
	}
}
