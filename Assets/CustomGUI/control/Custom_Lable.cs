using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Custom_Lable : CustomGUI_control
{
    protected override void StyleOffDrow()
    {
        GUI.Label(guipos.Pos, content);
    }

    protected override void StyleOnDrow()
    {
        GUI.Label(guipos.Pos, content,style);
    }
}
