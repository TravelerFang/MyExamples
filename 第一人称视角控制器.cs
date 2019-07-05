using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
///第一人称视角
///</summary>
public class FPV : MonoBehaviour 
{
    //鼠标灵敏度
    public float sensitivityX = 10f;
    public float sensitivityY = 8f;
    //最大上下视角
    public float maximumY = 60f;
    public float minimumY = -60f;
    //相机实际旋转量
    float rotationY = 0f;
    float rotationX;
    Vector3 rotation;

    private void Update()
    {
        rotationX =
            Camera.main.transform.localEulerAngles.y + 
            Input.GetAxis("MouseX") * sensitivityX;
        rotationY += Input.GetAxis("MouseY") * sensitivityY;
        rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);

        rotation.y = rotationX;
        rotation.x = -rotationY;
        transform.localEulerAngles = rotation;
    }
}
