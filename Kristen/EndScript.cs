using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EndScript : MonoBehaviour {

	GUIText GT;
	GUIText GT2;


	int badCount=0;
	int goodCount=0;

	// Use this for initialization
	void Start () {
	
		GT = GameObject.Find("GUIText").GetComponent<GUIText>();
		GT = GameObject.Find("GUIText2").GetComponent<GUIText>();

	}
	
	// Update is called once per frame
	void Update () {
		if (badCount == 4) {
			Application.LoadLevel("MenuScreen");		
		}
		if (goodCount == 4) {
			Application.LoadLevel("MenuScreen");		
		}
		GT.text = "Good: " + goodCount + "\n" +
			"Bad: " + badCount;
	}

	void OnTriggerEnter2D(Collider2D other){
	
	if(gameObject.tag=="Player"){
			if(other.tag == "BadPickup"){
				badCount++;
				Destroy(other.gameObject);

				switch (other.name)
				{
				case "egg":
					GT2.text = "You awalk on eggshells around others";
					StartCoroutine("ClearText");
					break;
				case "shovel":
					GT2.text = "You dug yourself a hole by lying";
					StartCoroutine("ClearText");
					break;
				case "TNT":
					GT2.text = "You have a short fuse and blew up at a friend";
					StartCoroutine("ClearText");
					break;
				case "EnergyDrink":
					GT2.text = "You procrastinated and have to stay up all night studying";
					StartCoroutine("ClearText");
					break;
				}
			}
			}
			if (other.tag == "GoodPickup") {
				goodCount++;
				Destroy(other.gameObject);

			switch (other.name)
			{
			case "sun":
				GT2.text = "You see the bright side of life";
				StartCoroutine("ClearText");
				break;
			case "leaf":
				GT2.text = "You took a walk to clear your head";
				StartCoroutine("ClearText");
				break;
			case "coffee":
				GT2.text = "You had coffee with a friend";
				StartCoroutine("ClearText");
				break;
			case "paintbrush":
				GT2.text = "You expressed yourself artistically";
				StartCoroutine("ClearText");
				break;
			}
			}

	}
		
	}

	public IEnumerator ClearText(){
		yield return new WaitForSeconds (3);
		GT2.text = "";
	}
}
