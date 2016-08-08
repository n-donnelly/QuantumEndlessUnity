using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour {

	private int score;
    private int multiplier;

	Text scoreText;

	// Use this for initialization
	void Awake () {
	
		score = 0;
        multiplier = 1;
		scoreText = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {

		scoreText.text = "SCORE: " + score;
	}

    public void ResetMultiplier ()
    {
        multiplier = 1;
    }

    public void IncreaseScore()
    {
        score += multiplier;
        if (score % 10 == 0)
            multiplier *= 2;
    }
}
