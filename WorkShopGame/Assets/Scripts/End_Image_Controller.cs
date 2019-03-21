using System.Collections;
using System.Collections.Generic;
using Fungus;
using UnityEngine;
using UnityEngine.UI;

public class End_Image_Controller : MonoBehaviour
{

	public  Image _endImage;

	public  Sprite _goodEndImage;
	public  Sprite _badEndImage;
	public  Sprite _mediumEndImage;
	

	public  void GoodEnd()
	{
		_endImage.sprite = _goodEndImage;
		ShowImage();
	}

	public  void BadEnd()
	{
		_endImage.sprite = _badEndImage;
		ShowImage();
	}

	public  void MediumEnd()
	{
		_endImage.sprite = _mediumEndImage;
		ShowImage();
	}

	public void ShowImage()
	{
		_endImage.gameObject.SetActive(true);
		Time.timeScale = 0;

	}
	
	// Use this for initialization
	void Start ()
	{
		_endImage.gameObject.SetActive(false);
		GoodEnd();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown(KeyCode.A)) 
		{
			ShowImage();
		}
	}
}
