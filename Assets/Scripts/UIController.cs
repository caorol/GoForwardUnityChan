using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour {
	private GameObject gameOverText;
	private GameObject runLengthText;
	private float len = 0;
	private float speed = 0.03f;
	private bool isGameOver = false;

	void Start () {
		gameOverText = GameObject.Find ("GameOver");
		runLengthText = GameObject.Find ("RunLength");
	}
	
	void Update () {
		if (!isGameOver) {
			// ゲーム中
			len += speed;
			runLengthText.GetComponent<Text> ().text = "Distance:  " + len.ToString ("F2") + "m";
		} else {
			// ゲームオーバー時
			// 画面クリックでシーンをロード
			if (Input.GetMouseButtonDown (0)) {
				// GameScene 読み込み
				SceneManager.LoadScene ("GameScene");
			}
		}
	}

	public void GameOver() {
		gameOverText.GetComponent<Text> ().text = "GameOver";
		isGameOver = true;
	}
}
