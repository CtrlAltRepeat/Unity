using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	private GameObject player;

	private float cameraRange = -10;

	// Use this for initialization
	void Start () {
	
		player = GameObject.FindWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3(player.transform.position.x,player.transform.position.y,cameraRange);
	}

	void CameraDistanceCheck(){

	}
}
