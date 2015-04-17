using UnityEngine;
using System.Collections;

public class DrinkForCustomer : MonoBehaviour {
	public Drink drink;
	public IngredientName cup;
	public int ingredientLimit = 0;

	void Start() {
		drink = new Drink(new Ingredient(cup), ingredientLimit);
	}
}
