using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Custom_Single_Toggle : MonoBehaviour
{
   public Custom_Toggle[] toggles;
    private Custom_Toggle beforetoggle;
    void Start()
    {
        for(int i = 0; i < toggles.Length; i++)
        {
            Custom_Toggle toggle = toggles[i];
            toggle.changeison += (value) =>
            {
                //当传入的是ture时，把其他toggle的状态设置为false
                if (value)
                {
                    //当当前toggle被选中时，取消其他toggle的选中状态
                    for(int j = 0; j < toggles.Length; j++)
                    {
                        if(j != i)
                        {
                            toggles[j].isOn = false;
                        }
                    }
                    //记录之前的选中toggle
                    beforetoggle = toggle;
                }
                else
                {
                    //保证至少有一个toggle被选中，如果当前toggle被取消选中，则将之前的选中toggle重新设置为选中状态
                    if (beforetoggle == value)
                    {
                        toggle.isOn = true;
                    }
                }
            };
        }
       
    }

}
