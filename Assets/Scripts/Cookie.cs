using UnityEngine;
using UnityEngine.InputSystem;

public class Cookie : MonoBehaviour
{
    public LayerMask cookieLayer;
    public InputAction mouseClick; //usato Input action invece di bool clickedThisFrame = Mouse.current.leftButton.wasPressedThisFrame; Come scritto negli hint, perchè lo avevamo già usato e mi trovo abbastanza bene

    public Animator animator; 

    public PlayerManager playerManager; 

    private void OnEnable()
    {
        mouseClick.Enable();
    }

    private void OnDisable()
    {
        mouseClick.Disable();
    }
    
    void Update()
    {

        if (mouseClick.triggered)
        {
            CookieCliked();
        }
    }

    private void CookieCliked()
    {
        // Debug.Log("Cliccato");
        Vector3 mousePos = Mouse.current.position.ReadValue();
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(mousePos);

        RaycastHit2D hit = Physics2D.Raycast(mouseWorldPos, Vector2.zero, 100, cookieLayer);

        // Debug.Log(hit.collider);

        if(hit.collider != null)
        {
            // Debug.Log("COOOOkIE");
            animator.Play("Cookie_Click_Animation",0,0);
            playerManager.AddCookie(1);
        }
    }
}
