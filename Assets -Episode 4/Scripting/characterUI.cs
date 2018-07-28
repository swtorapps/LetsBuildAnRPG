using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class characterUI : MonoBehaviour {

	public float GlobalCooldown;
	private float GlobalCooldownRemain;

	public mainCharacterInfo script;



	// Use this for initialization
	void Start () {
		GlobalCooldown = 2f;

		script = GameObject.FindObjectOfType<mainCharacterInfo> ();

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

		if (SceneManager.GetActiveScene() != SceneManager.GetSceneByName("creationScreen")){
			GameObject.Find ("UICharName").GetComponent<Text> ().text = script.playerName + " | Level " + script.playerLevel;
			GameObject.Find ("UIStrengthText").GetComponent<Text> ().text = script.playerStrength.ToString();
			GameObject.Find ("UIDefenseText").GetComponent<Text> ().text = script.playerDefense.ToString();
			GameObject.Find ("UIDexterityText").GetComponent<Text> ().text = script.playerDexterity.ToString();
			GameObject.Find ("UISanityText").GetComponent<Text> ().text = script.playerSanity.ToString();
			GameObject.Find ("UIReflexesText").GetComponent<Text> ().text = script.playerReflexes.ToString();
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
