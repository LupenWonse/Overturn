using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class TwoColorText : MonoBehaviour {

	public Text text1;
	public Text text2;

	public void onMouseEnter (){
		text1.color = new Color (text1.color.r, text1.color.b, text1.color.g, 0.0f);
		text2.color = new Color (text2.color.r, text2.color.b, text2.color.g, 1.0f);
	}

	public void onMouseExit (){
		text1.color = new Color (text1.color.r, text1.color.b, text1.color.g, 1.0f);
		text2.color = new Color (text2.color.r, text2.color.b, text2.color.g, 0.0f);
	}

	public void startGame (){
		SceneManager.LoadScene ("Level01");
	}
}
