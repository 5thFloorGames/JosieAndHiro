using UnityEngine;
using System.Collections;

public class MoveWhenSound : MonoBehaviour {

	private UnityEngine.AI.NavMeshAgent agent;

	// Use this for initialization
	void Start () {
		agent = gameObject.GetComponent<UnityEngine.AI.NavMeshAgent> ();
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void SetDestination(Vector3 destination){
		agent.destination = destination;
		agent.Stop();
		Invoke ("Move", Random.Range(0.2f,1.0f));
	}

	private void Move(){
		agent.Resume ();
	}
}
