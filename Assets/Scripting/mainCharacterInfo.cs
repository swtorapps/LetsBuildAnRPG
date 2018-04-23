using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class mainCharacterInfo : MonoBehaviour {

	int firstGame = 0; //This means the game has not been run before, therefore, we need to create a new character
	int createNewCharacter = 0; //We are creating a new character

	public string playerName;
	public int playerStrength, playerDefense, playerDexterity, playerSanity, playerReflexes;
	public int playerStrengthOdd, playerDefenseOdd, playerDexterityOdd, playerSanityOdd, playerReflexesOdd;

	private int playerRemainingPoints = 20;

	public Font fontType;

	// Use this for initialization
	void Start () {
		firstGame = PlayerPrefs.GetInt("characterCreationFirstGame");
		playerName = PlayerPrefs.GetString ("characterName");
			playerStrength = PlayerPrefs.GetInt ("characterStrength");
			playerDefense = PlayerPrefs.GetInt ("characterDefense");
			playerDexterity = PlayerPrefs.GetInt ("characterDexterity");
			playerSanity = PlayerPrefs.GetInt ("characterSanity");
			playerReflexes = PlayerPrefs.GetInt ("characterReflexes");

		if (firstGame == 0) {
			Debug.Log ("This is the first time the game has run");
			firstGame = 1;
			PlayerPrefs.SetInt("characterCreationFirstGame", firstGame);
			createNewCharacter = 1;
		} else {
			Debug.Log ("The game has run before!");
			PlayerPrefs.SetInt ("characterCreationFirstGame", 0);
			PlayerPrefs.SetString ("characterName", "Player Name");
			PlayerPrefs.SetInt ("characterStrength", 0);
			PlayerPrefs.SetInt ("characterDefense", 0);
			PlayerPrefs.SetInt ("characterDexterity", 0);
			PlayerPrefs.SetInt ("characterSanity", 0);
			PlayerPrefs.SetInt ("characterReflexes", 0);

		}

	}

	void OnGUI(){
		GUI.skin.font = fontType;
		GUI.skin.label.fontSize = 20;

		if (createNewCharacter == 1){
			GUILayout.BeginArea (new Rect(Screen.width/2-50, Screen.height/2-200, 500, 2000));
			GUI.backgroundColor = Color.red;

			playerName = GUI.TextField (new Rect (0, 0, 250, 25), playerName, 35);
			PlayerPrefs.SetString("characterName", playerName);

			//
			GUI.Label(new Rect(0, 35, 200, 40), "Strength: " + playerStrength);
			if (playerStrength != playerStrengthOdd) {
				if (playerStrengthOdd <= playerStrength) {
					playerRemainingPoints = playerRemainingPoints - (playerStrength - playerSanityOdd);
					playerStrengthOdd = playerStrength;
				} else if (playerStrengthOdd >= playerStrength) {
					playerRemainingPoints = playerRemainingPoints + (playerStrengthOdd-playerStrength);
					playerStrengthOdd = playerStrength;
				}
			}
			playerStrength = Mathf.RoundToInt (GUI.HorizontalSlider (new Rect (0, 65, 250, 35), playerStrength, 0, 10));
			PlayerPrefs.SetInt ("characterStrength", playerStrength);



			GUI.Label(new Rect(0, 80, 200, 40), "Defense: " + playerDefense);
			if (playerDefense != playerDefenseOdd) {
				if (playerDefenseOdd <= playerDefense) {
					playerRemainingPoints = playerRemainingPoints - (playerDefense - playerDefenseOdd);
					playerDefenseOdd = playerDefense;
				} else if (playerDefenseOdd >= playerDefense) {
					playerRemainingPoints = playerRemainingPoints + (playerDefenseOdd-playerDefense);
					playerDefenseOdd = playerDefense;
				}
			}
			playerDefense = Mathf.RoundToInt (GUI.HorizontalSlider (new Rect (0, 110, 250, 35), playerDefense, 0, 10));
			PlayerPrefs.SetInt ("characterDefense", playerDefense);









			GUI.Label(new Rect(0, 125, 200, 40), "Dexterity: " + playerDexterity);
			if (playerDexterity != playerDexterityOdd) {
				if (playerDexterityOdd <= playerDexterity) {
					playerRemainingPoints = playerRemainingPoints - (playerDexterity - playerDexterityOdd);
					playerDexterityOdd = playerDexterity;
				} else if (playerDexterityOdd >= playerDexterity) {
					playerRemainingPoints = playerRemainingPoints + (playerDexterityOdd-playerDexterity);
					playerDexterityOdd = playerDexterity;
				}
			}
			playerDexterity = Mathf.RoundToInt (GUI.HorizontalSlider (new Rect (0, 155, 250, 35), playerDexterity, 0, 10));
			PlayerPrefs.SetInt ("characterDexterity", playerDexterity);

			GUI.Label(new Rect(0, 170, 200, 40), "Sanity: " + playerSanity);
			if (playerSanity != playerSanityOdd) {
				if (playerSanityOdd <= playerSanity) {
					playerRemainingPoints = playerRemainingPoints - (playerSanity - playerSanityOdd);
					playerSanityOdd = playerSanity;
				} else if (playerSanityOdd >= playerSanity) {
					playerRemainingPoints = playerRemainingPoints + (playerSanityOdd-playerSanity);
					playerSanityOdd = playerSanity;
				}
			}
			playerSanity = Mathf.RoundToInt (GUI.HorizontalSlider (new Rect (0, 200, 250, 35), playerSanity, 0, 10));
			PlayerPrefs.SetInt ("characterSanity", playerSanity);

			GUI.Label(new Rect(0, 215, 200, 40), "Reflex: " + playerReflexes);
			if (playerReflexes != playerReflexesOdd) {
				if (playerReflexesOdd <= playerReflexes) {
					playerRemainingPoints = playerRemainingPoints - (playerReflexes - playerReflexesOdd);
					playerReflexesOdd = playerReflexes;
				} else if (playerReflexesOdd >= playerReflexes) {
					playerRemainingPoints = playerRemainingPoints + (playerReflexesOdd-playerReflexes);
					playerReflexesOdd = playerReflexes;
				}
			}
			playerReflexes = Mathf.RoundToInt (GUI.HorizontalSlider (new Rect (0, 245, 250, 35), playerReflexes, 0, 10));
			PlayerPrefs.SetInt ("characterReflexes", playerReflexes);


			GUI.Label (new Rect (0, 300, 600, 100), playerRemainingPoints + " Attribute Points Remain");


			if (playerRemainingPoints == 0 ){

				if(GUI.Button(new Rect(0, 400, 150, 150), "Begin Adventure!")) {
					SceneManager.LoadScene("gameworld_000");
				}
			} else if (playerRemainingPoints < 0) {
				GUI.Button (new Rect(0, 400, 300, 30), "Please Assign only 20 Attribute Points");
			} else {
				GUI.Button (new Rect(0, 400, 300, 30), "Please Assign Attribute Points!");
			}



			GUILayout.EndArea ();


		}
	
	}
	

}
