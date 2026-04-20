using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgControl : MonoBehaviour
{
    //代指游戏对象
    public Transform[] Bgs;
    public float bgSize = 60;
    public float Speed = 2;

    private float allSize = 0;

    void Start()
    {
        allSize = Bgs.Length * bgSize;
        Debug.Log(allSize);
    }

    // Update is called once per frame
    void Update()
    {
        //Bg01.transform.Translate(new Vector3(0, 0, -10 * Time.deltaTime));
        //Bg02.transform.Translate(new Vector3(0, 0, -10 * Time.deltaTime));
        //if (Bg01.transform.position.z <= -60)
        //{
        //    Bg01.transform.position = Bg01.transform.position + new Vector3(0, 0, 120);
        //}
        // if (Bg02.transform.position.z <= -60)
        // {
        //    Bg02.transform.position = Bg02.transform.position + new Vector3(0, 0, 120);
        // }
        bgMove();
    }

    private void bgMove(float dir = -1)
    {
        //遍历每一个背景，背景有顺序；
        for (int i = 0; i < Bgs. Length; i++)
        {
            Bgs[i].Translate(new Vector3(0, 0, dir * Speed * Time.deltaTime));
            if (Bgs[i].transform.position.z <= dir * bgSize)
            {
                Bgs[i].position = Bgs[i].transform.position + new Vector3(0, 0, -dir * allSize);
            }
        }
    }
}
