using UnityEngine;
using System.Collections;

public class ToggleObject : MonoBehaviour {

	public Behaviour togglable;

	public void Toggle(){
		togglable.enabled = !togglable.enabled;
	}
}
