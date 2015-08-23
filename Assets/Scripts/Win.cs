using UnityEngine;
using System.Collections;

public class Win : MonoBehaviour {

	void Start () {
		PlayerPrefs.SetInt ("TrophyP1", 5);
		PlayerPrefs.SetInt ("TrophyP2", 5);
	}

	void Update () {
		if (Input.anyKeyDown) {
			Application.LoadLevel ("Main");
		}
	}
}
