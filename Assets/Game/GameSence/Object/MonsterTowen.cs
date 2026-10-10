using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterTowen : Tankbase
{
    //间隔时间
    public float fireInterval = 1;
    public float nowTime = 0;
    //子弹发射位置
    public Transform[] shootPos;
    //子弹预设体关联
    public Bulletobj shoot;
    void Update()
    {
        //设置间隔时间
        nowTime += Time.deltaTime;
        if(nowTime > fireInterval)
        {
            Fire();
            nowTime = 0;
        }
    }
    public override void Fire()
    {
      for(int i = 0; i < shootPos.Length; i++)
        {
            //创建子弹预设体
            Bulletobj obj = Instantiate(shoot, shootPos[i].transform.position, shootPos[i].transform.rotation);
            //明确父对象
            Bulletobj bullet = obj.GetComponent<Bulletobj>();
            bullet.Setfather(this);
        }
    }
    public override void FireHold()
    {
        
    }
    public override void Wound(Tankbase other)
    {
        //什么都不写 让他无法受伤
    }
}
