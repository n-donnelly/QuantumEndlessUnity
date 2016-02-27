using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StartButtonScript : MonoBehaviour {

	public void OnStartClicked(){
		SceneManager.LoadScene (1, LoadSceneMode.Single);
	}
}