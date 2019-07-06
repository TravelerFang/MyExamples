using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
///门
///</summary>
public class Door : MonoBehaviour 
{
    [HideInInspector]
    public DoorState ds;

    private void Start()
    {
        this.Close();//初始化门状态
    }

    public void Open()
    {
        if (ds == DoorState.closed)
        {
            //开门操作
            ds = DoorState.open;
            transform.rotation = 
                transform.parent.rotation*Quaternion.Euler(0,90,0);       
        }
    }

    public void Close()
    {
        if (ds == DoorState.open)
        {
            //关门操作
            ds = DoorState.closed;
            transform.rotation = transform.parent.rotation;
        }
    }

}
