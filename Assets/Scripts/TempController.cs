using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempController : MonoBehaviour
{
    //Variable declaration
    public float playerSpeed;
    public float minX, minY, maxX, maxY;
    public GameObject laserBeam;
    public GameObject laserSpawner;
    public float fireRate = 0.25f;
    private float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        playerSpeed = 8;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalMove;
        float verticalMove;
        horizontalMove = Input.GetAxis("Horizontal");
        verticalMove = Input.GetAxis("Vertical");

        Vector2 newVelocity = new Vector2(horizontalMove, verticalMove);
        GetComponent<Rigidbody2D>().velocity = newVelocity * playerSpeed;

        float newX, newY;

        newX = Mathf.Clamp(GetComponent<Rigidbody2D>().position.x, minX, maxX);
        newY = Mathf.Clamp(GetComponent<Rigidbody2D>().position.y, minY, maxY);

        GetComponent<Rigidbody2D>().position = new Vector2(newX, newY);

        if (Input.GetAxis("Fire1") > 0 && timer > fireRate)
        {
            GameObject goObj;
            goObj = GameObject.Instantiate(laserBeam, laserSpawner.transform.position, laserSpawner.transform.rotation);
            goObj.transform.Rotate(0.0f, 0.0f, 0.0f);

            timer = 0;
        }
        timer += Time.deltaTime;
    }
}
