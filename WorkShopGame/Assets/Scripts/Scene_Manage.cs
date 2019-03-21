using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Animations;
using UnityEngine.SceneManagement;


public class Scene_Manage : MonoBehaviour
{

	public GameObject _pausePanel;
	private Animator _pausePanelAnimator;
	
	public void LoadPlayScene()
	{
		SceneManager.LoadScene(1);	
	}

	public void LoadStartScene()
	{
		SceneManager.LoadScene(0);	
	}

	public void LoadEndScene()
	{
		SceneManager.LoadScene(2);	
	}

	public void Pause()
	{
		//Debug.Log("设置时间为0");
		Time.timeScale = 0;
		Music.Pause();
		//this.gameObject.SetActive(true);
		_pausePanel.SetActive(true);
		//_pausePanelAnimator.SetBool("IsPaused",true);
	}

	public void Resume()
	{
		Time.timeScale = 1;
		//_pausePanelAnimator.SetBool("IsPaused",false);
		_pausePanel.SetActive(false);
		Music.Play(Music.CurrentMusicName);
	}
	
	public void Quit()
	{
		Application.Quit();
	}
	
	public void RestartThisScene()
	{		
		_pausePanel.SetActive(false);
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		Destroy(this.gameObject);
	}
	
	// Use this for initialization
	private void Awake()
	{
		_pausePanel.SetActive(false);
		//DontDestroyOnLoad(this);
		//DontDestroyOnLoad(this.gameObject);
		_pausePanelAnimator = _pausePanel.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.R))
		{
			this.RestartThisScene();
			this.Resume();
		}

		if (Input.GetKeyDown(KeyCode.P))
		{
			this.Pause();
		}
		
	}
}
