using UnityEngine;
using System.Collections;
using System;

public class MilkDispenser : MonoBehaviour {

	public Milk milk;
	Drink drink;

	void Start() {
		drink = gameObject.GetComponent<Drink>();
	}

	void OnMouseDown() {
	 drink.AddIngredient(milk);	
	}

}
