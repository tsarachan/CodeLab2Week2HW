﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour {

	Text score;

	int currentScore = 0;
	public int maxScore = 9999;

	int basicIncrement = 1;
	public int BasicIncrement {
		get { return basicIncrement; }
		set { basicIncrement = value; }
	}

	GameObject scoreFeedback;

	float canvasX;
	float canvasY;

	void Start() {
		score = GetComponent<Text>();
		score.text = currentScore.ToString();
		scoreFeedback = Resources.Load("Score feedback") as GameObject;

		RectTransform overlayCanvas = transform.root.Find("Score canvas").GetComponent<RectTransform>();
		canvasX = overlayCanvas.anchoredPosition.x;
		canvasY = overlayCanvas.anchoredPosition.y;
	}

	public void UpdateScore(int amount) {
		currentScore += amount;
		if (currentScore <= maxScore){
			score.text = currentScore.ToString();
		} else {
			currentScore = currentScore - maxScore;
			score.text = currentScore.ToString();
		}
	}

	public void LocalizedFeedback(int amount, Vector3 loc) {
		GameObject newScoreFeedback = Instantiate(scoreFeedback,
												  new Vector3(0.0f, 0.0f, 0.0f),
												  Quaternion.identity) as GameObject;
		
		Vector3 pos = Camera.main.WorldToScreenPoint(loc);
		Vector3 correctedPos = new Vector3(pos.x - canvasX,
										   pos.y - canvasY,
										   pos.z);
		newScoreFeedback.GetComponent<RectTransform>().anchoredPosition = correctedPos;

		newScoreFeedback.transform.SetParent(transform.root.Find("Score canvas"), false);
		newScoreFeedback.GetComponent<Text>().text = amount.ToString();
	}


}
