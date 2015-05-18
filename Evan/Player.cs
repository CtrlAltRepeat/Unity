using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
	public float speed;
	public float maxSpeed;

	public enum MoveState{
		normal, bad
	}

	public MoveState moveState;

	private float rotate;

	private GameObject target;
	private Vector2 targetVector;
	
	void FixedUpdate(){
	
		rotate-=Input.GetAxis("Horizontal");
		transform.eulerAngles = new Vector3(0,0,rotate);

		if(Input.GetKey(KeyCode.W)||Input.GetKey(KeyCode.S)){
			moveState = MoveState.normal;
			float direction = Input.GetAxis("Vertical");
			if(GetComponent<Rigidbody2D>().velocity.sqrMagnitude<=maxSpeed){
				Debug.Log(GetComponent<Rigidbody2D>().velocity.sqrMagnitude);
				GetComponent<Rigidbody2D>().AddForce(transform.up*direction*speed*Time.deltaTime,ForceMode2D.Force);

			}
		}
		if(Input.GetAxis("Vertical")==0&&moveState == MoveState.normal){
			GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
		}

		switch(moveState){

		case MoveState.normal:
			break;
		case MoveState.bad:
			GetComponent<Rigidbody2D>().AddForce(targetVector*speed*Time.deltaTime,ForceMode2D.Force);
			break;
		default:
			break;

		}
	}
	
	void OnTriggerEnter2D(Collider2D other){
	
//		if(other.tag == "BadPickup"){
//			moveState = MoveState.bad;
//			target = other.gameObject;
//			//Change from cloudy sprite to show actual item sprite
//		}
		if(other.name == "GoodPickup"){
			//Change from cloudy sprite to show actual item sprite
		}
		
	}

	void OnTriggerStay2d(Collider2D other){
		if(other.tag == "BadPickup"){
			moveState = MoveState.bad;
			target = other.gameObject;
			targetVector = target.transform.position-transform.position;
			//Change from cloudy sprite to show actual item sprite
		}
	}
	
}
