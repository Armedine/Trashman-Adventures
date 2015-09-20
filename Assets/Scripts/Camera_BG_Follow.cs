using UnityEngine;
using System.Collections;

public class Camera_BG_Follow : MonoBehaviour {

	public Transform target;
	public Transform bg;
	public Transform particleFollow;
	private Camera cam;
	private Vector3 pos;
	private Vector3 previousPos;

	private int tweenAmount;

	// Use this for initialization
	void Start () {
		cam = Camera.main;
	}
	
	// Update is called once per frame
	void Update () {
		bg.position = new Vector3(target.position.x, target.position.y, -1f);
		particleFollow.position = new Vector3(target.position.x + -10f, target.position.y + 10f, -1f);
	}
}