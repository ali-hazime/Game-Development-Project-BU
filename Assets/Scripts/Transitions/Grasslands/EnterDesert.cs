﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterDesert : MonoBehaviour
{
    private PlayerChar player;
    [SerializeField] ItemSaveManager itemSaveManager;
    [SerializeField] InventoryManager inventoryManager;

    public void Start()
    {
        if (itemSaveManager == null)
        {
            itemSaveManager = FindObjectOfType<ItemSaveManager>();
        }

        if (inventoryManager == null)
        {
            inventoryManager = FindObjectOfType<InventoryManager>();
        }
        if (player == null)
        {
            player = FindObjectOfType<PlayerChar>();
        }
    }
    private void OnTriggerEnter2D(Collider2D thing)
    {
        if (thing.CompareTag("Player"))
        {
            if (GameSavingInformation.desertMazeComplete)
            {
                QuestTracker.talkToComplete = false;
                QuestTracker.grasslandsQuestCount = 8;
                GameSavingInformation.whereAmI = "Jeralehar Desert";
                GameSavingInformation.whereWasI = SceneManager.GetActiveScene().name;
                SceneManager.LoadScene("Jeralehar Desert");
                GameSavingInformation.maxCurrency = 10;
                GameSavingInformation.minCurrency = 5;
                GameSavingInformation.playerX = 26.5f;
                GameSavingInformation.playerY = 35f;
                SaveSystem.SavePlayer(player);
                SaveSystem.SaveGameInfo();
                SaveSystem.SaveQuestInfo();
                itemSaveManager.SaveEquipment(inventoryManager);
                itemSaveManager.SaveInventory(inventoryManager);
            }
            else
            {
                QuestTracker.talkToComplete = false;
                QuestTracker.grasslandsQuestCount = 8;
                GameSavingInformation.whereAmI = "Desert Maze";
                GameSavingInformation.whereWasI = SceneManager.GetActiveScene().name;
                SceneManager.LoadScene("Desert Maze");
                GameSavingInformation.maxCurrency = 10;
                GameSavingInformation.minCurrency = 5;
                GameSavingInformation.playerX = 185f;
                GameSavingInformation.playerY = 225f;
                SaveSystem.SavePlayer(player);
                SaveSystem.SaveGameInfo();
                SaveSystem.SaveQuestInfo();
                itemSaveManager.SaveEquipment(inventoryManager);
                itemSaveManager.SaveInventory(inventoryManager);
            }
        }
    }
}
