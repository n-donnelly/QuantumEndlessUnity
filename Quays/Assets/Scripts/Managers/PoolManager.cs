using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PoolManager : MonoBehaviour {

	public GameObject pooledObject;

	public int objCount = 20;

	public bool willGrow = true;

	List<GameObject> objectPool;

	// Use this for initialization
	void Start () {

		objectPool = new List<GameObject> ();
		for (int i = 0; i < objCount; i++) {
			GameObject obj = (GameObject)Instantiate (pooledObject);
			obj.SetActive (false);
			objectPool.Add (obj);
		}

	}

	public GameObject getPooledObject() {

		for (int i = 0; i < objectPool.Count; i++) {
			if (!objectPool [i].activeInHierarchy) {
				return objectPool [i];
			}
		}

		if (willGrow) {
			GameObject obj = (GameObject)Instantiate (pooledObject);
			objectPool.Add (obj);
			return obj;
		}

		return null;
	}
}
