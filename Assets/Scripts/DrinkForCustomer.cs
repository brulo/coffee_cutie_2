using UnityEngine;
using System.Collections;

public class DrinkForCustomer : MonoBehaviour {
	public ContainerName containerName;
	public string drinkName;
	public Drink drink;

	void Start() {
		drink = new Drink(containerName, drinkName);
	}
}
