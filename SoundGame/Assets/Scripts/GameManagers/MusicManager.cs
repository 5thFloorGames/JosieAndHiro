using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour {

	public AudioSource layerOne;
	public AudioSource layerTwo;
	private float layerOneVolume = 0f;
	private float layerTwoVolume = 0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void StartTrackOne(){
		StartCoroutine ("FadeInOne");
	}

	public void StartTrackTwo(){
		StartCoroutine ("FadeInTwo");
	}

	public void StartFadeForCredits(){
		StartCoroutine ("FadeForCredits");
	}

	IEnumerator FadeInOne(){
		while(true){
			layerOneVolume += 0.0003f;
			layerOne.volume = layerOneVolume;
			if(layerOneVolume >= 0.02f){
				break;
			}
			yield return new WaitForSeconds(1f);
		}
	}

	IEnumerator FadeInTwo(){
		while(true){
			layerTwoVolume += 0.0003f;
			layerTwo.volume = layerTwoVolume;
			if(layerTwoVolume >= 0.02f){
				break;
			}
			yield return new WaitForSeconds(1f);
		}
	}

	IEnumerator FadeForCredits() {
		while(true){
			layerTwoVolume -= 0.0015f;
			layerOneVolume -= 0.0015f;
			layerTwo.volume = layerTwoVolume;
			layerOne.volume = layerOneVolume;
			if(layerTwoVolume <= 0f && layerOneVolume <= 0f){
				break;
			}
			yield return new WaitForSeconds(0.5f);
		}
	}
}
