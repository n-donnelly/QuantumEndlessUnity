using UnityEngine;
using System.Collections;

public class ObjectSpawner : MonoBehaviour {

	float timeSinceLastSpawn;
	public int spawnThreshold = 24;
	public int patternIndex = 0;
	public int childCount;

    public GameManager gameManager;

	Color[] colors;

	// Use this for initialization
	void Start () {
		timeSinceLastSpawn = 0f;
		colors = new Color[] {new Color(255f,0f,0f), new Color(0f, 255f, 0f), new Color(0f,0f,255f)};
		childCount = transform.childCount;
	}
	
	// Update is called once per frame
	void Update () {
	
		timeSinceLastSpawn += GameManager.gameSpeed * Time.deltaTime;

		if (timeSinceLastSpawn > spawnThreshold) {
			timeSinceLastSpawn = 0f;

			patternIndex = Random.Range (0, (transform.childCount-1));

			bool tryingChild = true;

			do {
				Transform child = transform.GetChild(patternIndex);
				if(child != null && !(child.GetComponent<PatternManager>().isRunning())) {
					tryingChild = false;

					Color[] objColors = new Color[3];
					objColors[0] = colors[Random.Range(0,colors.Length)];
					objColors[1] = colors[Random.Range(0,colors.Length)];
					objColors[2] = colors[Random.Range(0,colors.Length)];

					child.GetComponent<PatternManager>().Activate(objColors, gameManager);
				} else patternIndex++;
			} while (tryingChild && patternIndex < transform.childCount );
		}

	}
}
