using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Custom_Button : CustomGUI_control
{
    //提供给外部的点击事件 只要外部给予函数 那就会执行
    public event UnityAction ClickEvent;
    
    protected override void StyleOffDrow()
    {
       if(GUI.Button(guipos.Pos, content))
        {
            //？判断ClickEvent是否为空 如果不为空就执行
            ClickEvent?.Invoke();
        }
    }

    protected override void StyleOnDrow()
    {
        if (GUI.Button(guipos.Pos, content,style))
        {
            ClickEvent?.Invoke();
        }
    }
}
