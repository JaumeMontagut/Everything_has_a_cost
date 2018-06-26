using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinScript : MonoBehaviour
{
    public UIManager uiManager;

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collided");
        if (collision.gameObject.CompareTag("Player"))
        {
            uiManager.ActivateWinUI();
        }
    }
}
