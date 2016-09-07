using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ToggleOnCondition : MonoBehaviour {

	public Toggle[] conditions;
	public GameObject togglable;

	public void CheckToggles(){
		foreach (Toggle condition in conditions) {
			if (!condition.isOn) {
				return;
			}
		}
		togglable.SetActive (true);
	}
}
