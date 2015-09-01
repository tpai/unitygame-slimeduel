using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Power : HUDBase {
	
	public float nowPower = 0f;
	public float minPower = 0f;
	public float maxPower = 200f;
	public float offset = 6f;

	bool isShooting = false;
	bool decrMode = false;
	Image img;
	Player playerScript;

	void Start () {
		img = GetComponent<Image> ();
		playerScript = GameObject.Find ("Player/"+suffix).GetComponent<Player> ();
	}

	void Update () {
		if (!isShooting && Input.GetButtonDown ("Fire1_" + suffix)) {
			isShooting = true;
			playerScript.Attack ();
			nowPower = 0;
		}

		if (Input.GetButtonUp ("Fire1_" + suffix)) {
			isShooting = false;
			playerScript.Shoot (nowPower);
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
