using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//所见即所得的GUI系统的根节点脚本
[ExecuteAlways]
public class CustomGUI_Root : MonoBehaviour
{
    //存储所有的控件
    private CustomGUI_control[] allcontrols;
    // Start is called before the first frame update
    void Start()
    {
        //得到所有子对象控件的父对象脚本
        allcontrols = this.GetComponentsInChildren<CustomGUI_control>();
    }
    private void OnGUI()
    {
        //在编辑器模式下，OnGUI方法才会被频繁调用
        //if (!Application.isPlaying)
        //{
         allcontrols = this.GetComponentsInChildren<CustomGUI_control>();
        //}
        
        for(int i = 0; i < allcontrols.Length; i++)
        {
            allcontrols[i].DrowGUI();
        }
    }
}
