using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public Player playerController;
    public GunControl gunController;
    public TMP_Text ammoText;
    public TMP_Text livesText;

    private bool reloadPrompt;

    // Update is called once per frame
    void Update()
    {
        if (gunController.currentAmmoInClip == 0)
        {
            reloadPrompt = true;
        }

        if (Input.GetKeyDown(KeyCode.R) && reloadPrompt == true)
        {
            reloadPrompt = false;
        }

        if (reloadPrompt == true)
        {
            ammoText.text = "RELOAD";
        }
        else
        {
            ammoText.text = "Ammo: " + gunController.currentAmmoInClip;
        }

        livesText.text = "Lives: " + playerController.playerHealth;
    }
}
