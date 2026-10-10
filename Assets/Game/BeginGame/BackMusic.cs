using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackMusic : MonoBehaviour
{
    private static BackMusic instance;
    public static BackMusic Instance => instance;
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
        audioSource = GetComponent<AudioSource>();
        // 根据存储的数据初始化
        ChangeValue(GameDateAll.Instance.musicDate.singVolume);
        Isopen(GameDateAll.Instance.musicDate.isOnsing);
    }
    //改变背景音乐大小
    public void ChangeValue(float value)
    {
        audioSource.volume = value;
    }
    //开关背景音乐
    public void Isopen(bool Inon)
    {
        //是否静音
        audioSource.mute = !Inon;
    }
}
