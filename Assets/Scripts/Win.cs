using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Win : MonoBehaviour {

	public Sprite[] sprites;

	void Start () {
		Destroy (GameObject.Find ("UI"));
		int winner = int.Parse (PlayerPrefs.GetString ("Winner").Replace ("P", ""));
		Debug.Log (winner);
		GetComponent<Image> ().sprite = sprites [winner-1];
	}

	void Update () {
		if (Input.anyKeyDown) {
			Application.LoadLevel ("Menu");
		}
	}
}
