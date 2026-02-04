using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinButton : MonoBehaviour
{
    public PlayerManager playerManager;
    Button button;

    void Start()
    {
        button = GetComponent<Button>();
        button.interactable = false;
        
    }

    void Update()
    {
        //Qua forse è meglio farlo con un evento invece di controllare sempre, ma sono a corto di tempo ormai
        if(playerManager.GetCookie()>=400){
            button.interactable = true;
        }
        else
        {
            button.interactable = false; 
        }
    }

    public void Victory()
    {
        SceneManager.LoadScene("Victory");
    }
}
