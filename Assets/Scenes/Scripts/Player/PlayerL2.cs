using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerL2 : PlayerControl
{
   protected override void Shoot()
    {
        RangeAttack();
    }
    private int bulltNum = 6;//ÊýÁ¿
    private float angle = 50;//½Ç¶È

    //É¢µ¯¹¥»÷
    private void RangeAttack()
    {
        float interal = angle / bulltNum;

        for (float i = -angle / 2; i <= angle / 2; i = i + interal)
        {
            GameObject gameObject = Instantiate(Bullet);
            gameObject.transform.position = ShootPos.transform.position;
            gameObject.transform.eulerAngles = new Vector3(0, i, 0);
        }
    }
}
