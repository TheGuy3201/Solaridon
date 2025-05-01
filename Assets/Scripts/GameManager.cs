using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int gunVersion = 1;
    public bool miniKey;
    public bool finalKey;

    // Start is called before the first frame update
    void Start()
    {
        GunMode();
    }

    // Update is called once per frame
    async void Update()
    {
        await Task.Delay(2);
        GunMode();
    }
    public void GunMode()
    {
        if (gunVersion == 1) 
        {
            GameObject.Find("darksoldier").GetComponent<shoot>().shootSpeed = 0.75f;
            GameObject.Find("darksoldier").GetComponent<shoot>().bulletforce = 20f;
        }
        else if (gunVersion == 2)
        {
            GameObject.Find("darksoldier").GetComponent<shoot>().shootSpeed = 0.60f;
            GameObject.Find("darksoldier").GetComponent<shoot>().bulletforce = 30f;
        }
        else if (gunVersion == 3)
        {
            GameObject.Find("darksoldier").GetComponent<shoot>().shootSpeed = 0.05f;
            GameObject.Find("darksoldier").GetComponent<shoot>().bulletforce = 40f;
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
}
