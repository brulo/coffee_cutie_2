using UnityEngine;
using System.Collections;

public class Clock : MonoBehaviour {

	public float roundFullTime = 60f;
	public Sprite[] frames;
	SpriteRenderer renderer;
	int spriteStages;
	int currentFrame;
	float currentTime;
	float timeStep;
	/* private AudioSource soundPlayer; */
	/* public AudioClip bellSound; */
	public bool stopped;

	/* public RoundControllerScript roundController; */
	public GameState gameState;

	void Start() {
		renderer = GetComponent<SpriteRenderer>();
		gameState = GameObject.Find("Game State").GetComponent<GameState>();
		/* soundPlayer = GetComponent<AudioSource> (); */
		spriteStages=frames.Length;
	}

	void Update () {
		if (!stopped) {
			currentTime -= Time.deltaTime;
			if (currentTime <= 0) {
				currentTime = timeStep;
				nextFrame ();	
				StartCoroutine(FlashClockSprite(1));
			}
		}
	}

	IEnumerator FlashClockSprite(int numFlashes) {
		for(int i = 0; i < numFlashes; i++) {
			renderer.material.color = Color.red;
			yield return new WaitForSeconds(0.25f);
			renderer.material.color = Color.white;
			yield return new WaitForSeconds(0.25f);
		}
	}

	void nextFrame() {
		currentFrame++;
		if (currentFrame >= spriteStages) {
			endOfClockReached();
		}
		else {
			renderer.sprite = frames [currentFrame];
		}
	}

	public void deductTime(int numFrames) {
		for(int i = 0; i < numFrames; i++) {
			nextFrame();
		}
		StartCoroutine(FlashClockSprite(3));
	}

	void endOfClockReached() {
		/* soundPlayer.PlayOneShot (bellSound, 0.7f); */
		currentFrame = 0;
		stopped = true;
		/* roundController.outOfTime (); */
		gameState.EndRound();
		StartCoroutine(FlashClockSprite(6));
		renderer.material.color = Color.red;
	}

	public void StartClock() {
		stopped = false;
		timeStep=roundFullTime/spriteStages;
		currentTime = timeStep;
		currentFrame = 0;
		renderer.sprite = frames [currentFrame];
	}
	
	public void StartClock(float newRoundTime) {
		roundFullTime=newRoundTime;
		StartClock();
	}
}
