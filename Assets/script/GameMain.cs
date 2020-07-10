using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMain : MonoBehaviour
{
	public int stage_id;

	void Start()
	{
		GameObject.Find("txtGoal").GetComponent<Text>().text = "";
	}
	public void OnGoal()
	{
		Debug.Log("GameMain.OnGoal");
		GameObject.Find("txtGoal").GetComponent<Text>().text = "GOAL!!!";

		GameObject.Find("Player").GetComponent<PlayerControl>().is_goal = true;

		StartCoroutine(NextStage(3.0f, stage_id + 1));
	}

	private IEnumerator NextStage(float _fDelaySeconds , int _iStageId)
	{
		yield return new WaitForSeconds(_fDelaySeconds);

		UnityEngine.SceneManagement.SceneManager.LoadScene(string.Format("stage_{0}", _iStageId));
	}
}
