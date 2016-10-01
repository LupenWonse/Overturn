using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TwoColorText : MonoBehaviour {

	public string text1;
	public string text2;

	private Text textView;

	public void Awake(){
		textView = GetComponent<Text> ();
		textView.text = text1;
	}

	public void onMouseEnter (){
		textView.text = text2;
	}

	public void onMouseExit (){
		textView.text = text1;
	}
}
