using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragShoot : MonoBehaviour
{
    //public GameObject prefab_Trajectory_Texture;

    private Vector3 mousePressDown_Pos;
    private Vector3 mouseRelease_Pos;
    private Vector3 mouseCurrent_Pos;
    private float ShootPower_Z = 200f;

    private Rigidbody rb;

    public static bool isLaunch = false;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnMouseDown()
    {
        mousePressDown_Pos = Input.mousePosition;
    }

    private void OnMouseDrag()
    {
        Vector3 forceInit = (mousePressDown_Pos - Input.mousePosition);
        Vector3 forceV = (new Vector3(-forceInit.x,-forceInit.y, ShootPower_Z)) * forceMultiplier;

        if (!isLaunch)
        {
            DrawTrajectory.Instance.UpdateTrajectory(forceV, rb, transform.position);
        }
    }

    private void OnMouseUp()
    {
        DrawTrajectory.Instance.HideLine();
        mouseRelease_Pos = Input.mousePosition;
        Shoot(mousePressDown_Pos - mouseRelease_Pos);
    }

    private float forceMultiplier = 1.5f;

    void Shoot(Vector3 ShootPower)
    {
        if (isLaunch) return;

        rb.AddForce(new Vector3(-ShootPower.x, -ShootPower.y, ShootPower_Z) * forceMultiplier);
        isLaunch = true;
    }


}
