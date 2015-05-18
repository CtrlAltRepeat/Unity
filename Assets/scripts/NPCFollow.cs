using UnityEngine;
using System.Collections;

public class NPCFollow : MonoBehaviour {

	public enum NPCState{
	following,notfollowing
	}

	public NPCState npcState;

	public Sprite[] sprites;

	private GameObject target;
	private float followDistance=1;
	//private float giveUpDistance = 5;
	private int speed = 100;

	void Start(){
		int r = Random.Range (0, sprites.Length);
		SpriteRenderer s = gameObject.GetComponent<SpriteRenderer> ();
		s.sprite = sprites [r];
	}

	// Update is called once per frame
	void FixedUpdate () {
	
		switch(npcState){
		case NPCState.following:
			Vector3 playerVector = (target.transform.position-transform.position);
			GetComponent<Rigidbody2D>().AddForce(playerVector*speed*Time.deltaTime,ForceMode2D.Force);
			transform.rotation = Quaternion.LookRotation(Vector3.forward,playerVector);
			if(Vector3.Distance(gameObject.transform.position,target.transform.position)<=followDistance){
				GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
			}
		break;
		case NPCState.notfollowing:
		break;
		default:
		break;
		}
	}
	
	void OnTriggerEnter2D(Collider2D other){
		if(other.tag == "Player"){
			npcState = NPCState.following;
			target = other.gameObject;
		}
	}
	
	void OnTriggerExit2D(Collider2D other){
//		if(other.tag == "Player"){
//			npcState = NPCState.notfollowing;
//			target = null;
//		}
	}
}
