using System.Text.RegularExpressions;
using UnityEngine;

public class Ingredient {
	private IngredientType type;
	private IngredientName name;
	private string typeText;
	private string nameText;
	public IngredientType Type { get { return type; } }
	public IngredientName Name { get { return name; } }
	public string TypeText { get { return typeText; } }
	public string NameText { get { return nameText; } }
	private bool isSingular = false;
	public bool IsSingular { get { return isSingular; } }

	// Create specific ingredient.
	public Ingredient(IngredientName n) {
		name = n;
		// Determine Type
		if((int)name >= (int)IngredientName.TwoPercentMilk &
			 (int)name <= (int)IngredientName.SoyMilk) {
			type = IngredientType.Milk;
		}
		else if((int)name >= (int)IngredientName.VanillaSyrup &
			      (int)name <= (int)IngredientName.MochaSyrup) { 
			type = IngredientType.Syrup;
		}
		else if((int)name >= (int)IngredientName.HotCup &
						(int)name <= (int)IngredientName.EspressoCup) {
			type = IngredientType.Cup;
			isSingular = true;
		}
		else if((int)name >= (int)IngredientName.Coffee &
						(int)name <= (int)IngredientName.Espresso) {
			type = IngredientType.Coffee;
		}
		else if((int)name >= (int)IngredientName.Ice &
						(int)name <= (int)IngredientName.Lid) {
			type = IngredientType.Cold;
			isSingular = true;
		}
		else if((int)name == (int)IngredientName.Cuff) {
			type = IngredientType.Hot;
			isSingular = true;
		}
		else if((int)name >= (int)IngredientName.SteamedTwoPercentMilk &
						(int)name <= (int)IngredientName.SteamedSoyMilk) {
			type = IngredientType.SteamedMilk;
			isSingular = true;
		}

		nameText = SpaceCamelCase(Name.ToString());
		typeText = SpaceCamelCase(Type.ToString());
	}

	// Given an ingredient type, get a random ingredient of that type.
	public Ingredient(IngredientType t) {
		type = t;
		if(t == IngredientType.Milk) {
			name = (IngredientName)Random.Range((int)IngredientName.TwoPercentMilk,
					(int)IngredientName.SoyMilk);
		}
		else if (t == IngredientType.Syrup) {
			name = (IngredientName)Random.Range((int)IngredientName.VanillaSyrup,
					(int)IngredientName.MochaSyrup);
		}
		else if (t == IngredientType.Cup) {
			name = (IngredientName)Random.Range((int)IngredientName.HotCup,
					(int)IngredientName.ColdCup);
			isSingular = true;
		}
		else if (t == IngredientType.Coffee) {
			name = (IngredientName)Random.Range((int)IngredientName.Coffee,
					(int)IngredientName.Espresso);
		}
		else if (t == IngredientType.Cold) {
			name = (IngredientName)Random.Range((int)IngredientName.Ice,
					(int)IngredientName.Lid);
			isSingular = true;
		}
		else if (t == IngredientType.Hot) {
			name = IngredientName.Cuff;
			isSingular = true;
		}
		else if (t == IngredientType.SteamedMilk) {
			name = (IngredientName)Random.Range((int)IngredientName.SteamedTwoPercentMilk,
					(int)IngredientName.SteamedSoyMilk);
			isSingular = true;
		}

		nameText = SpaceCamelCase(Name.ToString());
		typeText = SpaceCamelCase(Type.ToString());
	}

	private string SpaceCamelCase(string input) {
		// thanks, internet
		return Regex.Replace(input, "(\\B[A-Z])", " $1");
	}
}

public enum IngredientType {
	Milk,
	Syrup,
	Cup,
	Coffee,
	Cold,
	Hot,
	SteamedMilk
}

public enum IngredientName {
	TwoPercentMilk, NonFatMilk, SoyMilk,
	VanillaSyrup, MochaSyrup,
	HotCup, ColdCup, EspressoCup,
	Coffee, Espresso,
	Ice, Lid, 
	Cuff, 
	SteamedTwoPercentMilk, SteamedNonFatMilk, SteamedSoyMilk
}
