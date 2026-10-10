using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monsterobj : Tankbase
{
    //让坦克在两个点之间移动
    //目标点
    public Transform targetpos;
    //移动点
    public Transform[] randompos;
    //让坦克始终对着玩家
    public Transform LookAtget;
    //让坦克间隔开火
    public float LookAtset;
    //间隔时间
    public float fireInterval = 1;
    public float nowTime = 0;
    //子弹发射位置
    public Transform[] shootPos;
    //子弹预设体关联
    public Bulletobj shoot;
    //图片
    public Texture maxhpBK;
    public Texture hpBK;
    private Rect maxhprect;
    private Rect hprect;
    //计算受伤血条显示时间
    private float showtime = 0;
    // Start is called before the first frame update
    void Start()
    {
        RandomPos();
    }

    // Update is called once per frame
    void Update()
    {
        //看向目标点
        this.transform.LookAt(targetpos);
        //一直移动
        this.transform.Translate(Vector3.forward * movespeed * Time.deltaTime);
        //如果小于某个距离就判断重合了
        if(Vector3.Distance(this.transform.position,targetpos.position)< 0.05f)
        {
            RandomPos();
        }
        //看向玩家
        if(LookAtget != null)
        {
            tankhead.LookAt(LookAtget);

            //判断小于距离就开火
            if (Vector3.Distance(this.transform.position, LookAtget.position) < LookAtset)
            {
                //设置间隔时间
                nowTime += Time.deltaTime;
                if (nowTime > fireInterval)
                {
                    Fire();
                    nowTime = 0;
                }
            }
        }
    }
    private void RandomPos()
    {
        if(randompos == null)
        {
            return;
        }
        targetpos = randompos[Random.Range(0,randompos.Length)];
    }

    public override void Fire()
    {
        for (int i = 0; i < shootPos.Length; i++)
        {
            //创建子弹预设体
            Bulletobj obj = Instantiate(shoot, shootPos[i].transform.position, shootPos[i].transform.rotation);
            //明确父对象
            Bulletobj bullet = obj.GetComponent<Bulletobj>();
            bullet.Setfather(this);
        }
    }
    //死亡后加分
    public override void Die()
    {
        base.Die();
        GamePanel.Instance.Addsouse(10);
    }
    public override void FireHold()
    {
       
    }
    //画血条
    private void OnGUI()
    {
        if(showtime > 0)
        {
            showtime -= Time.deltaTime; 
            Vector3 screenpos = Camera.main.WorldToScreenPoint(this.transform.position);
            screenpos.y = Screen.height - screenpos.y;
            //绘制
            maxhprect.x = screenpos.x - 50;
            maxhprect.y = screenpos.y - 50;
            maxhprect.width = 100;
            maxhprect.height = 10;
            GUI.DrawTexture(maxhprect, maxhpBK);
            hprect.x = screenpos.x - 50;
            hprect.y = screenpos.y - 50;
            hprect.width = (float)hp / maxhp * 100f;
            hprect.height = 15;
            GUI.DrawTexture(hprect, hpBK);
        }
    }
    public override void Wound(Tankbase other)
    {
        base.Wound(other);
        showtime = 3;
    }
}
