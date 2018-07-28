using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.SceneManagement;

public class characterData : MonoBehaviour {

	public static characterData manager;

	public int 		strength,
					defense,
					dexterity,
					sanity,
					reflex,
					level,
					exp;
	public string   characterName;




	void Awake(){

	}

	// Use this for initialization
	void Start () {
		if (manager == null) {
			DontDestroyOnLoad (gameObject);
			manager = this;
		} else if (manager != this) {
			Destroy (gameObject);
		}

	}
	
	// Update is called once per frame
	void Update () {
		
	}



	public void SaveGame(){
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream playerSaveFile = File.Create (Application.persistentDataPath + "/indev." + characterName + ".dat"); // FOLDER\indev.Player Name.dat

		AllPlayerData data = new AllPlayerData ();
		data.strength = strength;
		data.defense = defense;
		data.dexterity = dexterity;
		data.sanity = sanity;
		data.reflex = reflex;
		data.level = level;
		data.exp = exp;
		data.characterName = characterName;

		bf.Serialize (playerSaveFile, data);
		playerSaveFile.Close ();

	}


	public void LoadGame(){
		if (File.Exists(Application.persistentDataPath + "/indev." + characterName + ".dat")){
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream playerSaveFile = File.Open (Application.persistentDataPath + "/indev." + characterName + ".dat", FileMode.Open); 

			AllPlayerData data = (AllPlayerData)bf.Deserialize (playerSaveFile);
			playerSaveFile.Close ();

			strength = data.strength;
			defense = data.defense;
			dexterity = data.dexterity;
			sanity = data.sanity;
			reflex = data.reflex;
			level = data.level;
			exp = data.exp;
			characterName = data.characterName;
		}
	}
}

[Serializable]
class AllPlayerData{
	public int 		strength,
					defense,
					dexterity,
					sanity,
					reflex,
					level,
					exp;
	public string   characterName;
}