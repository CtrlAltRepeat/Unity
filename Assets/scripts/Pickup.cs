using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Pickup : MonoBehaviour {
	
	public enum SuctionState {sucking,notSucking}
	public SuctionState suctionState = SuctionState.notSucking;
	
	private GameObject target;
	private int speed = 100;
	
	public Animator pickupAnimator;

	// Use this for initialization
	void Start ()
	{
		pickupAnimator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		switch(suctionState)
		{
			case SuctionState.sucking:
				Vector3 playerPOS = -(target.transform.position-transform.position);
				target.GetComponent<Rigidbody2D>().AddForce(playerPOS*speed*Time.deltaTime,ForceMode2D.Force);
				transform.rotation = Quaternion.LookRotation(Vector3.forward,playerPOS);
				break;
			case SuctionState.notSucking:
				break;
			default:
				break;
		}
	}
	
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player")
		{
			pickupAnimator.SetBool ("collected", true);
			if(gameObject.tag == "BadPickup"){
				suctionState = SuctionState.sucking;
				target = other.gameObject;
			}
		}
	}
	
	void OnTriggerExit2D(Collider2D other)
	{
		if (other.tag == "Player")
		{
			pickupAnimator.SetBool ("collected", false);
			suctionState = SuctionState.notSucking;
			target = other.gameObject;
		}
	}
}
