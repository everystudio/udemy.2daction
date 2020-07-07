using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMain : MonoBehaviour
{
	void Start()
	{
		GameObject.Find("txtGoal").GetComponent<Text>().text = "";
	}
	public void OnGoal()
	{
		Debug.Log("GameMain.OnGoal");
		GameObject.Find("txtGoal").GetComponent<Text>().text = "GOAL!!!";



	}
}
