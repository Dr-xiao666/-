using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGeneration : MonoBehaviour
{
    public GameObject Player;
    public Transform Rpoint01;
    public Transform Rpoint02;

    private int rangex = 0;
    private int rangez = 0;

    public GameObject[] enemys;
    void Start()
    {
        Player = GameManager.Instance.GetCurPlayer();
        rangex = (int)((Rpoint02.position.x - Rpoint01.position.x) / 10);
        rangez = (int)((Rpoint02.position.z - Rpoint01.position.z) / 10);
        //Debug.Log(rangex);
        //Debug.Log(rangez);
    }
    public int enemyCount = 1;
   
    void Update()
    {
        GameObject[] curenemys = GameObject.FindGameObjectsWithTag("Enemy");
        if (curenemys.Length == 0)
        {
            int indexMax = enemyCount > enemys.Length ? enemys.Length : enemyCount;
            Debug.Log(indexMax);
            for (int i = 0; i < enemyCount; i++)
            {               
                //[0, 3);
                int enemyIndex = Random.Range(0, indexMax);

                float rx = Random.Range(0, rangex) * 10;
                float rz = Random.Range(0, rangez) * 10;
                float x = Rpoint01.position.x + rx;
                float z = Rpoint01.position.z + rz;
                GameObject obj = Instantiate(enemys[enemyIndex]);
                obj.transform.position = new Vector3(x, 0, z);
                obj.GetComponent<Enemy>().Player = Player;
            }
            enemyCount++;
        }
        if (enemyCount <= 8)
        {

        }

        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    float rx = Random.Range(0, rangex) * 10;
        //    float rz = Random.Range(0, rangez) * 10;
        //    float x = Rpoint01.position.x + rx;
        //    float z = Rpoint01.position.z + rz;
        //    //Debug.Log("rx: " + rx);
        //    //Debug.Log("rz: " + rz);
        //    //Debug.Log("x: " + x);
        //    //Debug.Log("x: " + z);
        //    GameObject obj = Instantiate(enemys[0]);
        //    obj.transform.position = new Vector3(x, 0, z);
        //}
    }
}
