using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static RankInfo;

//总的游戏数据管理类
public class GameDateAll
{
    private static GameDateAll instance = new GameDateAll();
    public static GameDateAll Instance { get => instance; }
    //音乐数据
    public MusicDate musicDate;
    //排行榜数据
    public RankList rankDate;
    private GameDateAll()
    {
        //初始化音乐数据
        musicDate = PlayerprefDataMgr.Instance.LoadDate(typeof(MusicDate), "Music") as MusicDate;
        //判断是否第一次打开游戏，如果是第一次打开游戏，则初始化音乐数据，并保存到本地
        if (!musicDate.isFirstOpen)
        {
            musicDate.isFirstOpen = true;
            musicDate.isOnsing = true;
            musicDate.isOnsong = true;
            musicDate.singVolume = 1;
            musicDate.songVolume = 1;
            PlayerprefDataMgr.Instance.SaveDate(musicDate,"Music");
        }
       //初始化排行榜数据
        rankDate = PlayerprefDataMgr.Instance.LoadDate(typeof(RankList), "Rank") as RankList;
    }
    //存储排行榜信息
    public void AddRankInfo(string name,int mouse,float time)
    {
        rankDate.rankList.Add(new RankInfo(name, mouse, time));
        //排序
        rankDate.rankList.Sort ((a, b) => a.time < b.time ? 1 : -1);
        //去除超出10行
        for (int i = rankDate.rankList.Count - 1;i >= 10; i--)
        {
            rankDate.rankList.RemoveAt(i);
        }
        PlayerprefDataMgr.Instance.SaveDate(rankDate, "Rank");
    }
    //写几个API，方便外部调用，修改音乐数据，并保存到本地
    //开关音乐
    public void OpenorCloseSing(bool isOn)
    {
        musicDate.isOnsing = isOn;
        BackMusic.Instance.Isopen(musicDate.isOnsing);
        PlayerprefDataMgr.Instance.SaveDate(musicDate,"Music");
    }
    //开关音效
    public void OpenorCloseSong(bool isOn)
    {
        musicDate.isOnsong = isOn;
        PlayerprefDataMgr.Instance.SaveDate(musicDate,"Music");
    }
    //设置音乐音量
    public void SetSingVolume(float volume)
    {
        musicDate.singVolume = volume;
        BackMusic.Instance.ChangeValue(musicDate.singVolume);
        PlayerprefDataMgr.Instance.SaveDate(musicDate,"Music");
    }
    //设置音效音量
    public void SetSongVolume(float volume)
    {
        musicDate.songVolume = volume;
        PlayerprefDataMgr.Instance.SaveDate(musicDate,"Music");
    }
}
