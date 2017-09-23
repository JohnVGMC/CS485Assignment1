using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour {

	public GameObject rollABallInfo;
	public GameObject customGameInfo;

	// Use this for initialization
	void Start () {
		rollABallInfo.SetActive (false);
		customGameInfo.SetActive (false);
	}

	public void LaunchRollABall()
	{
		SceneManager.LoadSceneAsync ("RollABallMiniGame");
	}

	public void LaunchCustomGame()
	{
		SceneManager.LoadSceneAsync ("2DUFOCustom");
	}

	// Update is called once per frame
	void Update () {
		
	}
}
