using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public string targetName = "P1";
	public float yOffset = 4f;
	Transform target;

	void Start () {
		target = GameObject.Find (targetName).transform;
	}

	void FixedUpdate () {
		transform.position = Vector3.Lerp (
			transform.position,
			new Vector3 (
				Mathf.Clamp (target.position.x, -40f, 40f),
				Mathf.Clamp (target.position.y + yOffset, -7f, 10f),
				transform.position.z
			), 
			Time.deltaTime * 5f
		);
	}
}
