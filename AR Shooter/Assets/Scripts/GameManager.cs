using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum ChemicalType
    {
        Base,
        Acid
    };
    public ChemicalType chemicalType;
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
}
