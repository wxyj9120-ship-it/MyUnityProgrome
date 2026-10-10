using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rank_Panel : BasePanel<Rank_Panel>
{
    public Custom_Button backButton;
    private List<Custom_Lable> lableName = new List<Custom_Lable>();
    private List<Custom_Lable> lableMouse = new List<Custom_Lable>();
    private List<Custom_Lable> lableTime = new List<Custom_Lable>();

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 1; i <= 10; i++)
        {
            //通过斜杠可以查找到子对象的子对象
            lableName.Add(transform.Find("Name/name" + i).GetComponent<Custom_Lable>());
            lableMouse.Add(transform.Find("Mouse/mouse" + i).GetComponent<Custom_Lable>());
            lableTime.Add(transform.Find("Time/time" + i).GetComponent<Custom_Lable>());
        }
        backButton.ClickEvent += () =>
        {
            HideMe();
            Begin_Panel.Instance.ShowMe();
        };
        //GameDateAll.Instance.AddRankInfo("我是", 200, 500);
        HideMe();
        
    }
    public void UpdatePanel()
    {
        //获取排行榜数据 用于更新排行榜面板
        List<RankInfo> rankList = GameDateAll.Instance.rankDate.rankList;
        for(int i = 0; i< rankList.Count; i++)
        {
            lableName[i].content.text = rankList[i].name;
            lableMouse[i].content.text = rankList[i].mouse.ToString();
            //把时间 秒 转换成 小时 分钟 秒
            int time = (int)rankList[i].time;
            lableTime[i].content.text = "";
            if(time / 3600 > 0)
            {
                lableTime[i].content.text += time / 3600 +"时";
            }
            if(time %3600 / 60 >= 0)
            {
                lableTime[i].content.text += time %3600 / 60 + "分";
            }
            lableTime[i].content.text += time % 60 + "秒";
        }
    }
    public override void ShowMe()
    {
        base.ShowMe();
        UpdatePanel();
    }
}
