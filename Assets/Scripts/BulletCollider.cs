using System;
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
        if(other.gameObject.CompareTag("Bullet") || other.gameObject.CompareTag("AI Bullet"))
            Destroy(other.gameObject);
        if (other.gameObject.CompareTag("Player"))
        {
            if (doorVer == 1 && GameObject.Find("GameManager").GetComponent<GameManager>().miniKey)
            {
                Destroy(this.gameObject);
                GameObject.Find("GameManager").GetComponent<GameManager>().miniKey = false;
                GameObject.Find("GameManager").GetComponent<GameManager>().ChangeMusic(GameObject.Find("GameManager").GetComponent<GameManager>().bossFightSound);

            }
            if (doorVer == 2 && GameObject.Find("GameManager").GetComponent<GameManager>().finalKey)
            {
                Destroy(this.gameObject);
                GameObject.Find("GameManager").GetComponent<GameManager>().finalKey = false;
                GameObject.Find("GameManager").GetComponent<GameManager>().ChangeMusic(GameObject.Find("GameManager").GetComponent<GameManager>().bossFightSound);
            }
            if (doorVer == 3)
            {

                gameObject.GetComponent<Collider2D>().isTrigger = true;
                await Task.Delay(3000);
                gameObject.GetComponent<Collider2D>().isTrigger = false;
                GetComponent<Collider2D>().offset = new Vector2(0, 0);
            }
            else if(doorVer == 3 && GameObject.Find("GameManager").GetComponent<GameManager>().gunVersion == 2)
            {
                gameObject.GetComponent <Collider2D>().isTrigger = true;
            }
            if(doorVer == 4 && GameObject.Find("GameManager").GetComponent<GameManager>().miniDone)
            {
                Destroy (this.gameObject);
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