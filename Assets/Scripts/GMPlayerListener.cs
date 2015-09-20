using UnityEngine;
using System.Collections;

public class GMPlayerListener : MonoBehaviour {

	public Transform player;
	public GameObject startingLoc;

	private Vector3 startingLocVector;

	// Use this for initialization
	void Start () {
		startingLoc = GameObject.FindGameObjectWithTag("Spawn Start");
		startingLocVector = startingLoc.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (player.position.y < -20){
			player.position = startingLocVector;
		}
	}
}