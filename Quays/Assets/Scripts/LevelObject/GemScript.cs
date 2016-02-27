using UnityEngine;
using System.Collections;

public class GemScript : LevelObject {

	float rotSpeed;
	public float maxRotSpeed = 15f;
	public float minRotSpeed = 2f;

	protected override void LvlObjUpdate(){
		transform.Rotate (0, 0, rotSpeed * Time.deltaTime);
	}

	protected override void LvlObjAwake(){
		rotSpeed = Random.Range (minRotSpeed, maxRotSpeed);
	}

	public override void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject == photon) {

			if (photon.GetComponent<PlayerController> ().GetColor () == renderer.color)
				ScoreManager.score++;
			else {
				Debug.Log ("Game over should be triggered");
				photon.GetComponent<PlayerController> ().SetGameOver ();
			}

			Destroy ();
		}
	}

}
