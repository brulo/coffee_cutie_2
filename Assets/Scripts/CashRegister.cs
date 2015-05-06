using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CashRegister : MonoBehaviour {
	public Text moneyAmount;
	private AudioSource audioSource;

	void Start() {
		audioSource = GetComponent<AudioSource>();
		moneyAmount.text = "$0";
	}

	public void SetMoneyAmount(int amount) {
		moneyAmount.text = "$" + amount;
		audioSource.Play();
	}

}
