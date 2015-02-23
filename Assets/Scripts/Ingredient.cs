public struct Ingredient {
	public IngredientType Type;
	public int ingredientIndex;

	public Ingredient(IngredientType type, int ingredientIdx) { 
		Type = type;
		ingredientIndex = ingredientIdx;
	}
}

public enum IngredientType {
	Milk, 
	Syrup,
	Cup
}

public enum MilkType { 
	MilkTwoPercent, MilkSoy, MilkNonFat,
	Count
}

public enum SyrupType {
	SyrupPlain, SyrupVanilla, SyrupMocha,
	Count
}

public enum CupType {
	HotForHere, HotToGo,
	ColdForHere, ColdToGo,
	None,
	Count
}

/* public enum IngredientSubtype { */	
/* 	MilkTwoPercent, MilkSoy, MilkNonFat, */
/* 	SyrupPlain, SyrupVanilla, SyrupMocha, */
/* 	HotToGo, HotForHere, ColdToGo, ColdForHere, */
/* 	None */
/* } */

