using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cloudfacingplayer : MonoBehaviour {

	public GameObject player;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float dist = Vector3.Distance(player.transform.position, transform.position);
		if(dist > 500)
			transform.LookAt (player.transform);
	}
}
