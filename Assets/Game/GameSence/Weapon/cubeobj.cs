using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cubeobj : MonoBehaviour
{
    //奖励
    public GameObject[] weapons;
    //死亡特效
    public GameObject Deareff;
    private int Die = 0;
    private void OnTriggerEnter(Collider other)
    {
        Die++;
        if(Die == 5)
        {
            //随机生成奖励
            int random = Random.Range(0, 100);
            if (random <= 40)
            {
                random = Random.Range(0, weapons.Length);
                Instantiate(weapons[random], this.transform.position, this.transform.rotation);
            }
            //获取音效
            GameObject eff = Instantiate(Deareff, this.transform.position, this.transform.rotation);
            //关联音效
            AudioSource source = eff.GetComponent<AudioSource>();
            source.volume = GameDateAll.Instance.musicDate.songVolume;
            source.mute = !GameDateAll.Instance.musicDate.isOnsong;
            //销毁音效
            Destroy(eff, source.clip.length);
            //销毁自己
            Destroy(gameObject);
        }
    }
}
