using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBalloonPistolScoreMessage
{
	void OnBalloonPoppedByPistol(GameObject gm);
}
public class BalloonPistolScore : MonoBehaviour, IBalloonPistolScoreMessage
{
	public BalloonScoreKeeper BalloonScoreKeeper;
	public const string OnBalloonPoppedByPistolConst = "OnBalloonPoppedByPistol";

	public void OnBalloonPoppedByPistol(GameObject gm)
	{
		BalloonScoreKeeper.AddPoint(1);
	}
}
