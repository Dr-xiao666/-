using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    //Íæ¼Ò
    public GameObject player;
    private Vector3 offset;
    public float speed = 3;

    // Start is called before the first frame update
    void Start()
    {
        player = GameManager.Instance.GetCurPlayer();
        offset = transform.position - player.transform.position;
        offset = new Vector3(0, offset.y, offset.z);
        //Debug.Log(offset);
    }

    int state = 0;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ChangeView(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ChangeView(1);
        }
        if (state ==0)
        {
            Vector3 targetPosition = player.transform.position + offset;
            transform.position = Vector3.Lerp(transform.position, targetPosition, speed * Time.deltaTime);
        }
        if (state == 1)
        {
            Vector3 targetPosition = offset;
            transform.position = Vector3.Lerp(transform.position, targetPosition, speed * Time.deltaTime);
           if (Vector3.Distance(targetPosition, transform. position) <=0.01f)
            {
                state = -1;
            }
            
        }

    }

    private Vector3[] offsets = new Vector3[] { new Vector3(0, 4, -5), new Vector3(0, 19, 8) };

    private Vector3[] cameraRotation = new Vector3[] { new Vector3(20, 0, 0), new Vector3(90, 0, 0) };


    private void ChangeView(int i)
    {
        offset = offsets[i];
        Camera.main.transform.eulerAngles = cameraRotation[i];
        state = i;
        }
}
