using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

[System.Serializable]
public class Weapon
{
    public GameObject weapon;
    public Color bulletColor;
    public Sprite weaponImage;
    public GameManager.ChemicalType chemicalType;
}

public class WeaponSelector : MonoBehaviour
{
    public List<Weapon> weapons;

    private int currentWeaponIndex = 0;
    GameManager gameManager;
    private void Start()
    {
        // Set the first weapon as active
        //weapons[currentWeaponIndex].weapon.SetActive(true);

        gameManager = GameManager.instance;
    }

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
        gameManager.playerShootingXR.chemicalType =  weapons[currentWeaponIndex].chemicalType;
        gameManager.playerShootingXR.gunLine.material.SetColor("_Color", weapons[currentWeaponIndex].bulletColor);
        gameManager.hudManager.weaponUIPanel.sprite = weapons[currentWeaponIndex].weaponImage;
    }
}
