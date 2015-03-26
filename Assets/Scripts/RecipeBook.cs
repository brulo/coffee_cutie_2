using System.Collections;

public class RecipeBook {

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
}
