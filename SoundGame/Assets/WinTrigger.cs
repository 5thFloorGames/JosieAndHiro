using UnityEngine;
using System.Collections;

public class WinTrigger : MonoBehaviour {

	private int playersInTrigger = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other){
		playersInTrigger++;
		if(playersInTrigger == 2){
			print ("game won!");
		}
	}

	void OnTriggerExit(Collider other){
		playersInTrigger--;
	}
}
