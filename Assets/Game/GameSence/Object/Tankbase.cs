using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Tankbase : MonoBehaviour
{
    public int atk ;
    public int def  ;
    public int maxhp ;
    public int hp ;

    public Transform tankhead;

    public int movespeed = 100;
    public int roundspeed = 100;
    public int headroundspeed = 100;

    //死亡特效
    public GameObject dieefft;

    //开火
    public abstract void Fire();
    //持续开火
    public abstract void FireHold();
    //受伤
    public virtual void Wound(Tankbase other)
    {
        int demo = other.atk - this.def;
        if (demo > 0)
        {
            hp -= demo;
        }
        else
        {
            return;
        }
        if (hp < 0)
        {
            hp = 0;
            Die();
        }
    }
    //死亡
    public virtual void Die()
    {
        Destroy(this.gameObject);
        //播放死亡特效
        if(dieefft != null)
        {
            //实例化对象时 设置死亡特效的位置和角度
            GameObject effobj = Instantiate(dieefft,this.transform.position,this.transform.rotation);
            //设置死亡音乐和音效
            AudioSource audioSource = effobj.GetComponent<AudioSource>();
            audioSource.volume = GameDateAll.Instance.musicDate.singVolume;
            audioSource.mute = !GameDateAll.Instance.musicDate.isOnsing;
            //防止音乐没开
            audioSource.Play();
        }
    }
}
