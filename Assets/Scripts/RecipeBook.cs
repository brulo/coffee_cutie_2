using UnityEngine;
using System.Collections;

public class RecipeBook {
	private Recipe[] allRecipes = new Recipe[] {
		glassOfMilk, chocolateMilk, 
		hotVanillaLatte, coldVanillaLatte, 
		hotMochaLatte, coldMochaLatte,
		largeCoffeeWithMilk, largeCoffee,
		icedCoffeeWithMilk, icedCoffee,
		doubleEspresso
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
				IngredientType.Milk, IngredientType.Milk, IngredientType.Milk 
			},
			new IngredientName[] {
			}
	);

	public static Recipe chocolateMilk = new Recipe("Chocolate Milk",
			IngredientName.ColdCup,
			new IngredientType[] {
				IngredientType.Milk, IngredientType.Milk, IngredientType.Milk 
			},
			new IngredientName[] {
				IngredientName.MochaSyrup
			}
	);


	public static Recipe hotVanillaLatte = new Recipe("Hot Vanilla Latte",
			IngredientName.HotCup,
			new IngredientType[] {
				IngredientType.Milk 
			},
			new IngredientName[] {
				IngredientName.Espresso, IngredientName.Espresso, 
				IngredientName.VanillaSyrup 
			}
	);

	public static Recipe coldVanillaLatte = new Recipe("Cold Vanilla Latte",
			IngredientName.ColdCup,
			new IngredientType[] {
				IngredientType.Milk 
			},
			new IngredientName[] {
				IngredientName.Espresso, IngredientName.Espresso, 
				IngredientName.VanillaSyrup, IngredientName.Ice
			}
	);

	public static Recipe hotMochaLatte = new Recipe("Hot Mocha Latte",
			IngredientName.HotCup,
			new IngredientType[] {
				IngredientType.Milk 
			},
			new IngredientName[] {
				IngredientName.Espresso, IngredientName.Espresso, 
				IngredientName.MochaSyrup
			}
	);

	public static Recipe coldMochaLatte = new Recipe("Cold Mocha Latte",
			IngredientName.ColdCup,
			new IngredientType[] {
				IngredientType.Milk 
			},
			new IngredientName[] {
				IngredientName.Espresso, IngredientName.Espresso, 
				IngredientName.MochaSyrup, IngredientName.Ice
			}
	);

	public static Recipe largeCoffee = new Recipe("Drip Coffee Without Milk",
			IngredientName.HotCup,
			new IngredientType[] {
			},
			new IngredientName[] {
				IngredientName.Coffee, IngredientName.Coffee, IngredientName.Coffee
			}
	);

	public static Recipe largeCoffeeWithMilk = new Recipe("Drip Coffee",
			IngredientName.HotCup,
			new IngredientType[] {
				IngredientType.Milk 
			},
			new IngredientName[] {
				IngredientName.Coffee, IngredientName.Coffee 
			}
	);

	public static Recipe icedCoffee = new Recipe("Iced Coffee Without Milk",
			IngredientName.ColdCup,
			new IngredientType[] {
			},
			new IngredientName[] {
				IngredientName.Coffee, IngredientName.Coffee, IngredientName.Coffee,
				IngredientName.Ice
			}
	);

	public static Recipe icedCoffeeWithMilk = new Recipe("Ice Coffee",
			IngredientName.ColdCup,
			new IngredientType[] {
				IngredientType.Milk 
			},
			new IngredientName[] {
				IngredientName.Coffee, IngredientName.Coffee, IngredientName.Coffee,
				IngredientName.Ice
			}
	);

	public static Recipe doubleEspresso = new Recipe("Double Espresso",
			IngredientName.HotCup,
			new IngredientType[] {
			},
			new IngredientName[] {
				IngredientName.Espresso, IngredientName.Espresso,
			}
	);
}
