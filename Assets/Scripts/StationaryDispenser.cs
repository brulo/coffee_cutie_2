using UnityEngine;
using System.Collections;

public class StationaryDispenser : MonoBehaviour {
	public Droplet dropletPrefab;
	public Ingredient ingredient;
	public IngredientName ingredientName;
	public Vector3 spawnOffset = new Vector3(0f, 0f, 0f);

	protected virtual void Start() {
		ingredient = new Ingredient(ingredientName);
	}	

	public void Dispense() {
		Debug.Log("Dispensing droplet");
		Vector3 spawnPosition = spawnOffset + gameObject.transform.position;
		Droplet droplet = Instantiate(dropletPrefab, spawnPosition, Quaternion.identity) as Droplet;
		Physics2D.IgnoreCollision(droplet.GetComponent<Collider2D>(), 
															GetComponent<Collider2D>());
		droplet.ingredient = ingredient;
	}
}
