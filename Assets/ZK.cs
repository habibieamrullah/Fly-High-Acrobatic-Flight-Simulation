using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using GoogleMobileAds.Api;

public class ZK : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine(toMain ());
		//PlayerPrefs.DeleteAll();
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	IEnumerator toMain() {
		yield return new WaitForSeconds (2);
		SceneManager.LoadScene ("menu");
	}
}