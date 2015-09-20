using UnityEngine;
using System.Collections;

public class GMPlayerListener : MonoBehaviour {

	public Transform player;
	public GameObject startingLoc;
	public float maxPlayerVelocity = 10f;

	private Vector3 startingLocVector;

	private Rigidbody2D playerRB;

	// Use this for initialization
	void Start () {
		startingLoc = GameObject.FindGameObjectWithTag("Spawn Start");
		startingLocVector = startingLoc.transform.position;

		playerRB = player.GetComponent<Rigidbody2D>();

		Cursor.visible = false;
	}
	
	// Update is called once per frame
	void Update () {
		//simple reset
		if (player.position.y < -20){
			player.position = startingLocVector;
			playerRB.velocity = new Vector2(0f, 0f);
		}

		//limit max speed
		if (playerRB.velocity.y > maxPlayerVelocity)
		{
			playerRB.velocity = new Vector2(maxPlayerVelocity, maxPlayerVelocity);
		}
	}
}