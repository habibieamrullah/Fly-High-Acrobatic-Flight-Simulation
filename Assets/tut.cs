using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tut : MonoBehaviour {

	public Text tutext;

	// Use this for initialization
	void Start () {
		
		
	}
	
	// Update is called once per frame
	void Update () {
		if (game.score >= 500) {
			tutext.text = "Great! Now go back to main menu and start your real flight in real world...";
		}
	}
}
