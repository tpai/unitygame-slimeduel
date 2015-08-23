using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Trophy : MonoBehaviour {

	public string suffix = "P1";
	int counter;

	void Start () {
		CheckTrophy ();
	}

	public void Win () {
		if (counter > 0) {
			counter --;
			PlayerPrefs.SetInt ("Trophy" + suffix, counter);
			CheckTrophy ();
		}
	}

	void CheckTrophy () {
		int trophy = PlayerPrefs.GetInt ("Trophy" + suffix);
		if (trophy == 0) {
			Application.LoadLevel (suffix + "_Lose");
		}
		else {
			counter = (trophy == 0) ? 5 : trophy;
		}
		ResetAll ();
		SetTrophy ();
	}

	void ResetAll () {
		foreach (Transform child in transform) {
			child.gameObject.SetActive (true);
		}
	}

	void SetTrophy () {
		int amt = 5;
		foreach (Transform child in transform) {
			if (amt == counter)break;
			child.gameObject.SetActive (false);
			amt --;
		}
	}
}
