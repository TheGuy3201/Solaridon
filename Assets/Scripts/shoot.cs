using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform firepoint;
    public GameObject bulletprefab;
    public float bulletforce;
    public float shootSpeed;
    private float timer = 0;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1") && timer > shootSpeed)
        {
            Shoot();
        }
        timer += Time.deltaTime;

    }
    void Shoot()
    {
       GameObject bullet = Instantiate(bulletprefab, firepoint.position, firepoint.rotation);
       Rigidbody2D rb= bullet.GetComponent<Rigidbody2D>();
       rb.AddForce(firepoint.up*bulletforce,ForceMode2D.Impulse);
       timer = 0;
    }
}

