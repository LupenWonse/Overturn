using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public float maxSpeed = 0.001f;
	public float jumpForce = 10f;

	private Vector3 startPosition;
	Animator anim;

	// Use this for initialization
	void Start (){
		anim = GetComponent<Animator>();
		startPosition = this.transform.position;
	}



	// Update is called once per frame
	void FixedUpdate () {
		var move = Input.GetAxis("Horizontal");

		// If the universe is inverted flip the input
		if (Universe.inverse) {
			move *= -1;
		}
			
		GetComponent<Rigidbody2D>().velocity = new Vector2(10*move*maxSpeed, GetComponent<Rigidbody2D>().velocity.y);
		anim.SetFloat("Speed", move);
	}

	void Update() {
		KeyCode jumpKeyCode;
		if (!Universe.inverse) {
			jumpKeyCode = KeyCode.UpArrow;
		} else {
			jumpKeyCode = KeyCode.DownArrow;
		}



		if (Input.GetKeyDown (jumpKeyCode) && GetComponent<Rigidbody2D>().velocity.y == 0) {
			GetComponent<Rigidbody2D> ().AddForce(new Vector2 (0, jumpForce) ) ;
		}


	}


	void OnCollisionEnter2D (Collision2D collision) {
		GameElement hitObject = collision.gameObject.GetComponent<GameElement>();
		if (hitObject && hitObject.killer) {
			Universe.deathCount += 1;
			this.transform.position = startPosition;
			this.GetComponent<Rigidbody2D> ().velocity = Vector3.zero;
		} else if (hitObject && hitObject.door) {
			Universe.levelCompleted ();
		}
	}
}
