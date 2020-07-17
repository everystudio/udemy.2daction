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
		GameObject.Find("txtMessage").GetComponent<Text>().text = "GOAL!!!";
		GameObject.Find("Player").GetComponent<PlayerControl>().is_goal = true;
		StartCoroutine(LoadStage(3.0f, stage_id + 1));
	}

	public void OnHitEnemy()
	{
		Debug.Log("GameMain.OnHitEnemy");
		GameObject.Find("txtMessage").GetComponent<Text>().text = "GAME OVER!!!";
		GameObject.Find("Player").GetComponent<Animator>().SetBool("dead",true);
		StartCoroutine(LoadStage(3.0f, stage_id));
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

	private IEnumerator LoadStage(float _fDelaySeconds , int _iStageId)
	{
		yield return new WaitForSeconds(_fDelaySeconds);

		UnityEngine.SceneManagement.SceneManager.LoadScene(string.Format("stage_{0}", _iStageId));
	}



}
