using UnityEngine;
using System.Collections;

public class Clicker : MonoBehaviour
{
    private float cookiePerSecond = 0.4f;
    private PlayerManager playerManager; 
    private SpriteRenderer spriteRenderer; 
    private Color color;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        color = spriteRenderer.color; 
    }

    void OnEnable()
    {
        PlayerManager.EventAddCookiePerSecond += FlashRed;
    }

    void OnDisable()
    {
        PlayerManager.EventAddCookiePerSecond -= FlashRed;
    }

    void Start()
    {
        playerManager = FindFirstObjectByType<PlayerManager>();
        playerManager.UpdateCookiePerSecond(cookiePerSecond);
    }

    void FlashRed()
    {
        StartCoroutine(RedCoroutine());
    }

    IEnumerator RedCoroutine()
    {
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        spriteRenderer.color = color; 
    }
    
}
