using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

[System.Serializable]
public class Weapon
{
    public GameObject weapon;
    public Color bulletColor;
    public Sprite weaponImage;
    public GameManager.GunType gunType;
}

public class WeaponSelector : MonoBehaviour
{
    GameManager gameManager;
    private void Start()
    {
        gameManager = GameManager.instance;
    }
/*
    public void UpdateWeapon()
    {
        // Disable the current weapon
        //weapons[currentWeaponIndex].weapon.SetActive(false);

        // Increment the current weapon index
        currentWeaponIndex++;

        // If the current index is greater than the number of weapons, set it back to 0
        if (currentWeaponIndex >= weapons.Count)
        {
            currentWeaponIndex = 0;
        }

        // Enable the new current weapon
        //weapons[currentWeaponIndex].weapon.SetActive(true);
        gameManager.playerShootingXR.gunType =  weapons[currentWeaponIndex].gunType;
        var ps = gameManager.playerShootingXR.gunParticles.main;
        ps.startColor = weapons[currentWeaponIndex].bulletColor;
        gameManager.playerShootingXR.gunLine.material.SetColor("_Color", weapons[currentWeaponIndex].bulletColor);
        gameManager.hudManager.weaponUIPanel.sprite = weapons[currentWeaponIndex].weaponImage;
    }*/

    public void SelectGun(int gunType)
    {
        var btnImage = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.transform.GetChild(0).GetComponent<Image>();
        var btnText = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.transform.GetChild(1).GetComponent<TextMeshProUGUI>();

        gameManager.hudManager.selectedGunPanel.gameObject.SetActive(true);
        gameManager.hudManager.selectedGunPanel.sprite = btnImage.sprite;
        gameManager.hudManager.selectedGunPanel.GetComponentInChildren<TextMeshProUGUI>().text = btnText.text;


        gameManager.playerShootingXR.gunType = (GameManager.GunType)gunType;
        
    }
}
