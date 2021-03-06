﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Life : HUDBase {

	public int counter;
	Transform player;

	void Start () {
		player = GameObject.Find ("Player/"+suffix).transform;
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

			if (alive == 1) {
				PlayerPrefs.SetString ("Winner", winner);
				Application.LoadLevel ("Win");
				return;
			}

			Destroy (player.gameObject);
		}
		else {
			player.GetComponent<Player> ().enabled = false;
			player.GetComponent<Player> ().enabled = true;
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
