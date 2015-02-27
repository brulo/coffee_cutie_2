using System.Text.RegularExpressions;

public class Ingredient {
	public IngredientType Type;
	public IngredientName Name;

	public Ingredient(IngredientName name) {
		Name = name;
		// Determine Type
		if((int)name <= (int)IngredientName.SoyMilk)
			Type = IngredientType.Milk;
		else
			Type = IngredientType.Syrup;
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
	Syrup
}

public enum IngredientName {
	TwoPercentMilk, NonFatMilk, SoyMilk,
	RegularSyrup, VanillaSyrup, MochaSyrup
}
