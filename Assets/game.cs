using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class game : MonoBehaviour {

	public Camera cam1;
	public Camera cam2;
	public Camera cam3;

	public GameObject ppanel;
	public Text scoretext;

	int cam = 1;
	public static bool paused = false;
	public static int score = 0;

	// Use this for initialization
	void Start () {
		score = PlayerPrefs.GetInt ("score");
		cam1.enabled = true;
		cam2.enabled = false;
		cam3.enabled = false;
		ppanel.SetActive (false);
	}

	// Update is called once per frame
	void Update () {
		scoretext.text = "Score: " + score.ToString ("n0");
	}

	public void toggleCam(){
		if (cam == 1) {
			cam = 2;
			cam1.enabled = false;
			cam2.enabled = true;
			cam3.enabled = false;
		} else if (cam == 2) {
			cam = 3;
			cam1.enabled = false;
			cam2.enabled = false;
			cam3.enabled = true;
		}else if(cam == 3){
			cam = 1;
			cam1.enabled = true;
			cam2.enabled = false;
			cam3.enabled = false;
		}
	}

	public void togglePause(){
		if (paused) {
			ppanel.SetActive (false);
			Time.timeScale = 1;
			paused = false;
		} else {
			Time.timeScale = 0;
			ppanel.SetActive (true);
			paused = true;
		}
	}
}
