using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {
	
	void Start () {
		PlayerPrefs.SetInt ("TrophyP1", 5);
		PlayerPrefs.SetInt ("TrophyP2", 5);
	}
}
