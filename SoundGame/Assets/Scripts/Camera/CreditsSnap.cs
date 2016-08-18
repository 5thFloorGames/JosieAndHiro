using UnityEngine;
using System.Collections;

public class CreditsSnap : MonoBehaviour {

	public Transform CameraSpot;
	public Transform HiroSpot;
	public Transform JosieSpot;
	public Camera cam;
	private GameObject hiro;
	private GameObject josie;

	public GameObject[] enablable;
	public GameObject[] disablable;
	private bool HiroHere = false;
	private bool JosieHere = false;

	void Start(){
		hiro = GameObject.FindGameObjectWithTag ("Hiro");
		josie = GameObject.FindGameObjectWithTag ("Josie");
	}

	void Enable(){
		foreach (GameObject g in enablable) {
			g.SetActive(true);
		}
	}
	
	void Disable(){
		foreach (GameObject g in disablable) {
			g.SetActive(false);
		}
	}
	
	void OnTriggerEnter(Collider other){
		if(other.tag == "Hiro"){
			HiroHere = true;
		}
		if(other.tag == "Josie"){
			JosieHere = true;
		}
		if(HiroHere && JosieHere){
			hiro.transform.position = HiroSpot.position;
			hiro.transform.rotation = HiroSpot.rotation;
			hiro.GetComponent<HiroController>().reset();
			hiro.GetComponent<HiroController>().enabled = false;
			josie.transform.position = JosieSpot.position;
			josie.transform.rotation = JosieSpot.rotation;
			josie.GetComponent<JosieController>().reset();
			josie.GetComponent<JosieController>().enabled = false;
			cam.GetComponent<MouseOrbitImproved>().enabled = false;
			cam.transform.position = CameraSpot.position;
			cam.transform.rotation = CameraSpot.rotation;
			Enable();
			Disable();
		}

	}

}
