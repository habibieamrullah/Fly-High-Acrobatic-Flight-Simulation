using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class propelerotator : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(!game.paused)
			transform.Rotate (0f, 25f, 0f);
	}
}
