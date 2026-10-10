using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playerobj : Tankbase
{
    //确定当前武器
    public Weaponobj nowweapon;
    //设置武器位置
    public Transform weaponpos;
    //设置连续开火间隔
    private float fireTime;
    private float fireInterval = 0.2f;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        //坦克前后移动
        this.transform.Translate(Input.GetAxis("Vertical") * Vector3.forward * movespeed * Time.deltaTime);
        //坦克左右旋转
        this.transform.Rotate(Input.GetAxis("Horizontal")*Vector3.up * roundspeed);
        //坦克头旋转
        tankhead.transform.Rotate(Input.GetAxis("Mouse X") * Vector3.up * headroundspeed);
        //坦克开火
        if(Input.GetMouseButtonDown(0))
        {
            Fire();
        }
        //坦克持续开火
        if (Input.GetMouseButton(1) && fireTime <= 0)
        {
            fireTime = fireInterval;
            FireHold();  
        }
        fireTime -= Time.deltaTime;
    }
    //坦克持续开火
    public override void FireHold()
    {
        if (nowweapon != null && fireTime >= 0)
        {
            nowweapon.Fire();
        }
    }
    //坦克开火
    public override void Fire()
    {
        if(nowweapon != null)
        {
            nowweapon.Fire();
        }
    }
  //坦克死亡
    public override void Die()
    {
        Time.timeScale = 0;
        LoosePanel.Instance.ShowMe();
    }
    //坦克受伤
    public override void Wound(Tankbase other)
    {
        base.Wound(other);
        //更新面板
        GamePanel.Instance.ChangeHP(maxhp, hp);
    }
    //切换武器
    public void ChangeWeapon(GameObject weapon)
    {
        //删除原本武器
        if(nowweapon != null)
        {
            Destroy(nowweapon.gameObject);
            nowweapon = null;
        }
        //更换武器
        GameObject weaponobj = Instantiate(weapon,weaponpos,false);
        nowweapon = weaponobj.GetComponent<Weaponobj>();
        //设置武器拥有者
        nowweapon.Setfather(this);   
    }
}
