using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pilot : MonoBehaviour {

	public float speed;
	public float multiplier;
	public Rigidbody rb;

	bool slideleft = false;
	bool slideright = false;

	GameObject plane;

	float updownIn;
	float leftrightIn;

	void Start () {
		if(PlayerPrefs.HasKey("selair"))
			plane = Instantiate(Resources.Load("plane" + PlayerPrefs.GetInt("selair").ToString()) as GameObject);
		else
			plane = Instantiate(Resources.Load("plane" + 1.ToString()) as GameObject);
		plane.transform.parent = transform;
		plane.transform.eulerAngles = new Vector3(transform.eulerAngles.x - 90, transform.eulerAngles.y, -transform.eulerAngles.z);

		rb = GetComponent<Rigidbody> ();
		if(game.score < 500)
			rb.transform.position = new Vector3 (0f, -180f, 0f);
		else
			rb.transform.position = new Vector3 (Random.Range(0f, 2000f), 0, Random.Range(0f, 500f));
		updownIn = Input.acceleration.z;
		leftrightIn = Input.acceleration.x;
	}

	void FixedUpdate() {
		//plane.transform.position = new Vector3 (transform.position.x, transform.position.y, transform.position.z);
		//plane.transform.eulerAngles = new Vector3(transform.eulerAngles.x - 90, transform.eulerAngles.y, -transform.eulerAngles.z);

		if (rb.velocity.magnitude < speed) {
			rb.AddRelativeForce (new Vector3 (0, 0, speed));
		}



		if (Input.GetKey ("up")) {
			rb.AddRelativeTorque (new Vector3 (0.2f * multiplier, 0, 0));
		}
		if(Input.GetKey ("down")){
			rb.AddRelativeTorque (new Vector3 (-0.2f * multiplier, 0, 0));
		}
		if(Input.GetKey ("left")){
			rb.AddRelativeTorque (new Vector3 (0, 0, 0.1f * multiplier));
		}
		if(Input.GetKey ("right")){
			rb.AddRelativeTorque (new Vector3 (0, 0, -0.1f * multiplier));
		}
		if (Input.GetKey (KeyCode.A)) {
			rb.AddRelativeTorque (new Vector3 (0, -0.1f * multiplier, 0));
		}
		if (Input.GetKey (KeyCode.D)) {
			rb.AddRelativeTorque (new Vector3 (0, 0.1f * multiplier, 0));
		}


		float updown = Input.acceleration.z - updownIn;
		float leftright = Input.acceleration.x - leftrightIn;

		float slide = 0f;
		if (slideleft)
			slide = -0.1f * multiplier;
		if (slideright)
			slide = 0.1f * multiplier;

		rb.AddRelativeTorque (new Vector3((-updown * .3f) * multiplier, slide, (-leftright * 0.1f) * multiplier));

	}

	public void sl(int n){
		if (n == 0) {
			slideleft = false;
			slideright = false;
		}
		if (n == 1) {
			slideleft = true;
			slideright = false;
		}
		if (n == 2) {
			slideleft = false;
			slideright = true;
		}
	}

	void OnTriggerEnter(Collider col){
		if (col.tag == "worldobject") {
			/*
			if (ZKAd.interstitial.IsLoaded ()) {
				ZKAd.interstitial.Show ();
			}

			*/
			if (ZKAd.interstitial.IsLoaded ()) {
				ZKAd.interstitial.Show ();
			}
			SceneManager.LoadScene ("crashed");
		}
	}

}
