using UnityEngine;
using System.Collections;

public class GetPosition : MonoBehaviour {
	public static Vector2 roundedWormPos1;
	public static Vector2 roundedWormPos2;
	public static Vector2 roundedWormPos3;
	public GameObject worm1;
	public GameObject worm2;
	public GameObject worm3;

	void Update () {
		// Get coordinates of worm 1 and round them
		if (worm1 != null)
		{
				float tempX1 = Mathf.Round (worm1.transform.position.x);
				float tempY1 = Mathf.Round (worm1.transform.position.y);
				roundedWormPos1 = new Vector2 (tempX1, tempY1);
		}

		// Get coordinates of worm 2 and round them
		if (worm2 != null) 
		{
				float tempX2 = Mathf.Round (worm2.transform.position.x);
				float tempY2 = Mathf.Round (worm2.transform.position.y);
				roundedWormPos2 = new Vector2 (tempX2, tempY2);
		
		}
		// Get coordinates of worm 3 and round them
		if (worm3 != null)
		    {
				float tempX3 = Mathf.Round (worm3.transform.position.x);
				float tempY3 = Mathf.Round (worm3.transform.position.y);
				roundedWormPos3 = new Vector2 (tempX3, tempY3);
				
			}

		//Debug.Log ("Worm1: " + roundedWormPos1 + " Worm2: " + roundedWormPos2 + " Worm3: " + roundedWormPos3);
		//this.enabled = false;
	}
}
