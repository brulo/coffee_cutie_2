using UnityEngine;
using System.Collections;

public class StationaryDispenser : MonoBehaviour {
	public Droplet dropletPrefab;
	public Ingredient ingredient;
	public IngredientName ingredientName;

	protected virtual void Start() {
		ingredient = new Ingredient(ingredientName);
	}	

	public void Dispense() {
		Droplet droplet = Instantiate(dropletPrefab, gameObject.transform.position, Quaternion.identity) as Droplet;
		droplet.ingredient = ingredient;
	}
}
