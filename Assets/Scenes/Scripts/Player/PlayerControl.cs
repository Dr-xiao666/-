using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerControl : MonoBehaviour
{
    public float hp = 300;
    private float speed = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (hp <= 0)
        {
            die();
            hp = 100;
        }              
        move();//移动控制
        attack();//攻击控制

    }

    private void move()
    {
        //获取轴向
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        //判断是否为0
        if (h != 0 || v != 0)
        {
            transform.Translate(new Vector3(h, 0, v) * Time.deltaTime * speed, Space.World);
            //飞机在左右前后移动的时候，会发生倾斜
            this.transform.eulerAngles = new Vector3(v * 15, 0, h * -30);
        }
    }

    public GameObject Bullet;
    public GameObject ShootPos;
   

    private KeyInterval J_Key = new KeyInterval(KeyCode.J, 0.5f);
    private KeyInterval K_Key = new KeyInterval(KeyCode.K, 0.5f);

    private void attack()
    {
        J_Key.IntervalDown(() =>
        {
            Shoot();
        }, null);

        //K_Key.IntervalDown (() =>
        //{
        //    RangeAttack();
        //}, null);
    }

    protected virtual void Shoot()
    {
        //实例化一个游戏对象，不是new复制里面参数
        GameObject gameObject = Instantiate(Bullet);
        gameObject.transform.position = ShootPos.transform.position;
    }


    

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Bullet")
        {
            //销毁子弹
            Destroy(collision.gameObject);
            //播放爆炸特效；TODO
            hp = hp - collision.gameObject.GetComponent<Bullet>().hurt;
            //终于肝完终末地了...

        }
    }
    private void die()
    {
        //播放结算页面
        Debug.Log("玩家死亡");


    }
}
