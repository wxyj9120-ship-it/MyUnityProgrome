using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weaponobj : MonoBehaviour
{
    //创建子弹
    public GameObject bullet;
    //创建子弹位置 因为有多个所以用数组
    public Transform[] shootpos;
    //声明武器的拥有者
    public Tankbase fatherobj;
    //设置拥有者
    public void Setfather(Tankbase obj)
    {
        fatherobj = obj;
    }
    //开火
    public void Fire()
    {
        for(int i = 0; i < shootpos.Length; i++)
        {
            //实例化子弹
            GameObject obj = Instantiate(bullet, shootpos[i].position, shootpos[i].rotation);
            //将对象先赋值给武器 再间接赋值给子弹
            Bulletobj bulletobj = obj.GetComponent<Bulletobj>();
            bulletobj.Setfather(fatherobj);
        }
        
    }
}
