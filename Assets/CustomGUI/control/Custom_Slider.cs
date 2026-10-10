using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum E_SliderType
{
    Horizontal,
    Vertical,
}
public class Custom_Slider : CustomGUI_control
{
    public float minValue = 0;
    public float maxValue = 1;
    public float nowValue = 0;
    public E_SliderType E_Slider = E_SliderType.Horizontal;
    //小按钮的样式
    public GUIStyle buttonStyel;
    public UnityAction<float> valuechange;
    private float lastValue;
    protected override void StyleOffDrow()
    {
        switch(E_Slider)
        {
            case E_SliderType.Horizontal:
                nowValue = GUI.HorizontalSlider(guipos.Pos, nowValue, minValue, maxValue);
                break;
            case E_SliderType.Vertical:
                nowValue = GUI.VerticalSlider(guipos.Pos, nowValue, minValue, maxValue);
                break;
        }
        if (lastValue != nowValue)
        {
            valuechange?.Invoke(nowValue);
            lastValue = nowValue;
        }
    }

    protected override void StyleOnDrow()
    {
        switch (E_Slider)
        {
            case E_SliderType.Horizontal:
                nowValue = GUI.HorizontalSlider(guipos.Pos, nowValue, minValue, maxValue,style,buttonStyel);
                break;
            case E_SliderType.Vertical:
                nowValue = GUI.VerticalSlider(guipos.Pos, nowValue, minValue, maxValue,style,buttonStyel);
                break;
        }
        if (lastValue != nowValue)
        {
            valuechange?.Invoke(nowValue);
            lastValue = nowValue;
        }
    }
}
