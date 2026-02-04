using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class SpawnButton : MonoBehaviour
{
    private Button button; 

    public PlayerManager playerManager; 

    public int cost = 15; 
    public GuiManager guiManager; 

    public GameObject clickerPrefab;
    public Transform clickerContainerTransform;
    public float radius = 3f;

    private int currentClickers = 0;
    private int maxClickers = 20;

    void Start()
    {
        button = GetComponent<Button>();
        button.interactable = false; 
        guiManager.UpdateCostSpawn(cost);
    }
    
    void Update()
    {
        if(playerManager.GetCookie() >= cost)
        {
            button.interactable = true;
        }
        else
        {
            button.interactable = false; 
        }
    }

    public void UpdateSpawnCost(int amount)
    {
        cost = amount; 
        guiManager.UpdateCostSpawn(cost);
    }

    public void SpawnClicker()
    {
        if(currentClickers >= maxClickers)
        {
            return; 
        }

        playerManager.SubCookie(cost);


        //Qua mi sono fatto aiutare da internet, non riuscivo a spawnarli bene in cerchio che puntavano il cookie
        float angle = currentClickers * (360f / maxClickers);
        Quaternion rotation = Quaternion.Euler(0,0, angle);

        GameObject newClicker = Instantiate(clickerPrefab, clickerContainerTransform);

        Vector2 spawnOffset = rotation * Vector2.down * radius;

        newClicker.transform.localPosition = spawnOffset;

        newClicker.transform.localRotation = rotation;

        currentClickers++;



        int updatedCost = Mathf.RoundToInt(cost * 1.15f);

        UpdateSpawnCost(updatedCost);

    }
}
