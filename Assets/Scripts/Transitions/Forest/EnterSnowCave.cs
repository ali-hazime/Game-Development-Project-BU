﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterSnowCave : MonoBehaviour
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
            QuestTracker.talkToComplete = false;
            QuestTracker.forestQuestCount = 6;
            GameSavingInformation.whereAmI = "SnowCave";
            GameSavingInformation.whereWasI = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene("SnowCave");
            GameSavingInformation.maxCurrency = 19;
            GameSavingInformation.minCurrency = 14;
            GameSavingInformation.playerX = 0f;
            GameSavingInformation.playerY = -1.25f;
            SaveSystem.SavePlayer(player);
            SaveSystem.SaveGameInfo();
            SaveSystem.SaveQuestInfo();
            itemSaveManager.SaveEquipment(inventoryManager);
            itemSaveManager.SaveInventory(inventoryManager);
        }
    }
}
