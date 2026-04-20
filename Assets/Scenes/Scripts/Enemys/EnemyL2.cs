using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyL2 : Enemy
{
    private void Start()
    {
        //每一个敌人基于不同的HP和伤害
        Init(150, 10, 5, 2);
    }
    public override void ShootBullet()
    {
        int bu01_index = 0;
        GameObject bu01 = Instantiate(Bullets[bu01_index]);
        bu01.transform.position = ShootPoss[bu01_index].transform.position;
        bu01.transform.rotation = ShootPoss[bu01_index].transform.rotation;

        int bu02_index = 1;
        GameObject bu02 = Instantiate(Bullets[bu02_index]);
        bu02.transform.position = ShootPoss[bu02_index].transform.position;
        bu02.transform.rotation = ShootPoss[bu02_index].transform.rotation;
    }
    //计算分数
    public override void caScore()
    {
        GameManager.Instance.SetScore(40);
    }

}
