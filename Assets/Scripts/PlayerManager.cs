using System;
using System.Collections;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public int cookie = 0; 
    public float cookiePerSecond = 0f; 
    private float cookieFromClicker = 0f;
    public GuiManager guiManager; 

    public static event Action EventAddCookiePerSecond;
    
    void Start()
    {
        guiManager.UpdateCookie(cookie);
        guiManager.UpdateCookiePerSecond(cookiePerSecond);
        StartCoroutine(AddCookiesFromClickerEverySecond());
    }

    public void AddCookie(int amount)
    {
        cookie += amount; 
        guiManager.UpdateCookie(cookie);
    }

    public void SubCookie(int amount)
    {
        cookie -= amount; 
        guiManager.UpdateCookie(cookie);
    }

    public void UpdateCookiePerSecond(float amount)
    {
        cookiePerSecond += amount; 
        guiManager.UpdateCookiePerSecond(cookiePerSecond);
    }

    public int GetCookie()
    {
        return cookie; 
    }

    IEnumerator AddCookiesFromClickerEverySecond()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);

            cookieFromClicker += cookiePerSecond;

            int fullCookies = Mathf.FloorToInt(cookieFromClicker);
            if(fullCookies > 0)
            {
                AddCookie(fullCookies);
                cookieFromClicker -= fullCookies;
            }
            EventAddCookiePerSecond?.Invoke(); //Evento per far illuminare i clicker, controllato su internet come fare bene. 
            //visto che nella demo si illuminavano tutti allo stesso momento ho pensato che questo fosse il metodo migliore. 
            
        }
    }

}
