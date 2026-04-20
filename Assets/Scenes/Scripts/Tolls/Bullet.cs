using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 50;
    public float hurt = 20;//伤害
    //计时器
    private float timer = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        //子弹出生后8秒销毁
        if (timer > 8)
        {
            Destroy(this.gameObject);
        }

        this.transform.Translate(new Vector3(0, 0, speed * Time.deltaTime));
    }
}
