using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    public Sprite portalOpen;
    SpriteRenderer _sRenderer;
    public bool activated;
    public int buttonsNeeded;
    public int buttonCount;


    void Start()
    {
        _sRenderer = GetComponent<SpriteRenderer>();
        activated = false;
    }

    void Update()
    {
        ActivatePortal();

        if (Input.GetKeyDown(KeyCode.K)) buttonCount++;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (activated && Input.GetKeyDown(KeyCode.W))
        {
            SceneManager.LoadScene("Final");
        }
    }

    void ActivatePortal()
    {
        if (buttonCount >= buttonsNeeded)
        {
            activated = true;
            _sRenderer.sprite = portalOpen;
        }
    }

}
