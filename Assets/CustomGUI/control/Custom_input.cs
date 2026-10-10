using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Custom_input : CustomGUI_control
{
    public UnityAction stringchange;
    private string laststring = "";
    protected override void StyleOffDrow()
    {
        content.text = GUI.TextField(guipos.Pos, content.text);
        if(laststring != content.text)
        {
            stringchange?.Invoke();
            laststring = content.text;
        }
    }

    protected override void StyleOnDrow()
    {
        content.text = GUI.TextField(guipos.Pos, content.text,style);
        if (laststring != content.text)
        {
            stringchange?.Invoke();
            laststring = content.text;
        }
    }
}
