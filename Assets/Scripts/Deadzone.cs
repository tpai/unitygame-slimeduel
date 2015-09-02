using UnityEngine;
using System.Collections;

public class Deadzone : MonoBehaviour {

	void OnTriggerEnter2D (Collider2D other) {
		if (other.tag == "P1" || other.tag == "P2" || other.tag == "P3" || other.tag == "P4") {
			GameObject.Find ("HUD/"+other.tag+"/Life").GetComponent<Life>().Lost ();
			GetComponent<AudioSource> ().Play ();
		}
	}
}
