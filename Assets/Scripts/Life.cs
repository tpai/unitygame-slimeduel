using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Life : HUDBase {

	public int counter;

	void Start () {
		CheckLife ();
	}

	public void Lost () {
		counter --;
		PlayerPrefs.SetInt ("Life" + suffix, counter);
		CheckLife ();

		if (counter < 1) {
			int alive = 0;
			string winner = "";
			foreach (Life life in GameObject.FindObjectsOfType<Life> ()) {
				if (life.counter != 0) {
					alive ++;
					winner = life.suffix;
				}
			}

			counter = 5;
			PlayerPrefs.SetInt ("Life" + suffix, counter);

			if (alive == 1) {
				Application.LoadLevel (winner+"_Win");
				return ;
			}
		}
	}

	void CheckLife () {
		counter = PlayerPrefs.GetInt ("Life" + suffix);
		ResetAll ();
		SetLife ();
	}

	void ResetAll () {
		foreach (Transform child in transform) {
			child.gameObject.SetActive (true);
		}
	}

	void SetLife () {
		int amt = 5;
		foreach (Transform child in transform) {
			if (amt == counter)break;
			child.gameObject.SetActive (false);
			amt --;
		}
	}
}
