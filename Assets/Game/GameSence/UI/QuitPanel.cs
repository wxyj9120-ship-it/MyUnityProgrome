using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitPanel : BasePanel<QuitPanel>
{
    public Custom_Button btQuit;
    public Custom_Button btOn;
    public Custom_Button btclose;
    // Start is called before the first frame update
    void Start()
    { 
        btQuit.ClickEvent += () =>
        {
            //返回主界面
            SceneManager.LoadScene("BeginGame");
        };

        btOn.ClickEvent +=() =>
        {
            //返回游戏
            HideMe();
            Time.timeScale = 1;
        };
 
        btclose.ClickEvent += () =>
        {
            //返回游戏
            HideMe();
            Time.timeScale = 1;
        };
        HideMe();
    }
}
