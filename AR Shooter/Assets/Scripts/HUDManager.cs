using UnityEngine;
using UnityEngine.UI;
using TMPro;

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
    public GameObject waveAlertPanel;
    public Image collectablesUI;
    public TextMeshProUGUI collectablesText;
    public void UpdateHealthUI(int maxHealth, int index)
    {
        heartImages[maxHealth -1 - index].sprite = damagedHeart;
    }
}