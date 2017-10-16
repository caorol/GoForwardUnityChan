using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour {
	private float scrollSpeed = -0.03f;
	private float deadLine = -16;
	private float startLine = 15.8f;

	void Start () {
	}
	
	void Update () {
		// 背景移動
		transform.Translate(scrollSpeed, 0, 0);

		// 画面外に出たら画面右端に移動
		if (transform.position.x < deadLine) {
			transform.position = new Vector2 (startLine, 0);
		}
	}
}
