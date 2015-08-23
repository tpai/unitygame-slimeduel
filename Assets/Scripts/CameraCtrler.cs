using UnityEngine;
using System.Collections;

public class CameraCtrler : MonoBehaviour {

	[SerializeField] Camera cameraCenter;
	[SerializeField] Camera cameraL;
	[SerializeField] Camera cameraR;

	Transform target1;
	Transform target2;

	bool multi = false;
	bool single = false;

	void Start () {
		target1 = GameObject.Find ("P1").transform;
		target2 = GameObject.Find ("P2").transform;
	}

	void FixedUpdate () {
		if (!single && Vector3.Distance (target1.position, target2.position) < 40f) {
			single = true;
			multi = false;
			cameraCenter.enabled = true;
			cameraL.enabled = false;
			cameraR.enabled = false;
		} else
			single = false;

		if (!multi && Vector3.Distance (target1.position, target2.position) >= 40f) {
			multi = true;
			single = false;
			cameraCenter.enabled = false;
			cameraL.enabled = true;
			cameraR.enabled = true;
		} else
			multi = false;
	}
}
