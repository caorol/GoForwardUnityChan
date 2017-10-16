using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeGenerator : MonoBehaviour {
	public GameObject cubePrefab;
	// 時間計測用
	private float delta = 0;
	// キューブ生成間隔
	private float span = 1.0f;
	// キューブ生成位置: x
	private float genPositionX = 12;
	// キューブ生成位置: オフセット
	private float offsetY = 0.3f;
	private float offsetX = 0.5f;
	// キューブ間隔
	private float spaceY = 6.9f;
	private float spaceX = 0.4f;
	// キューブ生成個数 上限
	private int maxCubeNum = 4;

	void Start () {
	}
	
	void Update () {
		delta += Time.deltaTime;

		// 生成間隔を経過したかどうか
		if (delta > span) {
			delta = 0;
			// 生成キューブ数
			int n = Random.Range (1, maxCubeNum + 1);
			for (int i = 0; i < n; i++) {
				GameObject go = Instantiate (cubePrefab) as GameObject;
				go.transform.position = new Vector2 (genPositionX, offsetY + i * spaceY);
			}
			// 次のキューブまでの生成時間
			span = offsetX + spaceX * n;
		}
	}
}
