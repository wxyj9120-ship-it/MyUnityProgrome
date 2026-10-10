using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//排行榜单条数据
public class RankInfo
{
    public string name;
    public int mouse;
    public float time;
    
    public RankInfo()
    {

    }
    public  RankInfo(string name, int mouse, float time)
    {
        this.name = name;
        this.mouse = mouse;
        this.time = time;
    }
    public class RankList
    {
        public List<RankInfo> rankList;
     }
}
