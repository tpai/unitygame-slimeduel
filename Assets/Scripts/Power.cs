using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Power : MonoBehaviour {

	public string suffix = "P1";
	public float nowPower = 0f;
	public float minPower = 0f;
	public float maxPower = 200f;
	public float offset = 6f;

	bool isShooting = false;
	bool decrMode = false;
	Image img;

	void Start () {
		img = GetComponent<Image> ();
	}

	void Update () {
		if (!isShooting && Input.GetButtonDown ("Fire1_" + suffix)) {
			isShooting = true;
			GameObject.Find (suffix).GetComponent<Player> ().Attack ();
			nowPower = 0;
		}

		if (Input.GetButtonUp ("Fire1_" + suffix)) {
			isShooting = false;
			GameObject.Find (suffix).GetComponent<Player> ().Shoot (nowPower);
		}
	}

	void FixedUpdate () {

		if (!isShooting)
			return;

		if (!decrMode)
			nowPower += offset;
		else
			nowPower -= offset;

		if (nowPower >= maxPower) {
			nowPower = maxPower;
			decrMode = true;
		}

		if (nowPower <= minPower) {
			nowPower = minPower;
			decrMode = false;
		}

		img.fillAmount = nowPower / maxPower;
	}
}
