using UnityEngine;
using System.Collections;

public class HUDBase : MonoBehaviour {
	
	public string suffix {
		get {
			return transform.parent.name;
		}
	}
}
