using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Timeline;

public class Set_Panel : BasePanel<Set_Panel>
{
    public Custom_Slider singslider;
    public Custom_Slider songslider;
    public Custom_Toggle singtoggle;
    public Custom_Toggle songtoggle;
    public Custom_Button backButton;

    // Start is called before the first frame update
    void Start()
    {
        singslider.valuechange += (value) =>
        {
            //设置音乐音量
            GameDateAll.Instance.SetSingVolume(value);
        };
        songslider.valuechange += (value) =>
        {
            //设置背景音乐音量
            GameDateAll.Instance.SetSongVolume(value);
        };
        singtoggle.changeison += (isOn) =>
        {
            //设置音乐开关
            GameDateAll.Instance.OpenorCloseSing(isOn);
        };
        songtoggle.changeison += (isOn) =>
        {
            //设置背景音乐开关
            GameDateAll.Instance.OpenorCloseSong(isOn);
        };
        backButton.ClickEvent += () =>
        {
            //关闭设置面板
            HideMe();
            //判断是在游戏界面还是开始界面
            if(SceneManager.GetActiveScene().name == "BeginGame")
            {
            //显示开始面板
            Begin_Panel.Instance.ShowMe();
            }
            Time.timeScale = 1;
        };

        HideMe();
    }
    public void UpdatePanel()
    {
        MusicDate date = GameDateAll.Instance.musicDate;
        singslider.nowValue = date.singVolume;
        songslider.nowValue = date.songVolume;
        singtoggle.isOn = date.isOnsing;
        songtoggle.isOn = date.isOnsong;
    }
    //每次显示面板时都要更新面板数据
    public override void ShowMe()
    {
        base.ShowMe();
        UpdatePanel();
    }
}
