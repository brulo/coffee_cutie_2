using System.Collections;
using System.Collections.Generic;

public class Recipes {
	public Drink GlassOfMilk { 
		get {
			Ingredient cup = new Ingredient(IngredientName.ColdCup);
			List<Ingredient> ingredients = new List<Ingredient>();
			ingredients.Add(new Ingredient(IngredientType.Milk)); 
			Drink drink = new Drink(cup,
															ingredients,
															"Glass of Milk");
			return drink;
		}
	}

	public string GlassOfMilkText {
		get {
			string text = "";
			text += "Glass Of Milk";
			text += "";
			text += "- Cold cup";
			text += "- Milk";
			return text;
		}
	}

	public Drink GlassOfSyrup { 
		get {
			Ingredient cup = new Ingredient(IngredientName.ColdCup);
			List<Ingredient> ingredients = new List<Ingredient>();
			ingredients.Add(new Ingredient(IngredientType.Syrup)); 
			Drink drink = new Drink(cup,
															ingredients,
															"Glass of Syrup?");
			return drink;
		}
	}

	public string GlassOfSyrupText {
		get {
			string text = "";
			text += "Glass Of Syrup?";
			text += "";
			text += "- Cold cup";
			text += "- Syrup";
			return text;
		}
	}
}
