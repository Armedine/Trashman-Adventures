using UnityEngine;
using System.Collections;

//[RequireComponent (typeof(SpriteRenderer))]

public class Tile_BG : MonoBehaviour {
	
	public int offsetX = 2;
	public bool hasRightBody = false;
	public bool hasLeftBody = false;
	
	public bool reverseScale = false;
	
	private float spriteWidth = 0.0f;
	
	private Camera cam;
	
	private Transform myTransform;
	
	void Awake ()
	{
		cam = Camera.main;
		myTransform = transform;
	}
	
	
	void Start () {
		SpriteRenderer sRenderer = GetComponent<SpriteRenderer>();
		spriteWidth = sRenderer.sprite.bounds.size.x;
	}
	
	
	void Update () {
		if (hasLeftBody == false || hasRightBody == false) 
		{
			//calc cam extents in world coords
			float camHorizExt = cam.orthographicSize * Screen.width/Screen.height;
			
			//calc x pos where edge of screen is (from cam)
			float edgeVisPosRight = (myTransform.position.x + spriteWidth/2) - camHorizExt;
			float edgeVisPosLeft = (myTransform.position.x - spriteWidth/2) + camHorizExt;
			
			//can we see edge?; make a new body if we can
			if (cam.transform.position.x >= (edgeVisPosRight - offsetX) && hasRightBody == false)
			{
				MakeNewBody(1);
				hasRightBody = true;
			} else if (cam.transform.position.x <= (edgeVisPosLeft + offsetX) && hasLeftBody == false)
			{
				MakeNewBody(-1);
				hasLeftBody = true;
			}
		}
	}
	
	//create new tile as needed
	void MakeNewBody (int rightOrLeft)
	{
		//new pos for new body
		Vector3 newPos = new Vector3(myTransform.position.x + spriteWidth * rightOrLeft, myTransform.position.y, myTransform.position.z);
		Transform newBody = Instantiate(myTransform, newPos, myTransform.rotation) as Transform;
		
		if (reverseScale == true)
		{
			newBody.localScale = new Vector3 (newBody.localScale.x*-1, newBody.localScale.y, newBody.localScale.z);
		}
		
		newBody.parent = myTransform.parent;
		
		if (rightOrLeft > 0)
		{
			newBody.GetComponent<Tile_BG>().hasLeftBody = true;
		} else
		{
			newBody.GetComponent<Tile_BG>().hasRightBody = true;
		}
	}
	
}
