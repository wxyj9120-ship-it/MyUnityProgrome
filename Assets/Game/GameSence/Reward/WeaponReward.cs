using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponReward : MonoBehaviour
{
    public GameObject[] weapon;
    public GameObject geteff;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            //随机一个武器
            int index = Random.Range(0, weapon.Length);
            Playerobj player = other.GetComponent<Playerobj>();
            player.ChangeWeapon(weapon[index]);
            //获取特效
            GameObject eff = Instantiate(geteff,this.transform.position,this.transform.rotation);
            //关联音效
            AudioSource source = eff.GetComponent<AudioSource>();
            source.volume = GameDateAll.Instance.musicDate.songVolume;
            source.mute = !GameDateAll.Instance.musicDate.isOnsong;
            //销毁音效
            Destroy(eff, source.clip.length);
            //销毁
            Destroy(this.gameObject);
        }
    }
}
