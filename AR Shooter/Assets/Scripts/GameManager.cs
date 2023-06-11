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
        PotassiumPermanganate

    };
    public GunType gunType;
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
    public GunType enemyType;
    public static GameManager instance;

    public HUDManager hudManager;
    public PlayerShootingXR playerShootingXR;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }
    public void UpdateJoystickStatus(bool visible)
    {
        hudManager.joystick.gameObject.SetActive(visible);
    }
}
