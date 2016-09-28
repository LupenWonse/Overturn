using UnityEngine;
using System.Collections;

public class Universe : MonoBehaviour {
	public static bool inverse;
	public bool test;
	public GameObject bg;
	public GameObject bginverse;
	SpriteRenderer bgSprite;
	SpriteRenderer bgInverseSprite;


	// Use this for initialization
	void Start () {
	Universe.inverse = false;
	test = false;
	Invoke("Inverse", 7);
	}

	// Update is called once per frame
	void Update () {

	}

	public void testOnClick () {
		print ("Hello");
	}

	void Inverse() {
		Universe.inverse = !Universe.inverse;
		float random = Random.Range(5f, 10f);
		Invoke("Inverse", random);
	}
}
