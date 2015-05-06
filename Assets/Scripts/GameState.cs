using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameState : MonoBehaviour {
	public GameStates gameState;
	private int score = 0;
	public int Score { get { return score; } }
	private CashRegister cashRegister;
	private Clock clock;
	public GameObject endRoundScreen;

	void Start() {
		gameState = GameStates.playing;

		clock = GameObject.Find("Clock").GetComponent<Clock>();
		clock.StartClock(180f);
		cashRegister = GameObject.Find("Cash Register").GetComponent<CashRegister>();
	}

	public void AddToScore(int amount) {
		score += amount;
		cashRegister.SetMoneyAmount(score);
	}

	public void StartNewRound() {
		Application.LoadLevel(0);
	}

	public void EndRound() {
		// freeze time
		Time.timeScale = 0;

		GameObject round = GameObject.Find("Round");
		// disable all gui elements
		Component[] selectables = round.GetComponents<Selectable>();
		foreach(Selectable selectable in selectables) {
			selectable.enabled = false;
		}
		// disable all colliders
		Component[] cols = round.GetComponentsInChildren<Collider2D>();
		foreach(Collider2D col in cols) {
			col.enabled = false;
		}
		// show end screen
		endRoundScreen.SetActive(true);
		GameObject.Find("End Round Score").GetComponent<Text>().text = score + "";
	}
		
	public void setGameState(GameStates newGameState) {
		if(newGameState == GameStates.playing) {
			if(this.gameState == GameStates.paused) {
			}
			else if(this.gameState == GameStates.titleScreen) {
			}
		}
		else if(newGameState == GameStates.paused) {
			if(this.gameState == GameStates.playing) {
			}
			else if(this.gameState == GameStates.titleScreen) {
			}
		}
		else if(newGameState == GameStates.titleScreen) {
			if(this.gameState == GameStates.playing) {
			}
			else if(this.gameState == GameStates.paused) {
			}
		}
		this.gameState = gameState;
	}
}

public enum GameStates {
	titleScreen, playing, paused
}
