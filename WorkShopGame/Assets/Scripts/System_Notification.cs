using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class System_Notification : MonoBehaviour
{
	private System_Notification _instance;

	public Canvas _mainCanvas;
	
	public GameObject _popUpDialog;

	public GameObject _simpleText;
	
	public System_Notification Instance
	{
		get 
		{
			if (_instance!= null) 
			{
				return _instance; 
			}
			else
			{
				_instance = new System_Notification();
				return _instance;
			}
		}
	}

	private void BasicComment(string texts)
	{
		var text = _popUpDialog.GetComponentInChildren<Text>();
		text.text = texts;
		//text.transform.localScale = new Vector3(0.009f,0.009f,0.009f);
		var bg = _popUpDialog.GetComponentInChildren<Image>();
		bg.GetComponent<RectTransform>().sizeDelta = new Vector2(text.preferredWidth + 100, text.preferredHeight + 50);
		//bg.transform.localScale = new Vector3(0.009f,0.009f,0.009f);
		var game_object = Instantiate(_popUpDialog, this.transform.position, Quaternion.identity);
		game_object.transform.localScale = new Vector3(1,1,1);
		game_object.transform.parent = _mainCanvas.transform;
		game_object.SetActive(true);
	}
	
	
	// Use this for initialization
	void Start () {
		BasicComment("果汁工厂被入侵啦！！！!\n 怎么办呀！！！");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
