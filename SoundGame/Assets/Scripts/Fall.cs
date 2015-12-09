using UnityEngine;
using System.Collections;

public class Fall : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void OnTriggerEnter(Collider other){
		StartCoroutine (drop ());
	}
	
	IEnumerator drop(){
		bool done = false;
		while (!done) {
			GameObject g = gameObject;
			Vector3 target = new Vector3 (g.transform.position.x, -15f, g.transform.position.z);
			g.transform.position = Vector3.MoveTowards (g.transform.position, target, 10f * Time.deltaTime);
			if (g.transform.position.y <= -15) {
				done = true;
			} else {
				yield return null;
			}
		}
	}
}
