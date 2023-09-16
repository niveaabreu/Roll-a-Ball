using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Rotator : MonoBehaviour {
	private int oscilate;

	// Before rendering each frame..
	void Start(){
		oscilate = 0;
	}
	void Update () 
	{
		// Rotate the game object that this script is attached to by 15 in the X axis,
		// 30 in the Y axis and 45 in the Z axis, multiplied by deltaTime in order to make it per second
		// rather than per frame.
		transform.Rotate (new Vector3 (10, 90, 0) * Time.deltaTime);
		
	}
}	