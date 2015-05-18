using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
	
	#region Component References
	private Rigidbody2D thisRigidbody;
	#endregion
	
	#region Movement
	//screen point for mouse position
	private Vector3 mousePos;
	
	//float for V-Axis movement
	private float vMove;
	//absolute value of V-Axis
	//private float vMoveAbs;
	//float for H-Axis movement
	private float hMove;
	//absolute value of H-Axis
	//private float hMoveAbs;
	#endregion

	#region State Enumeration
	public enum MoveState{
		none,
		prone,
		crouching,
		walking,
		sprinting
	}
	private MoveState moveState;
	#endregion

	#region Entity Properties
	//Name Property
	private string EntityName;
	public string entityName{
		get{return EntityName;}
		set{EntityName = value;}
	}

	//Age Property
	private int Age;
	public int age{
		get{return Age;}
		set{Age = value;}
	}

	//Energy Property
	private float Energy = 100f;
	public float energy{
		get{return Energy;}
		set{Energy = value;}
	}

	//Max Speed Property
	private float MaxSpeed;
	public float maxSpeed{
		get{return MaxSpeed;}
		set{MaxSpeed = value;}
	}
	#endregion

	public void EntityCreate(string _entityName, float _energy, float _maxSpeed){

		entityName = _entityName;
		energy = _energy;
		maxSpeed = _maxSpeed;
		gameObject.name = entityName;


	}

	void Awake(){
		
		//get this objects rigidbody reference
		thisRigidbody = GetComponent<Rigidbody2D>();
		EntityCreate("Evan",100f,5f);
		
	}

	void FixedUpdate(){
		
		//value assignment for player input
		vMove = Input.GetAxis("Vertical");
		//vMoveAbs = Mathf.Abs(vMove);
		hMove = Input.GetAxis("Horizontal");
		//hMoveAbs = Mathf.Abs(hMove);
		
		//rotates player so sprite faces mouse point
		mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		transform.rotation = Quaternion.LookRotation(Vector3.forward, mousePos - transform.position);
		
		//aquires force values
		float vForce = vMove*energy;
		float hForce = hMove*energy;
		//if player is moving under their max speed
		if(thisRigidbody.velocity.magnitude<maxSpeed){
			
			//zero-ing the movement vector before applying force
			//helps get rid of the floatiness of the character movement
			ZeroVelocity();
			//add vertical force
			thisRigidbody.AddForce(transform.up*vForce,ForceMode2D.Force);
			//add horizontal force
			thisRigidbody.AddForce(transform.right*hForce,ForceMode2D.Force);
				
			if(Input.GetKeyDown(KeyCode.LeftShift)){

			}
			
		}
		
		//if there no player input
		if(vForce == 0 && hForce == 0){
			//stop player
			ZeroVelocity();
		}
		
	}
	
	public void ZeroVelocity(){
		thisRigidbody.velocity = new Vector3(0,0,0);
	}

}
