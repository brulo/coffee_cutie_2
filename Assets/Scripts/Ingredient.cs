using System.Text.RegularExpressions;
using UnityEngine;

public class Ingredient {
	private IngredientType type;
	private IngredientName name;
	public IngredientType Type { get { return type; } }
	public IngredientName Name { get { return name; } }


	// Create specific ingredient.
	public Ingredient(IngredientName n) {
		name = n;
		// Determine Type
		if((int)name <= (int)IngredientName.SoyMilk)
			type = IngredientType.Milk;
		else if((int) name >= (int)IngredientName.RegularSyrup) { 
			if((int)name <= (int)IngredientName.MochaSyrup) {
				type = IngredientType.Syrup;
			}
		}
	}

	// Given an ingredient type, get a random ingredient of that type.
	public Ingredient(IngredientType t) {
		type = t;
		if(t == IngredientType.Milk) {
			name = (IngredientName)Random.Range((int)IngredientName.TwoPercentMilk,
																					(int)IngredientName.SoyMilk);
		}
		else if (t == IngredientType.Syrup) {
			name = (IngredientName)Random.Range((int)IngredientName.RegularSyrup,
																					(int)IngredientName.MochaSyrup);
		}
	}
	
	public string GetTypeText() {
		return Type.ToString();
	}

	public string GetNameText() {
		return SpaceCamelCase(Name.ToString());
	}

	private string SpaceCamelCase(string input) {
		return Regex.Replace(input, "(\\B[A-Z])", " $1");
	}
}

public enum IngredientType {
	Milk,
	Syrup,
}

public enum IngredientName {
	TwoPercentMilk, NonFatMilk, SoyMilk,
	RegularSyrup, VanillaSyrup, MochaSyrup
}
