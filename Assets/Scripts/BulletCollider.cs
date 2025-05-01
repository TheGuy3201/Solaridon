using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollider : MonoBehaviour
{
    public int cardVer;
    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Bullet"))
            Destroy(other.gameObject);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && this.gameObject.CompareTag("Gun"))
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().gunVersion++;
            Destroy(this.gameObject);
        }
        if (other.gameObject.CompareTag("Player") && this.gameObject.CompareTag("Keycard"))
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().CardSetter(cardVer);
            Destroy(this.gameObject);
        }
    }
}