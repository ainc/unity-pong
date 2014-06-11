using UnityEngine;
using System.Collections;

public class PlayerControls : MonoBehaviour {

	public KeyCode moveUp = KeyCode.UpArrow;
	public KeyCode moveDown = KeyCode.DownArrow;

	public float speed = 10.0f;


	void Update(){ 

		if (Input.GetKey (moveUp)) {
			var vel = rigidbody2D.velocity;
			vel.y = speed;
			rigidbody2D.velocity = vel;
		} else if (Input.GetKey (moveDown)) {
			var vel = rigidbody2D.velocity;
			vel.y = -1*speed;
			rigidbody2D.velocity = vel;;
		} else if(!Input.anyKey){
			var vel = rigidbody2D.velocity;
			vel.y = 0.0f;
			rigidbody2D.velocity = vel;
		}

		var reset = rigidbody2D.velocity;
		reset.x = 0;
		rigidbody2D.velocity = reset;
		
	}
}
	