using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class HUDManager : MonoBehaviour
{
    public Sprite damagedHeart;
    public Image[] heartImages;
    public Joystick joystick;
    public Image selectedGunPanel;
    /// <summary>
    /// 0 = pass, 1 = fail 
    /// </summary>
    public GameObject[] gameFinishPanels;
    public GameObject collectablesUIpanel;
    public GameObject collectablesListpanel;
    public GameObject waveAlertPanel;
    public Image collectablesUI;
    public TextMeshProUGUI collectablesText;
    public void UpdateHealthUI(int maxHealth, int index)
    {
        heartImages[maxHealth -1 - index].sprite = damagedHeart;
    }
    public void ShowAlert(string msg)
    {
        waveAlertPanel.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = msg;

        waveAlertPanel.transform.DOScale(Vector3.one, 0.7f).OnComplete(() =>
            waveAlertPanel.transform.DOScale(Vector3.zero, 0.7f).SetEase(Ease.InBounce).SetDelay(1f)).SetEase(Ease.OutBounce);
    }
}