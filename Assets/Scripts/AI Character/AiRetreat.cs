using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.Net.Mime.MediaTypeNames;

public class AiRetreat : MonoBehaviour
{
    public float _followSpeed;
    public Transform _target;
    public float _minDistance;

    public int enemyType; //0 is reg soldier, 1 is mini boss, 2 is final boss

    public Transform firePoint;

    //Stores projectile prefab
    public GameObject projectile;

    //Timespan between shots
    public float timeBetweenShots;

    //What time your able to shoot
    private float nextShotTime;


    //Enemy Health
    //public Image healthBar;
    public float enemyHealth = 90f;
    public AudioSource theSource;
    public AudioClip hurtSound;

    private void Start()
    {
        firePoint.position = new Vector3(transform.position.x+3, transform.position.y, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {

        if (enemyHealth <= 0)
        {
            if (enemyType == 1)
            {
                GameObject.Find("GameManager").GetComponent<GameManager>().miniDone = true;
                GameObject.Find("GameManager").GetComponent<GameManager>().ChangeMusic(GameObject.Find("GameManager").GetComponent<GameManager>().backgroundMusic);
                GameObject.Find("GameManager").GetComponent<GameManager>().ChangeObjective("Objective: \nFind the Keycard to the prototype room");
            }
            Destroy(gameObject);
        }

        if (Vector2.Distance(transform.position, _target.position) < _minDistance + 5)
        {
            //Projectile Spawner
            if (Time.time > nextShotTime)
            {
                if (enemyType == 1)
                {
                    Instantiate(projectile, new Vector3(firePoint.position.x, firePoint.position.y+3, firePoint.position.z), Quaternion.identity);
                    Instantiate(projectile, new Vector3(firePoint.position.x, firePoint.position.y - 3, firePoint.position.z), Quaternion.identity);
                }
                else if(enemyType == 2)
                {
                    Instantiate(projectile, new Vector3(firePoint.position.x-15, firePoint.position.y, firePoint.position.z), Quaternion.identity);
                }
                Instantiate(projectile, firePoint.position, Quaternion.identity);
                nextShotTime = Time.time + timeBetweenShots;
            }

            //Code for it coming close/farther then you
            if (Vector2.Distance(transform.position, _target.position) < _minDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, _target.position, -_followSpeed * Time.deltaTime);
            }
            else if (Vector2.Distance(transform.position, _target.position) > _minDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, _target.position, _followSpeed * Time.deltaTime);
            }
        }

    }

    public void TakeDamage(float damage)
    {
        theSource.PlayOneShot(hurtSound);
        enemyHealth -= damage;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            Destroy(other.gameObject);
            TakeDamage(30);
        }
    }
}

