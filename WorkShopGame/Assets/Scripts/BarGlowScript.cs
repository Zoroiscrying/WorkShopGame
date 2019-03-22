using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarGlowScript : MonoBehaviour
{

	private Image _image;
	public float GlowThreshold=1.0f;
	public Sprite GlowSprite;
	private bool _isChanged = false;
	//private string myBarName;
	
	// Use this for initialization
	void Awake ()
	{
		//myBarName = this.gameObject.name;
		_image = this.gameObject.GetComponent<Image>();
//		switch (myBarName)
//		{
//			case "ProgressBarRed":
//
//				break;
//			case "ProgressBarGreen":
//				break;
//			case "ProgressBarYellow":
//				break;
//			case "ProgressBarPurple":
//				break;
//			
//		}
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (!_isChanged)
		{
			
			if (_image.fillAmount >= GlowThreshold)
			{
				Debug.Log(_image.fillAmount);
				_image.sprite = GlowSprite;
				_isChanged = true;
			}			
		}

	}
}
