using TMPro;
using UnityEngine;

public class GuiManager : MonoBehaviour
{
    public TextMeshProUGUI cookies;
    public TextMeshProUGUI cost; 
    public TextMeshProUGUI cookiePerSecond; 


    public void UpdateCookie(int amount)
    {
        cookies.text = amount.ToString();
    }

    public void UpdateCostSpawn(int amount)
    {
        cost.text = amount.ToString();
    }

    public void UpdateCookiePerSecond(float amount)
    {
        cookiePerSecond.text = amount.ToString("F1"); // quando i Clicker sono a 11 fa vedere 4.400001, Qui cerco di mostrare solo 4.4 
    }

}
