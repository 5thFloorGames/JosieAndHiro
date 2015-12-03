using UnityEngine;
using System.Collections;

public class EnableAndDisableOnTrigger : MonoBehaviour {

	public GameObject[] enablable;
	public GameObject[] disablable;
	public bool enable = true;
	public bool needBoth = false;
	private bool HiroHere = false;
	private bool JosieHere = false;

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
	
	void Disable(){
		foreach (GameObject g in disablable) {
			g.SetActive(false);
		}
	}

	void OnTriggerEnter(Collider other){
		if (needBoth) {
			if(other.tag == "Hiro"){
				HiroHere = true;
			}
			if(other.tag == "Josie"){
				JosieHere = true;
			}
			if(HiroHere && JosieHere){
				Enable();
				Disable();
			}
		} else if (other.tag == "Hiro" || other.tag == "Josie") {
			Enable();
			Disable();
		}
	}
}
