using UnityEngine;
using System.Collections;

public class TurnLightsOn : MonoBehaviour {
	
	[SerializeField]
	private Light[] lightSources;
	private bool hit = false;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerEnter(Collider other){
		if (!hit) {
			hit = true;
			float wait = 0f;
			GetComponent<AudioSource>().Play();
			foreach (Light lightSource in lightSources) {
				StartCoroutine (TurnOn (lightSource, wait));
				wait += 0.3f;
			}
		}
	}
	
	IEnumerator TurnOn(Light source, float wait){
		yield return new WaitForSeconds (wait);
		source.enabled = true;
	}
}
