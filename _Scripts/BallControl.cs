using UnityEngine;
using System.Collections;

public class BallControl : MonoBehaviour {

	void Start () {
		hi (2.0f);
		GoBall ();
	}

	IEnumerator hi(float secs){
		yield return new WaitForSeconds(secs);
	}


	void GoBall(){
		float rand = Random.Range (0.0f,100.0f);
		if (rand < 50.0f) {
			rigidbody2D.AddForce(new Vector2(20.0f,15.0f));
		} else {
			rigidbody2D.AddForce(new Vector2(-20.0f,-15.0f));
		}
	}

	void hasWon(){
		var vel = rigidbody2D.velocity;
		vel.y = 0;
		vel.x = 0;
		rigidbody2D.velocity = vel;
		
		gameObject.transform.position = new Vector2 (0, 0);
	}

	void resetBall(){
		var vel = rigidbody2D.velocity;
		vel.y = 0;
		vel.x = 0;
		rigidbody2D.velocity = vel;

		gameObject.transform.position = new Vector2 (0, 0);

		hi (2.0f);
		GoBall ();
	}
	
	void OnCollisionEnter2D (Collision2D coll) {
		if (coll.collider.CompareTag("Player")) {
			var velY = rigidbody2D.velocity;
			velY.y = (velY.y/2.0f)+(coll.collider.rigidbody2D.velocity.y/3.0f);
			rigidbody2D.velocity = velY;
		}
	}
}
