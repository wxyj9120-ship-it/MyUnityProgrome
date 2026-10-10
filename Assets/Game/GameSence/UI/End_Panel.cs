using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class End_Panel : BasePanel<End_Panel>
{
    public Custom_input Input;
    public Custom_Button Button;
    // Start is called before the first frame update
    void Start()
    {
        Button.ClickEvent += () =>
        {
            Time.timeScale = 1;  
            GameDateAll.Instance.AddRankInfo(Input.content.text,GamePanel.Instance.nowsouse,GamePanel.Instance.nowtime);
            SceneManager.LoadScene("BeginGame");
        };
        HideMe();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
