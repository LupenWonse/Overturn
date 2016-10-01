using UnityEngine;
using System.Collections;

public class GameElement : MonoBehaviour {

	public bool killer = false;
	public bool door = false;
	public Vector2 moving = new Vector2(0,0);
	public float movementSpeed = 1.0f;
	public GameObject throws;

	private Vector3 initialPosition;



	private int direction = 1;

	void Start(){
		initialPosition = transform.position;

		if (throws != null) {
			startThrowing ();
		}
	}

	void FixedUpdate(){
		if (moving.x > 0) {
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (movementSpeed * direction, 0);
		}
		if (moving.y > 0) {
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, movementSpeed * direction);
		}

		if (this.transform.position.x - initialPosition.x > moving.x) {
			direction = -1;
		} else if (this.transform.position.x - initialPosition.x < -moving.x){
			direction = 1;
		}
	}

	void startThrowing(){
		print ("Throwing");
		GameObject.Instantiate (throws);
		Invoke ("startThrowing", 4);
	}
}
