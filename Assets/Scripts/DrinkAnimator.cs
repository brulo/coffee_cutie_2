using UnityEngine;
using System.Collections;

public class DrinkAnimator : MonoBehaviour {
	public Sprite milkFoam;

	public Sprite milkOne;
	public Sprite milkTwo;
	public Sprite milkThree;

	public Sprite latteOne;
	public Sprite latteTwo;
	public Sprite latteThree;

	public Sprite mochaOne;
	public Sprite mochaTwo;
	public Sprite mochaThree;

	public Sprite coffeeOne;
	public Sprite coffeeTwo;
	public Sprite coffeeThree;

	public SpriteRenderer liquidRenderer;
	public SpriteRenderer foamRenderer;
	/* private Drink drink; */

	void Start() {
		/* drink = GetComponent<DrinkForCustomer>().drink; */
		liquidRenderer.sortingLayerName = "Drink Liquid";
		foamRenderer.sortingLayerName = "Drink Foam";
	}

	public void UpdateRenderer() { 
		Drink drink = GetComponent<DrinkForCustomer>().drink;

		int numCoffee = drink.IngredientTypeCounts[(int)IngredientType.Coffee];
		int numMilk = drink.IngredientTypeCounts[(int)IngredientType.Milk];
		int numLiquids = numMilk + numCoffee;

		int numMocha = drink.IngredientNameCounts[(int)IngredientName.MochaSyrup];
		if(numLiquids > 0 ) {
			if(numLiquids == 1) {
				if(numCoffee > 0) {
					if(numMocha > 0) {
						liquidRenderer.sprite = mochaOne;
					}
					else {
						liquidRenderer.sprite = coffeeOne;
					}
				}
				if(numMilk > 0) {
					if(numMocha > 0) {
						liquidRenderer.sprite = mochaOne;
					}
					else {
						liquidRenderer.sprite = milkOne;
					}
				}
			}
			if(numLiquids == 2) {
				if(numCoffee == 2 & numMilk == 0) {
					if(numMocha > 0) {
						liquidRenderer.sprite = mochaTwo;
					}
					else {
						liquidRenderer.sprite = coffeeTwo;
					}
				}
				else if(numMilk == 1 & numCoffee == 1) {
					if(numMocha > 0) {
						liquidRenderer.sprite = mochaTwo;
					}
					else {
						liquidRenderer.sprite = latteTwo;
					}
				}
				else if (numMilk == 2) {
					if(numMocha > 0) {
						liquidRenderer.sprite = mochaTwo;
					}
					else {
						liquidRenderer.sprite = milkTwo;
					}
				}
			}
			else { // more than 2 liquids
				if(numCoffee > 2 & numMilk == 0) {
					if(numMocha > 0) {
						liquidRenderer.sprite = mochaThree;
					}
					else {
						liquidRenderer.sprite = coffeeThree;
					}
				}
				else if(numCoffee > 0 & numMilk > 0) {
					if(numMocha > 0) {
						liquidRenderer.sprite = mochaThree;
					}
					else {
						liquidRenderer.sprite = latteThree;
					}
				}
				else if(numMilk > 2) {
					if(numMocha > 0) {
						liquidRenderer.sprite = mochaThree;
					}
					else {
						liquidRenderer.sprite = milkThree;
					}
				}
			}
		}
		else {
			/* liquidRenderer.enabled = false; */
		}
	}
}
