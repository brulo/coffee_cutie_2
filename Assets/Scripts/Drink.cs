using UnityEngine;
using System.Collections;
using System.Text.RegularExpressions;
using System.Linq;

public class Drink : MonoBehaviour {
	Cup cup;	
	int[] milkCounts;
	int[] syrupCounts;

	void Start() {
		cup = Cup.NoCup;

		milkCounts = new int[Milk.GetValues(typeof(Milk)).Length];
		syrupCounts = new int[Syrup.GetValues(typeof(Syrup)).Length];
		for(int i = 0; i < milkCounts.Length; i++)
			milkCounts[i] = 0;
		for(int i = 0; i < syrupCounts.Length; i++)
			syrupCounts[i] = 0;
	}

	public void AddIngredient(Cup theCup) {
		if(cup == Cup.NoCup) {
			Debug.Log("Adding cup to drink");
			cup = theCup;
		}
		else {
			Debug.Log("Drink already has a cup");
		}
	}

	public void AddIngredient(Milk theMilk) {
		Debug.Log("Adding milk to drink");
		milkCounts[(int)theMilk] += 1;
		string name = SpaceCamelCase(theMilk.ToString());
		/* Debug.Log(name +": "+milkCounts[(int)theMilk]); */
		PrintContents();
	}

	public void AddIngredient(Syrup theSyrup) {
		Debug.Log("Adding syrup to drink");
		Debug.Log(theSyrup.ToString());
		syrupCounts[(int)theSyrup] += 1;
	}

	public void PrintContents() {
		Debug.Log("Drink Contents");
		foreach(Milk milk in Milk.GetValues(typeof(Milk))) { 
			if(milkCounts[(int)milk] > 0) { 
				string milkName = SpaceCamelCase(milk.ToString());
				if(milkCounts[(int)milk] == 1) {
					Debug.Log("- " + milkName);
				}
				else {
					Debug.Log("- " + milkName + " x " + milkCounts[(int)milk]);
				}
			}
		}
	}

	public string SpaceCamelCase(string input) {
		return Regex.Replace(input, "(\\B[A-Z])", " $1");
	}
}
