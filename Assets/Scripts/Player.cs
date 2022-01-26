using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public string suffix = "P1";
	public GameObject bomb;
	public float fwdSpeed = 3f;
	public float jumpSpeed = 20f;

	Transform gunTop;
	Transform sprite;
	Rigidbody2D rigid;
	Animator anim;
	bool isJumping = false;

	void OnEnable () {
		transform.name = suffix;
		transform.position = GameObject.Find ("Spawn" + suffix).transform.position;
		transform.rotation = GameObject.Find ("Spawn" + suffix).transform.rotation;

		anim = GetComponentInChildren<Animator> ();
		rigid = GetComponent<Rigidbody2D> ();
		rigid.velocity = Vector3.zero;
		
	}

	void Start () {
		bomb.CreatePool (20);
		sprite = transform.Find ("Sprite");
		gunTop = transform.Find ("Sprite/GunTop");
		rigid.centerOfMass = transform.up * -3f;
	}

	float h;
	void Update () {
		h = Input.GetAxis ("Horizontal_" + suffix);
		if (h != 0f) {
			rigid.velocity  = new Vector2 (fwdSpeed * h, rigid.velocity.y);
		}
		if (h > 0) {
			transform.localScale = new Vector3 (-transform.localScale.z, transform.localScale.z, transform.localScale.z);
		} else if (h < 0) {
			transform.localScale = Vector3.one * transform.localScale.z;
		}

		anim.SetFloat ("Horizontal", Mathf.Abs(h));

		if (!isJumping && Input.GetButtonDown ("Jump_"+suffix)) {
			GetComponent<AudioSource> ().Play ();
			isJumping = true;
			rigid.velocity  = new Vector2 (rigid.velocity.x, jumpSpeed);
		}
	}

	public void Attack () {
		anim.SetTrigger ("Attack");
	}

	public void Shoot (float force) {
		anim.SetTrigger ("Shoot");

		GameObject obj = bomb.Spawn (gunTop.position, gunTop.rotation);
		obj.transform.rotation = transform.rotation;

		if(anim.GetFloat("Horizontal")>0f) {
			obj.transform.localScale = Vector3.one;
		} else {
			obj.transform.localScale = new Vector3 (-1f, 1f, 1f);
		}

		obj.GetComponent<Rigidbody2D> ().velocity = gunTop.up * force;
		obj.GetComponent<Rigidbody2D> ().angularVelocity = Random.Range (50f, 100f);
	}

	void OnCollisionEnter2D (Collision2D coll) {
		if (coll.collider.tag == "Ground") {
			isJumping = false;
		}
	}
}
