using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.UI;
using UnityEngine.Events;

public class characterCreation : MonoBehaviour {

	public GameObject Prefab;
	public Transform Container;

	public int 		strength,
					defense,
					dexterity,
					sanity,
					reflex,
					level,
					exp;
	public string   characterName;

	const int skillPoints = 20;
	public characterData charData;


	void Start () {
//Loading saves via array
		string [] files = Directory.GetFiles(@Application.persistentDataPath, "*.dat");
		foreach (string save in files){
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream playerSaveFile = File.Open (save, FileMode.Open);

			AllPlayerData data = (AllPlayerData)bf.Deserialize (playerSaveFile);
			playerSaveFile.Close ();

			level = data.level;
			characterName = data.characterName;

			GameObject go = Instantiate (Prefab);
			go.GetComponentInChildren<Text> ().text = characterName + " | Level " + level;
			go.transform.SetParent (Container);
			go.transform.localPosition = Vector3.zero;
			go.transform.localScale = Vector3.one;
			go.GetComponent<Button> ().onClick.AddListener (() => OnButtonClick (save));

		}
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnButtonClick (string index){
		Debug.Log (index);
	}
}
