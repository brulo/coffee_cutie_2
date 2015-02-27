using UnityEngine;
using System.Collections;

public class DrinkForCustomer : MonoBehaviour {
	public ContainerName containerName;
	public string name;
	public Drink drink;

	void Start() {
		drink = new Drink(containerName, name);
	}
}
