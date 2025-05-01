using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //Gun Version and Keycard obtained variables
    public int gunVersion = 1;
    public bool miniKey;
    public bool finalKey;

    //Health Stuff
    public Image healthBar;
    public float healthAmount = 100f;

    // Start is called before the first frame update
    void Start()
    {
        GunMode();
    }

    void Update()
    {
        if(healthAmount <= 0 || Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.loadedSceneCount);
        }
        if (Input.GetKeyDown(KeyCode.Space))
            TakeDamage(25);
    }

    public void GunMode()
    {
        if (gunVersion == 1)
        {
            GameObject.Find("Player").GetComponent<shoot>().shootSpeed = 0.75f;
            GameObject.Find("Player").GetComponent<shoot>().bulletforce = 20f;
        }
        else if (gunVersion == 2)
        {
            GameObject.Find("Player").GetComponent<shoot>().shootSpeed = 0.60f;
            GameObject.Find("Player").GetComponent<shoot>().bulletforce = 30f;
        }
        else if (gunVersion == 3)
        {
            GameObject.Find("Player").GetComponent<shoot>().shootSpeed = 0.05f;
            GameObject.Find("Player").GetComponent<shoot>().bulletforce = 40f;
        }
    }
    public void CardSetter(int cardVer)
    {
        if (cardVer == 0)
            Debug.Log(cardVer);
        else if (cardVer == 1)
        {
            miniKey = true;
            Debug.Log(cardVer);
        }
        else if (cardVer == 2)
        {
            finalKey = true;
            Debug.Log(cardVer);
        }

    }

    public void TakeDamage(float damage)
    {
        healthAmount -= damage;
        healthBar.fillAmount = healthAmount / 100f;
    }

    public void Heal(float healingAmount)
    {
        healingAmount += healingAmount;
        healthAmount = Mathf.Clamp(healthAmount, 0, 100);

        healthBar.fillAmount = healthAmount / 100f;
    }
}
