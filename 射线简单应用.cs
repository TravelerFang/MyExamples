using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
///射线
///V1.0 射线击中碰撞体，画出线
///V2.0 实现点击开关门
///</summary>
public class RayTest : MonoBehaviour 
{
    private RaycastHit hitInfo;
    private Vector3 hitPoint;


    //V1.0
    //private void Update()
    //{
    //    if (Input.GetMouseButton(0))
    //    {
    //        Ray r = Camera.main.ScreenPointToRay(Input.mousePosition);
    //        if (Physics.Raycast(r, out hitInfo) == true)
    //        {
    //            Debug.DrawLine(Camera.main.transform.position, hitInfo.point,Color.red);
    //        }
    //    }
    //}

    private Door door;
    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Ray r = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(r, out hitInfo)&&hitInfo.transform.tag == "door" )
            {
                door = hitInfo.transform.GetComponent<Door>();
                if (door.ds == DoorState.closed)
                {
                    door.Open();
                }
                else
                {
                    door.Close();
                }
            }
        }
    }
}
