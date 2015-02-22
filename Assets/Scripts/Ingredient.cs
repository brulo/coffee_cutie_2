using UnityEngine;
using System.Collections;

public class Ingredient : MonoBehaviour {
}

public enum IngredientType {	
	milkTwoPercent, milkSoy, milkNonFat,
	syrupPlain, syrupVanilla, syrupMocha,
	none
}

public enum MilkType { 
	milkTwoPercent, milkSoy, milkNonFat
}

public enum CupType {
	cupForHere, cupToGo
}
