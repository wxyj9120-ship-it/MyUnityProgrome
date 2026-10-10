using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Custom_Toggle : CustomGUI_control
{
    public bool isOn = false;
    public event UnityAction<bool> changeison;
    private bool lastison = false;
    protected override void StyleOffDrow()
    {
        isOn = GUI.Toggle(guipos.Pos, isOn, content);
        //只有当状态发生改变时才会触发事件
        if (lastison != isOn)
        {
            changeison?.Invoke(isOn);
            lastison = isOn;
        }
    }

    protected override void StyleOnDrow()
    {
        isOn = GUI.Toggle(guipos.Pos, isOn, content,style);
        if (lastison != isOn)
        {
            changeison?.Invoke(isOn);
            lastison = isOn;
        }
    }
}
