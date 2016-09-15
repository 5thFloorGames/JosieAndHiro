using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CalibrationPhaseManager : MonoBehaviour {

	private int phase;
	public GameObject[] phases;

	// Use this for initialization
	void Start () {
		phase = 0;
		phases [phase].SetActive (true);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.P)) {
			NextPhase ();
		}
	}

	public void NextPhase() {
		if (phase >= phases.Length -1) {
			StartCoroutine ("LoadAsync");
		} else {
			phases [phase].SetActive (false);
			phase++;
			phases [phase].SetActive (true);
		}
	}

	IEnumerator LoadAsync() {
		AsyncOperation async = Application.LoadLevelAsync("TestSetup");
		yield return async;
		Debug.Log("Loading complete");
	}
}
