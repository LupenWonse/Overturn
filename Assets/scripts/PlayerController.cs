using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public float maxSpeed = 0.001f;
	public float jumpForce = 10f;


	public bool isGrounded = false;

	private Vector3 startPosition;

	public Transform groundDetector;
	public LayerMask groundLayerMask;


	Animator anim;

	// Use this for initialization
	void Start (){

		anim = GetComponent<Animator>();
		startPosition = this.transform.position;
	}



	// Update is called once per frame
	void FixedUpdate () {
		isGrounded = Physics2D.OverlapCircle(groundDetector.position, 0.01f, groundLayerMask);
		float move = Input.GetAxisRaw("Horizontal");

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


		if (Input.GetKeyDown (jumpKeyCode) && isGrounded) {
			GetComponent<Rigidbody2D> ().AddForce(new Vector2 (0, jumpForce) ) ;
		}

		if (!Universe.inverse) {
			GetComponent<SpriteRenderer> ().color = Color.black;
		} else {
			GetComponent<SpriteRenderer> ().color = Color.white;
		}

	}


	void OnCollisionEnter2D (Collision2D collision) {
		GameElement hitObject = collision.gameObject.GetComponent<GameElement>();
		//ContactPoint2D test = collision.contacts [0]; 
		//print (test.normal.ToString());

		if (hitObject && hitObject.killer) {
			Universe.deathCount += 1;
			this.transform.position = startPosition;
			this.GetComponent<Rigidbody2D> ().velocity = Vector3.zero;
		} else if (hitObject && hitObject.door) {
			Universe.levelCompleted ();
		}
	}
}
