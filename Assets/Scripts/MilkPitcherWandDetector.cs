using UnityEngine;
using System.Collections;

public class MilkPitcherWandDetector : MonoBehaviour {
	private MilkPitcher milkPitcher;
	
	void Start() {
		milkPitcher = GameObject.Find("Steamed Milk Pitcher").GetComponent<MilkPitcher>();
	}

	void OnTriggerEnter2D(Collision2D col) {
		if(col.gameObject.tag == "Steam Wand") {
			milkPitcher.SteamMilk();
		}
	}
}
