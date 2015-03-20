using UnityEngine;
using System.Collections;

public class StationaryDispenser : MonoBehaviour {
	public Droplet dropletPrefab;
	public Ingredient ingredient;
	public IngredientName ingredientName;
	public Vector3 spawnOffset = new Vector3(0, 0, 0);

	protected virtual void Start() {
		ingredient = new Ingredient(ingredientName);
	}	

	public void Dispense() {
		Vector3 spawnPosition = spawnOffset + gameObject.transform.position;
		Droplet droplet = Instantiate(dropletPrefab, spawnPosition, Quaternion.identity) as Droplet;
		droplet.ingredient = ingredient;
	}
}
