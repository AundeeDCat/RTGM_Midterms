using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using DG.Tweening;

public class Return : MonoBehaviour
{
    public GameObject ball;
    private Rigidbody ball_rb;

    void Awake()
    {
        ball_rb = ball.GetComponent<Rigidbody>();
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            ball.GetComponent<Collider>().gameObject.transform.DOMove(new Vector3(0f, 0.5f, -12.5f), 0.5f);
            ball_rb.velocity = new Vector3(0, 0, 0);
            ball.transform.Rotate(0.0f, 0.0f, 0.0f, Space.Self);

            DragShoot.isLaunch = false;
        }
    }
}
