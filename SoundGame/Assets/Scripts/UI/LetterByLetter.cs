using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LetterByLetter : MonoBehaviour {

	[Multiline]
	public string text;
	private Text UIText;
	public bool autoContinue = false;
	private float delay = 0.05f;

	// Use this for initialization
	void Start () {
		UIText = GetComponent<Text> ();
		StartCoroutine ("TypeText");
	}
	
	IEnumerator TypeText(){
		foreach(char character in text){
			UIText.text += character;
			yield return new WaitForSeconds (delay);
		}
		if (autoContinue) {
			for (int i = 0; i < 4; i++) {
				UIText.text += ".";
				yield return new WaitForSeconds (0.3f);
			}
			FindObjectOfType<CalibrationPhaseManager> ().NextPhase ();
			for (int i = 0; i < 4; i++) {
				UIText.text += ".";
				yield return new WaitForSeconds (0.3f);
			}
		}
	}
}
