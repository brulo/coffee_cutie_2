using UnityEngine;
using System.Collections;

public class Drink : MonoBehaviour {
	int[] ingredients;
	int cupType;	
	int[] milkCounts;
	int[] syrupCounts;

	void Start() {
		cupType = (int)CupType.None;
		milkCounts = new int[(int)MilkType.Count];
		syrupCounts = new int[(int)SyrupType.Count];
		for(int i = 0; i < milkCounts.Length; i++)
			milkCounts[i] = 0;
		for(int i = 0; i < syrupCounts.Length; i++)
			syrupCounts[i] = 0;
	}

	public void AddIngredient(Ingredient ingredient) {
		if(ingredient.Type == IngredientType.Cup){
			if(cupType == (int)CupType.None) {
				Debug.Log("Adding cup to drink");
				cupType = (int)ingredient.ingredientIndex;
			}
			else {
				Debug.Log("Drink already has a cup");
			}
		}
		else if(ingredient.Type == IngredientType.Milk) {
			Debug.Log("Adding milk to drink");
			milkCounts[(int)ingredient.ingredientIndex] += 1;
			Debug.Log(milkCounts[(int)ingredient.ingredientIndex]);
		}
		else if(ingredient.Type == IngredientType.Syrup) {
			Debug.Log("Adding syrup to drink");
			syrupCounts[(int)ingredient.ingredientIndex] += 1;
		}
	}
	
}
