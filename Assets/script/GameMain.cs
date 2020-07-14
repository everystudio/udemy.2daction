using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameMain : MonoBehaviour
{
	public int stage_id;

	public int key_num;

	void Start()
	{
		SceneManager.LoadScene("ui", LoadSceneMode.Additive);
	}
	public void OnGoal()
	{
		Debug.Log("GameMain.OnGoal");
		GameObject.Find("txtGoal").GetComponent<Text>().text = "GOAL!!!";
		GameObject.Find("Player").GetComponent<PlayerControl>().is_goal = true;
		StartCoroutine(NextStage(3.0f, stage_id + 1));
	}

	public void AddKey()
	{
		key_num += 1;
		Debug.Log(key_num);
		GameObject.Find("txtKeyNum").GetComponent<Text>().text = string.Format("x{0}", key_num);
	}

	public bool OpenLock()
	{
		if( 0 < key_num)
		{
			key_num -= 1;
			GameObject.Find("txtKeyNum").GetComponent<Text>().text = string.Format("x{0}", key_num);
			return true;
		}
		else
		{
			return false;
		}
	}

	private IEnumerator NextStage(float _fDelaySeconds , int _iStageId)
	{
		yield return new WaitForSeconds(_fDelaySeconds);

		UnityEngine.SceneManagement.SceneManager.LoadScene(string.Format("stage_{0}", _iStageId));
	}



}
