using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PatternManager : MonoBehaviour {

	public bool running  = false;
	public float patternHeight;
	float hackedInHeight = 10f;
	float vertOffset = 0f;

	void Start() {
		float currentLowest = 100f;
		float currentHighest = -100f;

		foreach (Transform colObj in transform) {
			foreach (Transform child in colObj.transform) {
				LevelObject lvlObj = child.GetComponent<LevelObject> ();

				float objLow = lvlObj.transform.position.y - (lvlObj.GetComponent<Renderer> ().bounds.size.y / 2);
				float objHigh = lvlObj.transform.position.y + (lvlObj.GetComponent<Renderer> ().bounds.size.y / 2);

				if (currentLowest > objLow)
					currentLowest = objLow;

				if (currentHighest < objHigh)
					currentHighest = objHigh;
			}
		}
		patternHeight = currentHighest - currentLowest;
	}

	public void Activate(Color[] colors) {
		running = true;

		vertOffset = Random.Range (0f, hackedInHeight - patternHeight);
		Vector2 vec = new Vector2 (0, vertOffset);
		LevelObject currentLast = null;

		int colIndex = 0;
		foreach (Transform colObj in transform) {

			foreach (Transform child in colObj.transform) {
				LevelObject lvlObj = child.GetComponent<LevelObject> ();

				lvlObj.Activate (vec, colors[colIndex]);

				if (currentLast == null || currentLast.transform.position.x < lvlObj.transform.position.x)
					currentLast = lvlObj;
			}
			colIndex++;
		}
		if (currentLast == null)
			throw new MissingComponentException ("Pattern Manager couldn't find last LevelObject");
		else
			currentLast.Subscribe (this);
	}

	public void Finish() {
		running = false;
	}

	public bool isRunning(){
		return running;
	}
}
