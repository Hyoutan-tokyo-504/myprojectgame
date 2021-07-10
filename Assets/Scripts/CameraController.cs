using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CameraController : MonoBehaviour
{

    //private Vector3 lastMousePosition;
    //private Vector3 newAngle = new Vector3(0, 0, 0);
    //public Camera camera;
    //bool aim;
    //int count;
    ////private int touchcount;

    //private void Start()
    //{
    //    aim = false;
    //}

    //public void AimButtonDown()
    //{
    //    aim = true;
    //}

    //public void AimButtonUp()
    //{
    //    aim = false;
    //}
    //private void Update()
    //{
    //    if (aim == true)
    //    {
    //        if (Input.GetTouch(0).phase == TouchPhase.Began)
    //        {
    //            // マウスクリック開始(マウスダウン)時にカメラの角度を保持(Z軸には回転させないため).
    //            newAngle = camera.transform.localEulerAngles;
    //            lastMousePosition = Input.mousePosition;
    //        }

    //        if (Input.GetTouch(0).phase == TouchPhase.Moved)
    //        {
    //            // マウスの移動量分カメラを回転させる.
    //            newAngle.y += (Input.GetTouch(0).position.x - lastMousePosition.x) * 0.2f;
    //            newAngle.x -= (Input.GetTouch(0).position.y - lastMousePosition.y) * 0.2f;
    //            camera.gameObject.transform.localEulerAngles = newAngle;

    //            //lastMousePosition = Input.mousePosition;

    //            lastMousePosition = Input.GetTouch(0).position;

    //        }
    //    }
    //}



    [Range(0.1f, 10f)]
    //カメラ感度、数値が大きいほどより直感的な操作が可能.
    public float lookSensitivity = 5f;
    [Range(0.1f, 1f)]
    //数値が大きいほどカメラが向きたい方向に向くまでの時間が長くなる.
    public float lookSmooth = 0.1f;

    public Vector2 MinMaxAngle = new Vector2(-65, 65);

    private float yRot;
    private float xRot;

    private float currentYRot;
    private float currentXRot;

    private float yRotVelocity;
    private float xRotVelocity;

    private void Start()
    {
        //this.transform.rotation = transform.parent.gameObject.transform.rotation;
    }

    void Update()
    {

        yRot += Input.GetAxis("Mouse X") * lookSensitivity; //マウスの移動.
        xRot -= Input.GetAxis("Mouse Y") * lookSensitivity; //マウスの移動.



        xRot = Mathf.Clamp(xRot, MinMaxAngle.x, MinMaxAngle.y);//上下の角度移動の最大、最小.


        currentXRot = Mathf.SmoothDamp(currentXRot, xRot, ref xRotVelocity, lookSmooth);
        currentYRot = Mathf.SmoothDamp(currentYRot, yRot, ref yRotVelocity, lookSmooth);

        transform.rotation = Quaternion.Euler(currentXRot, currentYRot, 0);
    }
}
