using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum GunType
    {
        Hydrogen,
        Ammonia,
        SulfuricAcid,
        NitricAcid,
        HydrochloricAcid,
        PotassiumHydroxide,
        PotassiumPermanganate,
        None

    };
    public enum EnemyType
    {
        Nitrogen,
        Magnessium,
        HCL,
        ZincMetal,
        copperIIPhosphateSalt,
        Ammonia,
        ammoniumNitrate,
        CarbonDioxide,
        potassiumCarbonate,
        SulfuricAcid,
        potassiumSulfate
    };
    public enum CollectableType
    {
        Ammonia,
        Hydrogen,
        AmmoniumChloride,

    };
    public static GameManager instance;

    public HUDManager hudManager;
    public PlayerShootingXR playerShootingXR;
    public GameOverManagerXR gameOverManagerXR;
    public int collectables = 0;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        Time.timeScale = 1;
    }
    public void UpdateJoystickStatus(bool visible)
    {
        hudManager.joystick.gameObject.SetActive(visible);
    }
}
