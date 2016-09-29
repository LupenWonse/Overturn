using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Universe : MonoBehaviour {
	public static bool inverse;
	public static int deathCount = 0;
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

	void Inverse() {
		Universe.inverse = !Universe.inverse;
		float random = Random.Range(5f, 10f);
		Invoke("Inverse", random);
	}

	public static void levelCompleted() {
		SceneManager.LoadScene ("MainMenu");
	}
}
