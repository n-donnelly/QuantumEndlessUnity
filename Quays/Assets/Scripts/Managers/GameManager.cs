using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public static float gameSpeed;

	public GameOverManager gameOverManager;
	public PlayerController playerController;
    public ScoreManager scoreManager;
	public float speedUp;

	// Use this for initialization
	void Awake () {

        ResetSpeed();
		speedUp = 0.05f;

	}

	void FixedUpdate() {
		gameSpeed += speedUp * Time.fixedDeltaTime;

		if (playerController.gameOver) {
			gameOverManager.triggerGameOver ();
			gameSpeed = 0f;
		}
	}

	public void ResetGame() {
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex, LoadSceneMode.Single);
	}

    public void GemPickUp(Color c)
    {
        scoreManager.IncreaseScore();
    }

    public void ResetSpeed()
    {
        gameSpeed = 4f;
    }

}
