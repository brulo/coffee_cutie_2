using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CashRegister : MonoBehaviour {
	public Text moneyAmount;

	void Start() {
		moneyAmount.text = "$0";
	}

	public void SetMoneyAmount(int amount) {
		moneyAmount.text = "$" + amount;
	}

}
