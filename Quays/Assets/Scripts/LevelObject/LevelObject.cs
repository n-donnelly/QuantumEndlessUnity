using UnityEngine;
using System.Collections;

public abstract class LevelObject : MonoBehaviour {

	public Vector2 objPosition;

	protected GameObject photon;
	protected new SpriteRenderer renderer;
	protected float height;
	protected Vector2 startPos;

	PatternManager patMgr;

	// Use this for initialization
	void Awake () {
		LvlObjAwake ();
		photon = GameObject.FindGameObjectWithTag ("Player");
		renderer = GetComponent<SpriteRenderer> ();
		renderer.color = new Color(0f,0f,0f);
		objPosition = transform.position;
		startPos = transform.position;
		height = renderer.bounds.size.y;
		gameObject.SetActive (false);
		patMgr = null;
	}

	// Update is called once per frame
	void Update () {
		LvlObjUpdate ();
		if (transform.position.x < -11) {
			Destroy ();
		}
		else {
			objPosition = (Vector2)transform.position + new Vector2( - (GameManager.gameSpeed * Time.deltaTime), 0);
			transform.position = objPosition;
		}
	}

	protected abstract void LvlObjUpdate ();
	protected abstract void LvlObjAwake ();

	public abstract void OnTriggerEnter2D (Collider2D other);

	public void SetColor(Color color) {
		renderer.color = color;
	}

	public void Subscribe(PatternManager pm) {
		patMgr = pm;
	}

	protected void Destroy() {
		gameObject.SetActive (false);
		if (patMgr != null)
			patMgr.Finish ();
	}

	public void Activate(Vector2 offset, Color col) {
		transform.position = (Vector2)startPos + (Vector2)offset;
		gameObject.SetActive (true);
		renderer.color = col;
	}
}
