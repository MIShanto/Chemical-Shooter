using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Shield
{
    public Color color; 
    public GameManager.EnemyType enemyType; 
    public GameManager.GunType gunType; 
}
public class Boss : MonoBehaviour
{
    public EnemyHealthXR enemyHealthXR;
    public List<Shield> shields;
    public Material shieldMat;

    private void Start()
    {
        InvokeRepeating(nameof(UpdateSheild), 0, 3f);
        //GetComponent<EnemyHealthXR>().OnDeath.AddListener(() => GameManager.instance.UpdateJoystickStatus(true));
    }

    void UpdateSheild()
    {
        if (enemyHealthXR.currentHealth > 0)
        {
            int index = Random.Range(0, shields.Count);

            shieldMat.color = shields[index].color;
            enemyHealthXR.enemyType = shields[index].enemyType;
            enemyHealthXR.gunType = shields[index].gunType;
        }
    }
}
