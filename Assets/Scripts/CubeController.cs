using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour {
	// 移動速度
	private float speed = -0.2f;
	// 消滅位置
	private float deadLine = -10;
	private bool isCollision = false;
	private AudioSource audio;
	public static bool isGameOver = false;

	void Start () {
		audio = GetComponent<AudioSource> ();
	}
	
	void Update () {
		if (isCollision && !isGameOver) {
			audio.Play ();
			isCollision = false;
		}

		// キューブ移動
		transform.Translate(speed, 0, 0);

		// 画面外に出たら破棄
		if (transform.position.x < deadLine) {
			Destroy (gameObject);
		}
	}

	void OnCollisionEnter2D (Collision2D other) {
		if (other.gameObject.tag == "Cube" || other.gameObject.tag == "Ground") {
			Debug.Log ("<color=yellow>Cube HIT!: " + other.gameObject.tag + "</color>");
			isCollision = true;
		}
	}
}
