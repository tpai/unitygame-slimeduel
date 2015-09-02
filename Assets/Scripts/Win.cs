using UnityEngine;
using System.Collections;

public class Win : MonoBehaviour {

	void Start () {
		PlayerPrefs.SetInt ("LifeP1", 5);
		PlayerPrefs.SetInt ("LifeP2", 5);
		PlayerPrefs.SetInt ("LifeP3", 5);
		PlayerPrefs.SetInt ("LifeP4", 5);
	}

	void Update () {
		if (Input.anyKeyDown) {
			Application.LoadLevel ("Main");
		}
	}
}
