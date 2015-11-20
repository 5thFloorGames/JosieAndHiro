using UnityEngine;
using System.Collections;

public class TurnLightsOff : MonoBehaviour {

	[SerializeField]
	private Light lightSource;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other){
		lightSource.enabled = false;
	}
}
