using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class KeyInterval
{
    private float invoke;//间隔时间
    private float invokeTimer;//间隔时间计时器
    private KeyCode keyCode;    
    private float timer = 0;//连续计时器

    public KeyInterval (KeyCode keyCode, float invoke)
    {
        this.keyCode = keyCode;
        this.invoke = invoke;
        this.invokeTimer = invoke;
    }
    //Action 函数指针
    public void IntervalDown( Action action, Action actionEnd)
    {
        if (Input.GetKey(keyCode))
        {
            invokeTimer += Time.deltaTime;
            if (invokeTimer >= invoke)
            {
                action();
                invokeTimer = 0;
            }
        }
        if (Input.GetKeyUp(keyCode))
        {
            if (timer > invoke)
            {
                invokeTimer = invoke;
                timer = 0;
            }
            if (actionEnd != null)
            {
                actionEnd();
            }
        }
        timer += Time.deltaTime;
    }

}
