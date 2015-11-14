using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Win : MonoBehaviour {

	public Sprite[] sprites;
	bool freeToRestart = false;

	void Start () {
		Destroy (GameObject.Find ("UI"));
		int winner = int.Parse (PlayerPrefs.GetString ("Winner").Replace ("P", ""));
		GetComponent<Image> ().sprite = sprites [winner-1];
		StartCoroutine (Wait ());
	}

	IEnumerator Wait() {
		yield return new WaitForSeconds (3f);
		freeToRestart = true;
	}

	void Update () {
		if (freeToRestart && Input.anyKeyDown) {
			Application.LoadLevel ("Menu");
		}
	}
}
