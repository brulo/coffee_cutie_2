using UnityEngine;
using System.Collections;

public class GameState : MonoBehaviour {
	public GameStates gameState;
	private int score = 0;
	public int Score { get { return score; } }
	private CashRegister cashRegister;

	void Start() {
		gameState = GameStates.playing;
		cashRegister = GameObject.Find("Cash Register").GetComponent<CashRegister>();
	}

	public void AddToScore(int amount) {
		score += amount;
		cashRegister.SetMoneyAmount(score);
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
