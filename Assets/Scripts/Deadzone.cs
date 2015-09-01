using UnityEngine;
using System.Collections;

public class Deadzone : MonoBehaviour {

	void OnTriggerEnter2D (Collider2D other) {
		if (other.tag == "P1" || other.tag == "P2") {
			GameObject.Find ("HUD/"+other.tag+"/Life").GetComponent<Life>().Lost ();
			GetComponent<AudioSource> ().Play ();

			Transform root = other.transform.parent;
			root.GetComponentInParent<Player> ().enabled = false;
			root.GetComponentInParent<Player> ().enabled = true;
		}
	}
}
