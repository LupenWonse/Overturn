using UnityEngine;
using System.Collections;

public class ImageInverse : MonoBehaviour {
	public Sprite normal;
	public Sprite inverse;
	// Use this for initialization
	void Start () {


	}

	// Update is called once per frame
	void Update () {
	if(Universe.inverse){
		GetComponent<SpriteRenderer>().sprite = inverse;
	}else{
		GetComponent<SpriteRenderer>().sprite = normal;
	}
	}
}
