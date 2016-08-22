using UnityEngine;
using System.Collections;

public class ChangeCubeColor : MonoBehaviour {

	public GameObject cube;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider col){
		cube.GetComponent<Renderer> ().material.color = Color.green;
	}

	void OnTriggerExit(Collider col){
		cube.GetComponent<Renderer> ().material.color = Color.white;
	}
}
