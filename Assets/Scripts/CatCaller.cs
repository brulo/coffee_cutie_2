using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CatCaller : MonoBehaviour {
	private string[] script;
	private int scriptIdx = -1;
	Text catCallerText;

	void Start() {
		Transform speechBubbleText = transform.Find("Cat Caller Text");
		catCallerText = speechBubbleText.GetComponent<Text>();
		// Set x position based on current screen.
		Vector2 screen0Range = new Vector2(-4.33f, 6f);
		Vector2 screen1Range = new Vector2(11.02f, 19.27f);
		float yPos = 0f;
		float xPos;
		GameObject camera = GameObject.Find("Main Camera");
		if(camera.GetComponent<CameraHandler>().CurrentScreen == 0) {
			xPos = Random.Range(screen0Range.x, screen0Range.y);
		}
		else {
			xPos = Random.Range(screen1Range.x, screen1Range.y);
		}
		Vector3 newPosition = gameObject.transform.position;
		newPosition.x = xPos;
		gameObject.transform.position = newPosition;
		// pick a catcall script.
		string[][] scripts = new string[][] {
			new string[] {
				"Hey, sweetheart!",
				"What, you can't talk to me?",
				"I'm a paying customer. This is bad service.",
				"Stuck up bitch."
			},
			new string[] {
				"How old are you?",
				"I forgot where I live.",
				"When do you get off work? Could you walk me home?",
				"I don't know very many girls your age anymore.",
				"I've got a real big tip for you if you can make my drink the way I like it.",
				"I bet I seem like an old man to you.",
				"Y'know, I could teach you a few things.",
				"See ya tomorrow, sweetheart."
			},
			new string[] {
				"Working hard back there?",
				"I bet you're pretty tough, huh. I like that."
			},	
			new string[] {
				"It's too bad that aprons so long...",
				"Do you have a boyfriend? Doesn't he buy you any cute clothes?",
				"You don't want to be a barista forever, do you?",
				"Don't worry, a pretty girl like you, somebody's gonna take care of you."
			},
			new string[] {
				"Why don't you smile?",
				"You'd be prettier if you smiled.",
				"You think that face looks cute?",
				"I can tell you think you're really pretty but you're not."
			}
		};
		script = scripts[Random.Range(0, scripts.Length)];
		AdvanceDialog();
	}

	void OnMouseUp() { 
		AdvanceDialog();
	}

	void AdvanceDialog() {
		scriptIdx++;
		if(scriptIdx < script.Length) {
			catCallerText.text = script[scriptIdx];
		}
		else { 
			Destroy(this.gameObject);
		}
	}

}	
