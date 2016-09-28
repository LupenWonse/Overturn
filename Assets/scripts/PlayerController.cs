using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public float maxSpeed = 10f;
	Animator anim;
	// Use this for initialization
	void Start (){
		anim = GetComponent<Animator>();
	}



	// Update is called once per frame
	void Update () {
		var move = Input.GetAxis("Horizontal");
		if(!Universe.inverse) {
			if(move>0) {
				anim.SetInteger("Direction", 0);
				GetComponent<Rigidbody2D>().velocity = new Vector2(10*move*maxSpeed, GetComponent<Rigidbody2D>().velocity.y);
				anim.SetFloat("Speed", Mathf.Abs(move));
			}
			else if(move <0) {
				anim.SetInteger("Direction", 1);
				GetComponent<Rigidbody2D>().velocity = new Vector2(10*move*maxSpeed, GetComponent<Rigidbody2D>().velocity.y);
				anim.SetFloat("Speed", Mathf.Abs(move));
			}else {
				anim.SetFloat("Speed", Mathf.Abs(0*maxSpeed));
				GetComponent<Rigidbody2D>().velocity = new Vector2(0*move*maxSpeed, GetComponent<Rigidbody2D>().velocity.y); }

		}

		else{
			if(move>0) {
				anim.SetInteger("Direction", 1);
				GetComponent<Rigidbody2D>().velocity = new Vector2(-10*move*maxSpeed, GetComponent<Rigidbody2D>().velocity.y);
				anim.SetFloat("Speed", Mathf.Abs(move));
			}
			else if(move <0) {
				anim.SetInteger("Direction", 0);
				GetComponent<Rigidbody2D>().velocity = new Vector2(-10*move*maxSpeed, GetComponent<Rigidbody2D>().velocity.y);
				anim.SetFloat("Speed", Mathf.Abs(move));
			}else {
				anim.SetFloat("Speed", Mathf.Abs(0*maxSpeed));
				GetComponent<Rigidbody2D>().velocity = new Vector2(0*move*maxSpeed, GetComponent<Rigidbody2D>().velocity.y); }

		}



			}
}
