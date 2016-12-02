using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableScriptOnTrigger : MonoBehaviour {

	public MonoBehaviour script;

	// Use this for initialization
	void Start () {
		
	}
	
	void OnTriggerEnter(Collider col){
		script.enabled = true;
	}
}
