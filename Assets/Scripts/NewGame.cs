using UnityEngine;
using System.Collections;

public class NewGame : MonoBehaviour {
	public int time;

	// Use this for initialization
	void Start () {
		Invoke ("LoadLevel", time);
	}

	void LoadLevel()	{
		Application.LoadLevel("scene_main");
	}
}
