using UnityEngine;
using System.Collections;

public class EnableOrDisableOnTrigger : MonoBehaviour {

	public GameObject[] enablable;
	public GameObject[] disablable;
	public bool enable = true;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Enable(){
		foreach (GameObject g in enablable) {
			g.SetActive(true);
		}
	}
	
	void TurnOff(){
		foreach (GameObject g in disablable) {
			g.SetActive(false);
		}
	}

	void OnTriggerEnter(Collider other){
		if (other.tag == "Hiro" || other.tag == "Josie") {
			Enable();
		}
	}
}
