using UnityEngine;
using System.Collections;

public class BallControl : MonoBehaviour {

    private Rigidbody2D rb2d;
    private Vector2 vel;

    IEnumerator Hi(float secs){
        yield return new WaitForSeconds(secs);
    }

    void GoBall(){
        float rand = Random.Range(0.0f, 2.0f);
        if(rand < 1.0f){
            rb2d.AddForce(new Vector2(20.0f, -15.0f));
        } else {
            rb2d.AddForce(new Vector2(-20.0f, -15.0f));
        }
    }

	// Use this for initialization
	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        vel = rb2d.velocity;
        Hi(2.0f);
        GoBall();
	}

    void ResetBall(){
        vel.y = 0;
        vel.x = 0;
        rb2d.velocity = vel;
        gameObject.transform.position = new Vector2(0, 0);
    }

    void RestartGame(){
        ResetBall();
        Hi(0.5f);
        GoBall();
    }

    void OnCollisionEnter2D (Collision2D coll) {
        if(coll.collider.CompareTag("Player")){
            vel.y = (vel.y / 2.0f) + (coll.collider.attachedRigidbody.velocity.y / 3.0f);
            rb2d.velocity = vel;
        }
    }
}