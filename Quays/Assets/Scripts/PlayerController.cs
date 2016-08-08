using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	public float speed = 10f;

	Vector2 movement;
	Rigidbody2D body;
	SpriteRenderer rend;
	public Text DebugText;
	public bool gameOver = false;

	float height;

	void Awake()
	{
		body = GetComponent<Rigidbody2D> ();
		rend = GetComponent<SpriteRenderer> ();
		height = rend.bounds.size.y;
        rend.color = new Color(255f, 0f, 0f);
	}
		
	// Update is called once per frame
	void Update () {

		if (gameOver)
			return;

		float v = transform.position.y;

#if UNITY_STANDALONE || UNITY_WEBPLAYER

		v = Input.GetAxisRaw ("Vertical");
        movement.Set (0f, v);

		movement = movement.normalized * speed * Time.deltaTime;
		Vector2 newPos = (Vector2)transform.position + (Vector2)movement;
		Vector2 newnew = new Vector2(newPos.x, ((newPos.y < (height/2-5) || newPos.y > (5-height/2)) ? transform.position.y : newPos.y));
		Debug.Log("Photon pos: " + newnew);
		body.MovePosition (newnew);

		#elif UNITY_IOS || UNITY_ANDROID || UNITY_WP8 || UNITY_IPHONE

		transform.position = new Vector2(-6, transform.position.y);

		if(Input.touchCount > 0)
		{
			Touch myTouch = Input.GetTouch(0);
			Vector3 touchPosition = myTouch.position;
			touchPosition.z = 100;
			Vector2 worldPosition = Camera.main.ScreenToWorldPoint(myTouch.position);

			Vector3 tempPos = Vector3.Lerp(transform.position, worldPosition, speed * Time.deltaTime);
			transform.position = new Vector2(transform.position.x, tempPos.y);
			Debug.Log("Position x: " + transform.position.x + " || y: " + transform.position.y);
		}

		#endif
	}

	public void SetColor(Color col) {
		rend.color = col;
	}

	public Color GetColor() {
		return rend.color;
	}

	public void TransitionColor(Color newCol){
		SetColor (newCol);
	}

	public void SetGameOver() {
		gameOver = true;
	}
    
}
