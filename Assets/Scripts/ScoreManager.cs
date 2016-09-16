using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour {

	Text score;

	int currentScore = 0;
	public int maxScore = 9999;

	int basicIncrement = 1;
	public int BasicIncrement { get; set; }

	GameObject scoreFeedback;

	void Start() {
		score = GetComponent<Text>();
		score.text = currentScore.ToString();
		scoreFeedback = Resources.Load("Score feedback") as GameObject;
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
		GameObject newScoreFeedback = Instantiate(scoreFeedback, loc, Quaternion.identity) as GameObject;
		newScoreFeedback.transform.SetParent(transform.root.Find("Score feedback canvas"), false);
		newScoreFeedback.GetComponent<Text>().text = amount.ToString();
	}


}
