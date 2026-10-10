using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//存储音乐信息的类
public class MusicDate
{
    public bool isOnsing; //是否播放音乐
    public bool isOnsong;//是否播放音效
    public float singVolume; //音乐音量
    public float songVolume; //音效音量
    public bool isFirstOpen = false; //是否第一次打开游戏
}
