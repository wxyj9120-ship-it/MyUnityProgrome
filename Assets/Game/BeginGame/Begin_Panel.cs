using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Begin_Panel : BasePanel<Begin_Panel>
{
    public Custom_Button beginButton;
    public Custom_Button setinButton;
    public Custom_Button endButton;
    public Custom_Button rinkButton;
    // Start is called before the first frame update
    void Start()
    {
        //注册按钮点击事件
        beginButton.ClickEvent += () =>
        {
            //切换到游戏场景
            SceneManager.LoadScene("Game");
        };
        setinButton.ClickEvent += () =>
        {
            //打开设置面板
           Set_Panel.Instance.ShowMe();
            //隐藏自己，避免穿透
            HideMe();
            
        };
        endButton.ClickEvent += () =>
        {
            //退出游戏
            Application.Quit();
        };
        rinkButton.ClickEvent += () =>
        {
            //打开排行榜面板
            Rank_Panel.Instance.ShowMe();
            HideMe();
        };
    }
}
