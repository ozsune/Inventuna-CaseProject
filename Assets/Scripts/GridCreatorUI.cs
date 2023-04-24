using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridCreatorUI : MonoBehaviour
{
    [SerializeField] private Slider heightSlider;
    [SerializeField] private Text heightText;
    
    [SerializeField] private Slider widthSlider;
    [SerializeField] private Text widthText;
    
    [SerializeField] private GridGenerator gridGenerator;
    public void Create()
    {
        gridGenerator.Generate((int)heightSlider.value, (int)widthSlider.value);
    }
    
    public void Start()
    {
        SetSlider(heightSlider, GridBorder.MaxHeight, GridBorder.MinHeight);
        SetSlider(widthSlider, GridBorder.MaxWidth, GridBorder.MinWidth);
        
        heightSlider.onValueChanged.AddListener(delegate {GetSliderValue(heightSlider, heightText); });
        widthSlider.onValueChanged.AddListener(delegate {GetSliderValue(widthSlider, widthText); });
    }

    private void SetSlider(Slider slider, int max, int min)
    {
        slider.maxValue = max;
        slider.minValue = min;
    }

    private void GetSliderValue(Slider slider, Text text)
    {
        text.text = slider.value.ToString();
    }
}
