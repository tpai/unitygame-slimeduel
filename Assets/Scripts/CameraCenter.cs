using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CameraCenter : MonoBehaviour {

	public float yOffset = 4f;
	public List<Transform> targets = new List<Transform>();

	Vector3 p1, p2, p3, p4;
	float a, b, c, d, x, y;

	void Start () {
		foreach (Transform t in GameObject.Find ("Player").transform) {
			targets.Add(t);
		}
	}
	
	void FixedUpdate () {
//		float distance = Vector3.Distance (target1.position, target2.position) / 2f;
//		Vector3 center = Vector3.MoveTowards (
//			target1.position, target2.position, distance
//		);

		Bounds bounds = new Bounds(transform.position, Vector3.zero);
		for (int i = 0; i < targets.Count; i++) {
			if (targets[i] != null)
				bounds.Encapsulate (targets [i].transform.position); 
		}

		transform.position = Vector3.Lerp (
			transform.position,
			new Vector3 (
				bounds.center.x,
				bounds.center.y + yOffset,
				transform.position.z
			), 
			Time.deltaTime * 5f
		);
	}
}
