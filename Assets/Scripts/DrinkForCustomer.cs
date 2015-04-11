using UnityEngine;
using System.Collections;

public class DrinkForCustomer : MonoBehaviour {
	public Drink drink;
	public IngredientName cup;

	void Start() {
		drink = new Drink(new Ingredient(cup));
	}
}
