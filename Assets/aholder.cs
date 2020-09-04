using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aholder : MonoBehaviour {

	GameObject plane;
	int currentAircraft = 1;

	// Use this for initialization
	void Start () {
		if(PlayerPrefs.HasKey("selair"))
			currentAircraft = PlayerPrefs.GetInt("selair");
		bringAirc ();
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (0f, 0.5f, 0f);
	}

	public void prevAirc(){
		if (currentAircraft > 1) {
			currentAircraft--;
			bringAirc ();
		}
	}

	public void nextAirc(){
		if (currentAircraft < 6) {
			currentAircraft++;
			bringAirc ();
		}
	}

	public void bringAirc(){
		Destroy (plane);
		plane = Instantiate(Resources.Load("plane" + currentAircraft.ToString()) as GameObject);
		plane.transform.parent = transform;
		plane.transform.eulerAngles = new Vector3(transform.eulerAngles.x - 90, transform.eulerAngles.y, -transform.eulerAngles.z);
		PlayerPrefs.SetInt ("selair", currentAircraft);
	}
		
}