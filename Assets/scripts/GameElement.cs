using UnityEngine;
using System.Collections;

public class GameElement : MonoBehaviour {

	public bool killer = false;
	public bool door = false;
	public Vector2 moving = new Vector2(0,0);
	public float movementSpeed = 1.0f;
	private Vector3 initialPosition;

	private int direction = 1;

	void Start(){
		initialPosition = transform.position;
	}

	void FixedUpdate(){
		if (moving.magnitude > 0) {
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (movementSpeed * direction, 0);
		}

		if (this.transform.position.x - initialPosition.x > moving.x) {
			direction = -1;
		} else if (this.transform.position.x - initialPosition.x < -moving.x){
			direction = 1;
		}
	}
}
