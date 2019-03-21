using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarGlowScript : MonoBehaviour
{

	private Image _image;
	public float GlowThreshold = 1.0f;
	public Sprite GlowSprite;
	private bool _isChanged = false;
	
	// Use this for initialization
	void Awake ()
	{
		_image = this.gameObject.GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {
		if (!_isChanged)
		{
			if (_image.fillAmount >= GlowThreshold)
			{
				_image.sprite = GlowSprite;
			}			
		}

	}
}
