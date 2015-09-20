using UnityEngine;
using System.Collections;

public class ParallaxBG : MonoBehaviour {
	
	public Transform[] backgrounds; 	//C# syntax = [] = array.
	private float[] parallaxScale;		//Proportion of cam movement to adjust by.
	public float smoothing = 1.0f; 			//Set above 0; controls how smooth animations are.
	
	private Transform cam;				//Main camera.
	private Vector3 previousCamPos;		//Position of camera previously.
	
	//Awake runs before start.
	void Awake () 
	{
		cam = Camera.main.transform;
	}
	
	void Start () 
	{
		previousCamPos = cam.position;
		parallaxScale = new float[backgrounds.Length];
		
		for (int i = 0; i < backgrounds.Length; i++)
		{
			parallaxScale[i] = backgrounds[i].position.z*-1;
		}
	}
	
	
	void Update ()
	{
		for (int i = 0; i < backgrounds.Length; i++)
		{
			//parallax is opposite of cam's movement; previous frame multiplied by scale.
			float parallax = (previousCamPos.x - cam.position.x) * parallaxScale[i];
			float backgroundTargetPosX = backgrounds[i].position.x + parallax;
			
			//create target pos. then set background location
			Vector3 backgroundTargetPos = new Vector3 (backgroundTargetPosX, backgrounds[i].position.y, backgrounds[i].position.z);
			
			//fade between positions using lerp
			backgrounds[i].position = Vector3.Lerp (backgrounds[i].position, backgroundTargetPos, smoothing * Time.deltaTime);
		}
		
		previousCamPos = cam.position;
	}
}