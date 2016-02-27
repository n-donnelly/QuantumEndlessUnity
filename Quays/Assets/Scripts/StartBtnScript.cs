using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StartBtnScript : MonoBehaviour {

	public void OnStartClicked(){
		SceneManager.LoadScene (1, LoadSceneMode.Single);
	}
}
