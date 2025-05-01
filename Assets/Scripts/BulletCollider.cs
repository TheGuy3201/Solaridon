using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class BulletCollider : MonoBehaviour
{
    public int cardVer;
    public int doorVer;

    // Start is called before the first frame update
    private async void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Bullet"))
            Destroy(other.gameObject);
        if (other.gameObject.CompareTag("Player"))
        {
            if (doorVer == 1 && GameObject.Find("GameManager").GetComponent<GameManager>().miniKey)
            {
                Destroy(this.gameObject);
                GameObject.Find("GameManager").GetComponent<GameManager>().miniKey = false;
            }
            if (doorVer == 2 && GameObject.Find("GameManager").GetComponent<GameManager>().finalKey)
            {
                Destroy(this.gameObject);
                GameObject.Find("GameManager").GetComponent<GameManager>().finalKey = false;
            }
            if (doorVer == 3)
            {

                gameObject.GetComponent<Collider2D>().isTrigger = true;
                await Task.Delay(3000);
                gameObject.GetComponent<Collider2D>().isTrigger = false;
                GetComponent<Collider2D>().offset = new Vector2(0, 0);
                doorVer = 0;
            }

        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && this.gameObject.CompareTag("Gun"))
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().gunVersion++;
            GameObject.Find("GameManager").GetComponent<GameManager>().GunMode();
            Destroy(this.gameObject);
        }
        if (other.gameObject.CompareTag("Player") && this.gameObject.CompareTag("Keycard"))
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().CardSetter(cardVer);
            Destroy(this.gameObject);
        }
        

    }
}