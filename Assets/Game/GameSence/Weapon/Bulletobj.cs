using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bulletobj : MonoBehaviour
{
    public int movespeed = 10;
    //谁发射子弹
    public Tankbase fatherobj;
    //特效预设
    public GameObject effobj;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(Vector3.forward * movespeed * Time.deltaTime);

    }
    //碰撞触发时
    private void OnTriggerEnter(Collider other)
    {
        //除了箱子，还有对立阵营
        if (other.CompareTag("Cube")||
            other.CompareTag("Player")&& fatherobj.CompareTag("Monster")||
            other.CompareTag("Monster") && fatherobj.CompareTag("Player"))
        {
            //判断受伤 用父类去获得 里氏替换
            Tankbase tankbase = other.GetComponent<Tankbase>();
            if(tankbase != null)
            {
                tankbase.Wound(fatherobj);
            }
            //创建爆炸特效
            if(effobj != null)
            {
                GameObject eff = Instantiate(effobj,this.transform.position,this.transform.rotation);
                //关联音效
                AudioSource source = eff.GetComponent<AudioSource>();
                source.volume = GameDateAll.Instance.musicDate.songVolume;
                source.mute = !GameDateAll.Instance.musicDate.isOnsong;
                //销毁音效
                Destroy(eff,source.clip.length);
            }
            //销毁子弹
            Destroy(this.gameObject);
        }

    }
    //设置拥有者
    public void Setfather(Tankbase obj)
    {
        fatherobj = obj;
    }
}
