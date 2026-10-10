using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoosePanel : BasePanel<LoosePanel>
{
    public Custom_Button Button1;
    public Custom_Button Button2;
    // Start is called before the first frame update
    void Start()
    {
        Button1.ClickEvent += () =>
        {
            Time.timeScale = 1;
            SceneManager.LoadScene("BeginGame");

        };
        Button2.ClickEvent += () =>
        {
            Time.timeScale = 1;
            SceneManager.LoadScene("Game");
        };
        HideMe();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
