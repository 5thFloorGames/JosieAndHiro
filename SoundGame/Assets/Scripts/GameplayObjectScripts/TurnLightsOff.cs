using UnityEngine;
using System.Collections;

public class TurnLightsOff : MonoBehaviour {

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
			GetComponent<AudioSource> ().Play ();

			foreach (Light lightSource in lightSources) {
				StartCoroutine (TurnOff (lightSource, wait));
				wait += 0.3f;
			}
			RenderSettings.skybox = null;
			RenderSettings.ambientIntensity = 0.3f;
		}
	}

	IEnumerator TurnOff(Light source, float wait){
		yield return new WaitForSeconds (wait);
		while (source.intensity > 0) {
			source.intensity = source.intensity - 0.02f;
			print (source.intensity);
			yield return new WaitForSeconds (0.01f);
			if (source.intensity <= 0) {
				yield break;
			}
		}
		source.enabled = false;
	}
}
