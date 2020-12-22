using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//シーンマネジメントを有効にする

public class ed : MonoBehaviour
{

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetMouseButtonDown(1) || Input.GetKeyDown("space") || Input.GetButtonDown("Action1") || Input.GetButtonDown("Jump")) //スペースキー、Aボタン、ジャンプボタンを押した場合
		{
			SceneManager.LoadScene("ed");
		}

	}
}
