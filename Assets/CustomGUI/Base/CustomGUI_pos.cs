using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum E_Alignment_Type
{
    Up,
    Down,
    Left,
    Right,
    Center,
    Left_Up,
    Left_Down,
    Right_Up,
    Right_Down,
}
[System.Serializable]
public class CustomGUI_pos
{
   
    private Rect rpos = new Rect(0, 0, 100, 100);
    public E_Alignment_Type E_Control_Alignment_Type = E_Alignment_Type.Center;
    public E_Alignment_Type E_Screen_Alignment_Type = E_Alignment_Type.Center;
    public Vector2 pos;
    public float width = 100;
    public float height = 60;
    private Vector2 screenpos;
    //控件位置
    private void ControlPos()
    {
        switch (E_Control_Alignment_Type)
        {
            case E_Alignment_Type.Up:
                screenpos.x = -width / 2;
                screenpos.y = 0;
                break;
            case E_Alignment_Type.Down:
                screenpos.x = -width / 2;
                screenpos.y = -height;
                break;
            case E_Alignment_Type.Left:
                screenpos.x = 0;
                screenpos.y = -height / 2;
                break;
            case E_Alignment_Type.Right:
                screenpos.x = -width;
                screenpos.y = -height / 2;
                break;
            case E_Alignment_Type.Center:
                screenpos.x = -width / 2;
                screenpos.y = -height / 2;
                break;
            case E_Alignment_Type.Left_Up:
                screenpos.x = 0;
                screenpos.y = 0;
                break;
            case E_Alignment_Type.Left_Down:
                screenpos.x = 0;
                screenpos.y = -height;
                break;
            case E_Alignment_Type.Right_Up:
                screenpos.x = -width;
                screenpos.y = 0;
                break;
            case E_Alignment_Type.Right_Down:
                screenpos.x = -width;
                screenpos.y = -height;
                break;
        }
    }
    //屏幕位置
    private void ScreenPos()
    {
        switch (E_Screen_Alignment_Type)
        {
            case E_Alignment_Type.Up:
                rpos.x = Screen.width / 2 + screenpos.x + pos.x;
                rpos.y = 0 + screenpos.y + pos.y;
                break;
            case E_Alignment_Type.Down:
                rpos.x = Screen.width / 2 + screenpos.x + pos.x;
                rpos.y = Screen.height + screenpos.y - pos.y;
                break;
            case E_Alignment_Type.Left:
                rpos.x = screenpos.x + pos.x;
                rpos.y = Screen.height / 2 + screenpos.y + pos.y;
                break;
            case E_Alignment_Type.Right:
                rpos.x = Screen.width + screenpos.x - pos.x;
                rpos.y = Screen.height / 2 + screenpos.y + pos.y;
                break;
            case E_Alignment_Type.Center:
                rpos.x = Screen.width / 2 + screenpos.x + pos.x;
                rpos.y = Screen.height / 2 + screenpos.y + pos.y;
                break;
            case E_Alignment_Type.Left_Up:
                rpos.x = screenpos.x + pos.x;
                rpos.y = screenpos.y + pos.y;
                break;
            case E_Alignment_Type.Left_Down:
                rpos.x = screenpos.x + pos.x;
                rpos.y = Screen.height / 2 + screenpos.y - pos.y;
                break;
            case E_Alignment_Type.Right_Up:
                rpos.x = Screen.width + screenpos.x - pos.x;
                rpos.y = 0 + screenpos.y + pos.y;
                break;
            case E_Alignment_Type.Right_Down:
                rpos.x = Screen.width + screenpos.x - pos.x;
                rpos.y = Screen.height + screenpos.y - pos.y;
                break;
        }
    }
    //绘制位置
    public Rect Pos
    {
        get
        {
            ControlPos();
            ScreenPos();
            rpos.width = width;
            rpos.height = height;
            return rpos;
        }
    }

}

