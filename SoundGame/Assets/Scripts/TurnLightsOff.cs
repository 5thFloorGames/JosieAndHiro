using UnityEngine;
using System.Collections;

public class TurnLightsOff : MonoBehaviour {

	[SerializeField]
	private Light[] lightSources;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other){
		float wait = 0f;
		foreach (Light lightSource in lightSources) {
			StartCoroutine(TurnOff(lightSource, wait));
			wait += 0.3f;
		}
	}

	IEnumerator TurnOff(Light source, float wait){
		yield return new WaitForSeconds (wait);
		source.enabled = false;
	}
}
