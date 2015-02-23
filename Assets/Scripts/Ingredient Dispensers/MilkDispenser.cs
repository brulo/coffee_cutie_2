using UnityEngine;
using System.Collections;
using System;

public class MilkDispenser : MonoBehaviour {
	IngredientType Type;
	public MilkType milkType;
	Ingredient ingredient;

	Drink drink;

	void Start() {
		Type = IngredientType.Milk;
		ingredient = new Ingredient(Type, (int)milkType);

		drink = gameObject.GetComponent<Drink>();
	}

	void OnMouseDown() {
	 drink.AddIngredient(ingredient);	
	}

}
