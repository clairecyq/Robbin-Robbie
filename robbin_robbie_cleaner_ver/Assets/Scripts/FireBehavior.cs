﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBehavior : MonoBehaviour {

	// Use this for initialization
	// void Start () {
		
	// }
	
	// Update is called once per frame

	public int circularRotation = 90;

	public GameObject Spring; // used only in one level
	public GameObject energyShell; //

	void Update () {
		 transform.Rotate (new Vector3 (0, circularRotation, 0) * Time.deltaTime);
	}

	public void setCircularRotation(int newRot) {
		circularRotation = newRot;
	}

	 private void OnTriggerEnter2D(Collider2D c)
    {   
        if (c.gameObject.name == "Robbie" && this.isActiveAndEnabled){
            // gameObject.SetActive(false);
			gameObject.GetComponent<SpriteRenderer>().enabled = false;
			gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
			if (this.name.Contains("fire")) {
				GameController.instance.obtainCoin();
			}
			else if (this.name.Contains("spring")) {
				Spring.SetActive(true);
			}
			else {
				energyShell.SetActive(true);
				//Spring.SetActive(true);
				GameObject.FindWithTag("Player").GetComponent<RobbieMovement>().canHide = true;
			}
		}
    }
}