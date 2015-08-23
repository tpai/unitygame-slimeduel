using UnityEngine;
using System.Collections;

public class GunTop : MonoBehaviour {

	float sideDegree = 0f;

	void Update () {
		if (transform.parent.localScale.x > 0)
			sideDegree = 0f;
		else
			sideDegree = 180f;

		transform.localRotation = Quaternion.Euler (new Vector3 (0f, sideDegree, 25f));
	}
}
