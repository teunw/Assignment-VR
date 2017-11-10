using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class BalloonScore
{
	public DateTime Timestamp;
	public int Score;
	public BalloonScore(DateTime? timestamp = null, int score = 1)
	{
		if (timestamp == null)
		{
			Timestamp = DateTime.Now;
		}
		else
		{
			this.Timestamp = timestamp.Value;
		}
		Score = score;
	}
}

[RequireComponent(typeof(Text))]
public class BalloonScoreKeeper : MonoBehaviour
{
	public Text ScoreText;
	public Text ScorePerMinuteText;
	private List<BalloonScore> Scores = new List<BalloonScore>();

	public void AddPoint(int point = 1)
	{
		Scores.Add(new BalloonScore(null, point));
		SyncScore();
	}

	private int GetScore()
	{
		var totalScore = 0;
		Scores.ForEach(s => totalScore += s.Score);
		return totalScore;
	}

	public void ResetScore()
	{
		Scores.Clear();
		SyncScore();
	}

	public float GetScorePerMinute()
	{
		if (Scores.Count < 2) return 0f;
		Scores.Sort((score1, score2) => score1.Timestamp.CompareTo(score2.Timestamp));
		var firstScore = Scores.First();
		var lastScore = Scores.Last();
		var totalScore = GetScore();
		var minutesSpent = lastScore.Timestamp.Subtract(firstScore.Timestamp).TotalMinutes;
		return (float) (totalScore / minutesSpent);
	}

	public void SyncScore()
	{
		ScoreText.text = GetScore().ToString();
	}

	public void Update()
	{
		ScorePerMinuteText.text = GetScorePerMinute().ToString(CultureInfo.CurrentCulture);
	}
}
