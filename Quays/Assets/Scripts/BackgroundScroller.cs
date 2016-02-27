using UnityEngine;
using System.Collections;

public class BackgroundScroller : MonoBehaviour {

	private Vector3 startPos;
	public float tileSizeZ;

	void Start() {
		startPos = transform.position;
	}

	// Update is called once per frame
	void Update () {
		float newPosition = Mathf.Repeat (Time.time * GameManager.gameSpeed*1.1f, tileSizeZ);
		transform.position = startPos + Vector3.left * newPosition;
			
	}
}
