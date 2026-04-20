using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private RaySixDirCollision raySixDirCollision;
    public GameObject Player;
    private Rigidbody rigidbody; 
    private float hp;//血量
    private float speed;//速度
    private float hum;//伤害
    private float attackInterval;//攻击间隔


    protected void Init(float hp, float speed, float hurt, float attackInterval)
    {
        this.hp = hp;  
        this.speed = speed;
        this.hum = hurt;
        this.attackInterval = attackInterval;
        //获取自己身上的组件
        rigidbody = GetComponent<Rigidbody>();
        raySixDirCollision = new RaySixDirCollision(~(1 << 9));

        raySixDirCollision.AddRayLayer(Vector3.zero, 2, Color.red);
        raySixDirCollision.AddRayLayer(new Vector3(0, 0, 1.5f), 3, Color.green);

        raySixDirCollision.SetDistance(0, DRI.LEFT, 10);
        raySixDirCollision.SetDistance(0, DRI.RIGHT, 10);

        raySixDirCollision.SetDistance(1, DRI.LEFT, 10);
        raySixDirCollision.SetDistance(1, DRI.RIGHT, 10);
        
    }

    private bool isDie = false;
    private float timer = 0;
    void Update()
    {
        raySixDirCollision.RaySixDirCollisionUpdate(this.transform);
        if (hp <= 0 && !isDie)
        {
            die();
        }
        if (isDie)
        {
            timer += Time.deltaTime;
            if (timer >= 5)
            {
              Destroy(this.gameObject);
                //死亡5s之后...
            }          
        }
        if (!isDie)
        {
            move();
            attack();
        }
    }
    private void move()
    {
        this.transform.eulerAngles = new Vector3(-rigidbody.velocity.z * 3, 
                                                 transform.eulerAngles.y,
                                                 rigidbody.velocity.x * 10);
        
        //看向玩家发射子弹
        transform.rotation = Quaternion.Lerp(transform.rotation,
            Quaternion.LookRotation(Player.transform.position - transform.position), 0.02f);

        transform.LookAt(Player.transform);
        if (this.transform.position.y > 0)
        {
            rigidbody.AddForce(Vector3.down * 10);
        }
        if (this.transform.position.y < 0)
        {
            rigidbody.AddForce(Vector3.up * 10);
        }

        float dis = Vector3.Distance(transform.position, Player.transform.position);
        if (dis >= 15)
        {
            //this.transform.Translate(Vector3.forward * speed * Time.deltaTime);
            rigidbody.AddRelativeForce(Vector3.forward * speed);
        }
        if (dis < 13)
        {
            //this.transform.Translate(-Vector3.forward * speed * Time.deltaTime);
            rigidbody.AddRelativeForce(Vector3.back * speed);
        }
        raySixDirCollision.SixRaycast((dir, hit) =>
        {
            switch (dir)
            {
                case DRI.FORNT:
                    rigidbody.AddRelativeForce(Vector3.right * 25);
                    break;
                case DRI.LEFT:
                    rigidbody.AddRelativeForce(Vector3.right * 25);
                    break;
                case DRI.RIGHT:
                    rigidbody.AddRelativeForce(Vector3.left * 25);
                    break;
                default:
                    break;
            }
        }, null);

    }

    private void die() //死亡函数
    {
        rigidbody.AddForceAtPosition(Vector3.up * 2,
            transform.position + new Vector3(10, 0, 0), ForceMode.Impulse);
        //整个爆炸
        GameObject obj = Instantiate(boomEffect02);
        obj.transform.position = this.transform.position;
        rigidbody.useGravity = true;
        isDie = true;

        caScore();//计算分数
    }

    public virtual void caScore()
    {
        GameManager.Instance.SetScore(20);
    }

    //攻击
    public GameObject[] Bullets;//子弹
    public GameObject[] ShootPoss;
    private float attackTimer = 0;
    

    private void attack()
    {
        attackTimer += Time.deltaTime;
        if (attackTimer > attackInterval)
        {
            ShootBullet();//发射子弹
            attackTimer = 0;
        }
    }
    public virtual void ShootBullet()
    {
        // 1. 检查数组是否为空
        if (Bullets == null || Bullets.Length == 0 || ShootPoss == null || ShootPoss.Length == 0)
        {
            Debug.LogError("敌人 {gameObject.name} 的 Bullets 或 ShootPoss 数组未赋值，无法发射子弹！");
            return;
        }

        // 2. 确保索引在有效范围内
        int index = 0; // 这里的index需要根据你的逻辑确定
        if (index < 0 || index >= Bullets.Length || index >= ShootPoss.Length)
        {
            Debug.LogError("敌人 {gameObject.name} 的索引 {index} 超出数组范围！");
            return;
        }

        // 3. 执行发射逻辑
        GameObject obj = Instantiate(Bullets[index]);
        obj.transform.position = ShootPoss[index].transform.position;
        obj.transform.rotation = ShootPoss[index].transform.rotation;
    }


    public GameObject boomEffect01;
    public GameObject boomEffect02;
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Bullet")
        {
            //销毁子弹
            Destroy(collision.gameObject);
            //播放爆炸特效；TODO
            GameObject obj = Instantiate(boomEffect01);
            obj.transform.position = collision.gameObject.transform.position;            
            //计算伤害
            hp = hp - collision.gameObject.GetComponent<Bullet>().hurt;
            //终于肝完终末地了...
           
        }
    }
}


