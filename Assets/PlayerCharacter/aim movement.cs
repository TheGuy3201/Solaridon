using System.Collections;

using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
public class Aimmovement : MonoBehaviour

{
    public Camera mainCam;

    public Transform rb;
    private Vector3 mousePos;

    void Update()
    {
        TakeInputs();
    }

    void FixedUpdate()
    {
        Move();
    }

    void TakeInputs()
    {
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
    }
    void Move()
    {
        Vector2 aimDirection = mousePos - rb.position;
        float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = Quaternion.Euler(0,0,aimAngle);
    }
}
