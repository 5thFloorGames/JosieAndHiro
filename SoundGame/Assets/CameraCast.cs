using UnityEngine;
using System.Collections;

public class CameraCast : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.F)) {
			if(Physics.Raycast(transform.position, Input.mousePosition)){
				print ("urgblgbl");
			}
		}
	}
}
