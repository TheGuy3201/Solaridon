using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiBullet : MonoBehaviour
{
    //
    public Transform firepoint;
    public GameObject bulletprefab;
    public float bulletforce;
    public float shootSpeed;
    public float damage;

    Vector3 targetPosition;
    public float speed;


    // Start is called before the first frame update
    private void Start()
    {
        //goal, have the targeted game object in the <>
        targetPosition = GameObject.Find("Player").transform.position;
    }

    // Update is called once per frame
    private void Update()
    {

        transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        if (transform.position == targetPosition)
        {
            Destroy(gameObject);
        }

    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        if (other.gameObject.CompareTag("Player"))
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }

}
