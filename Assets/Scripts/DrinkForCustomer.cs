using UnityEngine;
using System.Collections;

public class DrinkForCustomer : MonoBehaviour {
	public Drink drink;

	void Start() {
		drink = new Drink(new Ingredient(IngredientType.Cup));
	}
}
