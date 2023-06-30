using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameOver : MonoBehaviour
{
    [SerializeField] PlayerController player;
    [SerializeField] GameObject menuGO;

    // Start is called before the first frame update
    void Start()
    {
        player.Muerte_Player += MenuGameOverOn;
    }
    // Update is called once per frame
    void Update()
    {
    
    }

    void MenuGameOverOn(object sender, EventArgs e)
    {
        menuGO.SetActive(true);
    }

}
