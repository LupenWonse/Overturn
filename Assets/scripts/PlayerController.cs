using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public float maxSpeed = 0.001f;
	public float jumpForce = 10f;
	Animator anim;

	// Use this for initialization
	void Start (){
		anim = GetComponent<Animator>();
	}



	// Update is called once per frame
	void FixedUpdate () {
		var move = Input.GetAxis("Horizontal");

		// If the universe is inverted flip the input
		if (Universe.inverse) {
		//	move *= -1;
		}
			
		GetComponent<Rigidbody2D>().velocity = new Vector2(10*move*maxSpeed, GetComponent<Rigidbody2D>().velocity.y);
		anim.SetFloat("Speed", move);

		float verticalMove = Input.GetAxis ("Vertical");
		if (verticalMove > 0 && GetComponent<Rigidbody2D> ().velocity.y == 0) {
			GetComponent<Rigidbody2D> ().AddForce(new Vector2 (0, jumpForce) ) ;
			}
	}


	void OnCollisionEnter2D (Collision2D collision) {
		GameElement hitObject = collision.gameObject.GetComponent<GameElement>();
		print (hitObject);
		if (hitObject && hitObject.killer) {
			Universe.deathCount += 1;
		}
	}
}
