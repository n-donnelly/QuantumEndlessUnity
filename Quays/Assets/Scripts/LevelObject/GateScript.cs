using UnityEngine;
using System.Collections;

public class GateScript : LevelObject {

	public override void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject == photon) {
			photon.GetComponent<PlayerController>().TransitionColor (renderer.color);
		}
	}

	protected override void LvlObjUpdate() {
		return;
	}

	protected override void LvlObjAwake(){
		return;
	}
}
