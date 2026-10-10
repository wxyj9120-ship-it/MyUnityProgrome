using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePanel : BasePanel<GamePanel>
{
    
    public Custom_Lable labesouse;
    public Custom_Lable labetime;
    //设置
    public Custom_Button buttonset;
    //退出
    public Custom_Button buttonesc;
    //血条
    public Custom_Texture texhp;

    public int hpw = 370;
    int time = 0;
    [HideInInspector]
    public int nowsouse = 0;
    [HideInInspector]
    public float nowtime = 0;
    void Start()
    {
        //事件监听
        buttonset.ClickEvent += () =>
        {
            Set_Panel.Instance.ShowMe();
            //将时间缩放值设为0 就是时间暂停
            Time.timeScale = 0;
        };
        buttonesc.ClickEvent += () =>
        {
            //返回游戏页面，弹个窗口
            QuitPanel.Instance.ShowMe();
            Time.timeScale = 0;
        };
     
    }

    void Update()
    {
        //更新时间
        nowtime += Time.deltaTime;
        //把时间 秒 转换成 小时 分钟 秒
        time = (int)nowtime;
        labetime.content.text = "";
        if (time / 3600 > 0)
        {
            labetime.content.text += time / 3600 + "时";
        }
        if (time % 3600 / 60 >= 0)
        {
            labetime.content.text += time % 3600 / 60 + "分";
        }
        labetime.content.text += time % 60 + "秒";
    }
    //更新分数
    public void Addsouse(int souse)
    {
        nowsouse += souse;
        labesouse.content.text = nowsouse.ToString();
    }
    //更新血量
    public void ChangeHP(int maxhp, int hp)
    {
       texhp.guipos.width  = (float)hp / maxhp * hpw;
    }
}
