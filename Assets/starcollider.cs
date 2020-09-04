using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class starcollider : MonoBehaviour {

	public GameObject parent;

	public AudioClip scoresound;
	AudioSource audioSource;

	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (!game.paused) {
			transform.Rotate (0f, 0f, 2f);
		}
	}

	void OnTriggerEnter(Collider col){
		if (col.tag == "playerplane") {
			game.score += 100;
			PlayerPrefs.SetInt ("score", game.score);
			parent.transform.localScale = new Vector3 (0f, 0f, 0f);
			audioSource.PlayOneShot (scoresound);
			StartCoroutine (comeAgain ());
		}
	}

	IEnumerator comeAgain(){
		yield return new WaitForSeconds (60);
		parent.transform.localScale = new Vector3 (8f, 8f, 8f);
	}
}
