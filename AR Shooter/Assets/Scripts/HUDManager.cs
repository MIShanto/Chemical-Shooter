using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour
{
    public Sprite damagedHeart;
    public Image[] heartImages;
    public Joystick joystick;
    public void UpdateHealthUI(int maxHealth, int index)
    {
        heartImages[maxHealth -1 - index].sprite = damagedHeart;
    }
}