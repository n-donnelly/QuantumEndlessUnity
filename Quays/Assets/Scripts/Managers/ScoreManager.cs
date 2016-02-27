using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour {

	public static int score;

	Text scoreText;

	// Use this for initialization
	void Awake () {
	
		score = 0;
		scoreText = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {

		scoreText.text = "SCORE: " + score;
	}
}
