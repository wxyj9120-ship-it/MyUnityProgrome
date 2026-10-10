using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Custom_Texture : CustomGUI_control
{
    public ScaleMode scaleMode = ScaleMode.StretchToFill;
    public bool alpha = true;
    public float wightAndhight = 0;
    
    protected override void StyleOffDrow()
    {
        GUI.DrawTexture(guipos.Pos, content.image, scaleMode);
    }

    protected override void StyleOnDrow()
    {
        GUI.DrawTexture(guipos.Pos, content.image, scaleMode,alpha,wightAndhight);
    }
}
