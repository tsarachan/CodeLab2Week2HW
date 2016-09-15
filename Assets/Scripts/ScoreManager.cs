using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour {

	Text score;

	int currentScore = 0;
	public int maxScore = 9999;

	void Start()
	{
		score = GetComponent<Text>();
		score.text = currentScore.ToString();
	}

	public void UpdateScore(int amount)
	{
		currentScore += amount;
		if (currentScore <= maxScore) { score.text = currentScore.ToString(); }
		else
		{
			currentScore = currentScore - maxScore;
			score.text = currentScore.ToString();
		}
	}


}
