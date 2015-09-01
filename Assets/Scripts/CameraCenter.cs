using UnityEngine;
using System.Collections;

public class CameraCenter : MonoBehaviour {

	public float yOffset = 4f;
	Transform target1;
	Transform target2;

	void Start () {
		target1 = GameObject.Find ("Player/P1").transform;
		target2 = GameObject.Find ("Player/P2").transform;
	}
	
	void FixedUpdate () {
		float distance = Vector3.Distance (target1.position, target2.position) / 2f;
		Vector3 center = Vector3.MoveTowards (
			target1.position, target2.position, distance
		);
		transform.position = Vector3.Lerp (
			transform.position,
			new Vector3 (
				center.x,
				center.y + yOffset,
				transform.position.z
			), 
			Time.deltaTime * 5f
		);
	}
}
