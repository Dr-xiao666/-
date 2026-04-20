using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyL1 : Enemy
{
    private void Start()
    {
        //每一个敌人基于不同的HP和伤害
        Init(100, 15, 10, 2);
    }
}
