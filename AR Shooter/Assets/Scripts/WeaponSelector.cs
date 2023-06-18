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

    public void SelectGun(int gunType)
    {
        var btnImage = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.transform.GetChild(0).GetComponent<Image>();
        var btnText = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.transform.GetChild(1).GetComponent<TextMeshProUGUI>();

        gameManager.hudManager.selectedGunPanel.gameObject.SetActive(true);
        gameManager.hudManager.selectedGunPanel.sprite = btnImage.sprite;
        gameManager.hudManager.selectedGunPanel.GetComponentInChildren<TextMeshProUGUI>().text = btnText.text;


        gameManager.playerShootingXR.gunType = (GameManager.GunType)gunType;
        
    }
    public void UpdateTimeScale(float time)
    {
        Time.timeScale = time;
    }
}
