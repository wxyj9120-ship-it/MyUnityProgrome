using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public enum E_Weapon_pops
{
    atk,
    def,
    hp
}
public class Weapon_pops : MonoBehaviour
{
    //设置枚举对象
    public E_Weapon_pops weapon = E_Weapon_pops.atk;
    public int chanangevalue = 2;
    public GameObject geteff;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Playerobj player = other.GetComponent<Playerobj>();
            switch(weapon)
            {
                case E_Weapon_pops.atk:
                    player.atk += chanangevalue;
                break;
                case E_Weapon_pops.def:
                    player.def += chanangevalue;
                break;
                case E_Weapon_pops.hp:
                    player.hp += chanangevalue;
                    //不能超过上限
                    if(player.hp > player.maxhp)
                    {
                        player.hp = player.maxhp;
                    }
                    //更新数据
                    GamePanel.Instance.ChangeHP(player.maxhp, player.hp);
                break;
            }
            //获取音效
            GameObject eff = Instantiate(geteff, this.transform.position, this.transform.rotation);
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
