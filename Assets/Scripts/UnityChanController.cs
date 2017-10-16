using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityChanController : MonoBehaviour {
	Animator animator;
	Rigidbody2D rigid2D;
	// 地面の位置
	private float groundLevel = -3.0f;
	// ジャンプ速度
	float jumpVelocity = 20;
	// ジャンプ速度の減衰
	private float dump = 0.8f;
	// ゲームオーバ位置
	private float deadLine = -9;

	void Start () {
		animator = GetComponent<Animator> ();
		rigid2D = GetComponent<Rigidbody2D> ();

		// 走るアニメーションを再生するパラメタセット
		animator.SetFloat("Horizontal", 1);
	}
	
	void Update () {
		// 走るアニメーション

		// 着地しているかどうか
		bool isGround = (transform.position.y > groundLevel)?false:true;
		animator.SetBool ("isGround", isGround);

		// ジャンプ中は消音
		GetComponent<AudioSource>().volume = isGround?1:0;

		// クリック時: ジャンプ
		if (Input.GetMouseButtonDown (0) && isGround) {
//			Debug.Log ("<color=yellow>pos Y:"+ transform.position.y +",   velocity: "+rigid2D.velocity+"</color>");
			rigid2D.velocity = new Vector2 (0, jumpVelocity);
		}

		// クリックされてない時: ジャンプ減速
		if (Input.GetMouseButton (0) == false) {
			if (rigid2D.velocity.y > 0) {
				rigid2D.velocity *= dump;
			}
		}

		// デッドラインを超えたらゲームオーバ
		if (transform.position.x < deadLine) {
			// UIController の GameOver 関数を呼び出す
			GameObject.Find ("Canvas").GetComponent<UIController> ().GameOver ();
			CubeController.isGameOver = true;
			// ユニティちゃんを破棄
			Destroy (gameObject);
		}
	}
}
