using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class SliderTextSynchronizer : MonoBehaviour
{

    public Slider Slider;
	public int RoundTo = 2;
	
	private Text _text;

	void Start()
	{
		_text = GetComponent<Text>();
	}

	void Update()
	{
		_text.text= Math.Round(Slider.value, RoundTo).ToString(CultureInfo.CurrentCulture);
	}
}
