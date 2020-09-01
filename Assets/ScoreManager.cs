using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
	//得点用の変数
	public int score = 0;

	//得点を表示するテキスト
	private GameObject scoreText;

	// Use this for initialization
	void Start()
	{
		//シーン中のScoreTextオブジェクトを取得
		this.scoreText = GameObject.Find("ScoreText");
	}

	// Update is called once per frame
	void Update()
	{
		
	}

	//衝突時に呼ばれる関数
	void OnCollisionEnter(Collision collision)
	{
		//タグ用変数
		string tag = collision.gameObject.tag;

		//ターゲットごとの得点
		if (tag == "SmallStarTag")
		{
			score += 10;

			//スコアの表示
			this.scoreText.GetComponent<Text>().text = "得点:" + score + "点";
		}
		else if (tag == "LargeStarTag" || tag == "SmallCloudTag")
		{
			score += 20;

			//スコアの表示
			this.scoreText.GetComponent<Text>().text = "得点:" + score + "点";
		}
		else if (tag == "LargeCloudTag")
		{
			score += 50;

			//スコアの表示
			this.scoreText.GetComponent<Text>().text = "得点:" + score + "点";
		}

	}
}
