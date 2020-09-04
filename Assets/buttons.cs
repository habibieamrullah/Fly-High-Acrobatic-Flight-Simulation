using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class buttons : MonoBehaviour {

	public Slider loadingbar;
	public GameObject sld;
	private AsyncOperation async;

	int score;

	void Start(){
		sld.SetActive (false);
		score = PlayerPrefs.GetInt ("score");
	}

	public void sceneMain(){
		if (score < 500) {
			SceneManager.LoadScene ("tutorial");	
		} else {
			sld.SetActive (true);
			StartCoroutine (loadMain ());
		}
	}
	public void sceneMenu(){
		Time.timeScale = 1;
		game.paused = false;
		SceneManager.LoadScene ("menu");
	}
	public void sceneAir(){
		SceneManager.LoadScene ("aircrafts");
	}

	IEnumerator loadMain (){
		async = SceneManager.LoadSceneAsync("main");
		while (!async.isDone) {
			loadingbar.value = async.progress;
			yield return null;
		}
	}
}
