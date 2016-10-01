using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public void LoadNextLevel() {
		// Simply load the next scene
		SceneManager.LoadScene( SceneManager.GetActiveScene().buildIndex + 1);
		// TODO Add limits check
	}


}
