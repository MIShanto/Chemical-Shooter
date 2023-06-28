using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System;

public class Collectable : MonoBehaviour
{
    public GameManager.CollectableType collectableType;

    public string name;
    public Sprite sprite;

    GameManager gameManager;
    private void Start()
    {
        gameManager = GameManager.instance;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collider"))
        {
            CollectItem();
        }
    }

    void CollectItem()
    {
        gameManager.collectables++;

        if (PlayerPrefs.GetInt(Enum.GetName(typeof(GameManager.CollectableType), collectableType), 0) == 0)
        {
            PlayerPrefs.SetInt(Enum.GetName(typeof(GameManager.CollectableType), collectableType), 1);

            gameManager.hudManager.collectablesUI.sprite = sprite;
            gameManager.hudManager.collectablesText.text = name;
            gameManager.SetCollectedChemicals(sprite);

            //tween
            gameManager.hudManager.collectablesUIpanel.transform.DOScale(Vector3.one, 0.7f).OnComplete(() =>
            gameManager.hudManager.collectablesUIpanel.transform.DOScale(Vector3.zero, 0.7f).SetEase(Ease.InBounce).SetDelay(1f)).SetEase(Ease.OutBounce);

        }

        if (gameManager.collectables == 0)
            gameManager.OnGameWin();

        Destroy(gameObject);
    }

    
}
