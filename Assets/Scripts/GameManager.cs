using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TMPro;
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
    public bool miniDone;

    //Health Stuff
    public Image healthBar;
    public float healthAmount = 100f;
    public AudioSource theSource;
    public AudioClip hurtSound;
    public AudioClip backgroundMusic;
    public AudioClip victorySound;
    public AudioClip bossFightSound;

    protected int winCount = 0;
    public GameObject DeathMessage;
    public GameObject ObjectiveMessage;

    // Start is called before the first frame update
    void Start()
    {
        GunMode();
    }

    void Update()
    {
        if(healthAmount <= 0 || Input.GetKeyDown(KeyCode.R))
        {
            PlayerDied();
        }
        if(GameObject.FindGameObjectWithTag("AI Boss") == false && winCount <= 1)
        {
            DeathMessage.GetComponent<TextMeshProUGUI>().text = "YOU DEFEATED THE PROTODESTRUCTOR 2000 \n \n Thank You For Playing our BETA of Solaridon";
            ChangeObjective(" ");
            ChangeMusic(victorySound);
            winCount++;
        }
    }

    public void ChangeObjective(String playerText)
    {
        ObjectiveMessage.GetComponent<TextMeshProUGUI>().text = playerText;
    }

    public void ChangeMusic(AudioClip music)
    {
        theSource.Stop();
        theSource.clip = music;
        theSource.Play();
    }

    public async void PlayerDied()
    {
        DeathMessage.GetComponent<TextMeshProUGUI>().text = "You Died";
        await Task.Delay(2500);
        DeathMessage.GetComponent<TextMeshProUGUI>().text = " ";
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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
            ChangeObjective("Objective: \nKill the \"Speed Demon\"");
            Debug.Log(cardVer);
        }
        else if (cardVer == 2)
        {
            finalKey = true;
            ChangeObjective("Objective: \nDestroy the \"Prototype Weapon\"");
            Debug.Log(cardVer);
        }

    }

    public void TakeDamage(float damage)
    {
        theSource.PlayOneShot(hurtSound);
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
