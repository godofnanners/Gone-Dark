﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIscript : MonoBehaviour
{
    Text[] text = new Text[5];
    Image[] image = new Image[8];
    private PlayerInventory playerInv;

    MainMenu menu;
    public bool open = false;
    public bool started = false;

   


    void Start()
    {
        menu = GameObject.Find("Canvas").gameObject.GetComponent<MainMenu>();

        text[0] = GameObject.Find("PistolMag").gameObject.GetComponent<Text>();
        text[1] = GameObject.Find("ShotgunShells").gameObject.GetComponent<Text>();
        text[2] = GameObject.Find("Medkits").gameObject.GetComponent<Text>();
        text[3] = GameObject.Find("CurrentPistol").gameObject.GetComponent<Text>();
        text[4] = GameObject.Find("CurrentShotgun").gameObject.GetComponent<Text>();

        image[0] = GameObject.Find("Shotgun").gameObject.GetComponent<Image>();
        image[1] = GameObject.Find("Pistol").gameObject.GetComponent<Image>();
        image[2] = GameObject.Find("Background").gameObject.GetComponent<Image>();
        image[3] = GameObject.Find("MedkitPic").gameObject.GetComponent<Image>();
        image[4] = GameObject.Find("RedKeycard").gameObject.GetComponent<Image>();
        image[5] = GameObject.Find("BlueKeycard").gameObject.GetComponent<Image>();
        image[6] = GameObject.Find("YellowKeycard").gameObject.GetComponent<Image>();
        image[7] = GameObject.Find("BackpackIcon").GetComponent<Image>();


        Color c = image[7].color;
        c.a = 0;
        image[7].color = c;
    }

    void Update()
    {
        if (started)
        {
            if (Input.GetKeyDown(KeyCode.B))
            {
                if (!open)
                {
                    open = true;
                }
                else
                {
                    open = false;
                }
            }
        }

        OpenInventory();

    }

    void OpenInventory()
    {
        if (open)
        {
            for (int i = 0; i < 4; i++)
            {
                image[i].gameObject.SetActive(true);
            }
            for (int i = 0; i < 5; i++)
            {
                text[i].gameObject.SetActive(true);
            }
            image[7].gameObject.SetActive(false);

            if (playerInv.GetComponent<PlayerInventory>().redKeycard)
            {
                image[4].gameObject.SetActive(true);
            }
            if (playerInv.GetComponent<PlayerInventory>().blueKeycard)
            {
                image[5].gameObject.SetActive(true);
            }
            if (playerInv.GetComponent<PlayerInventory>().yellowKeycard)
            {
                image[6].gameObject.SetActive(true);
            }

        }
        else
        {
            for (int i = 0; i < 7; i++)
            {
                image[i].gameObject.SetActive(false);
            }
            for (int i = 0; i < 5; i++)
            {
                text[i].gameObject.SetActive(false);
            }
            image[7].gameObject.SetActive(true);
        }
    }
}