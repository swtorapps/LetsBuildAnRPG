using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterUI : MonoBehaviour {

	public float GlobalCooldown;
	private float GlobalCooldownRemain;



	// Use this for initialization
	void Start () {
		GlobalCooldown = 2f;

	}
	
	// Update is called once per frame
	void Update () {

		if (Time.time > GlobalCooldownRemain) {
			if (Input.GetKeyDown ("1")) {
				ActionBar1 ("Basic Attack");
				GlobalCooldownRemain = Time.time + GlobalCooldown;
			}
			if (Input.GetKeyDown ("2")) {
				ActionBar2 ("More Powerful Attack");
				GlobalCooldownRemain = Time.time + GlobalCooldown;
			}
			if (Input.GetKeyDown ("3")) {
				ActionBar3 ("Basic Heal");
				GlobalCooldownRemain = Time.time + GlobalCooldown;
			}
			if (Input.GetKeyDown ("4")) {
				ActionBar4 ("Buff");
				GlobalCooldownRemain = Time.time + GlobalCooldown;
			}
			if (Input.GetKeyDown ("5")) {
				ActionBar5 ("Sprint");
				GlobalCooldownRemain = Time.time + GlobalCooldown;
			}
		} else {
			if (Input.GetKeyDown ("1") || Input.GetKeyDown ("2") || Input.GetKeyDown ("3") || Input.GetKeyDown ("4") || Input.GetKeyDown ("5")) {
				Debug.Log ("Globalcooldown! Time reamins is: " + GlobalCooldownRemain/1000 + " seconds!");
			}
		}
	}


	public void ActionBar1(string action) {
		Debug.Log ("Action 1 was triggered! Player activated: " + action);
	
	}

	public void ActionBar2(string action) {
		Debug.Log ("Action 2 was triggered! Player activated: " + action);

	}

	public void ActionBar3(string action) {
		Debug.Log ("Action 3 was triggered! Player activated: " + action);

	}

	public void ActionBar4(string action) {
		Debug.Log ("Action 4 was triggered! Player activated: " + action);

	}

	public void ActionBar5(string action) {
		Debug.Log ("Action 5 was triggered! Player activated: " + action);

	}




}
