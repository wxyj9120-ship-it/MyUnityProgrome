using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum E_Style
{
    On,
    Off,
}
public abstract class CustomGUI_control : MonoBehaviour
{
    //位置信息
    public CustomGUI_pos guipos;
    //显示内容信息
    public GUIContent content;
    //自定义样式信息
    public GUIStyle style;
    public E_Style e_style = E_Style.Off;
    //提供给外部绘制GUI的方法
    public void DrowGUI()
    {
        switch (e_style)
        {
            case E_Style.On:
                StyleOnDrow();
                break;
            case E_Style.Off:
                StyleOffDrow();
            break;
        }
        
}
        protected abstract void StyleOnDrow();
        protected abstract void StyleOffDrow();  
}
