﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    public GameObject questCanvas;
    public SaveLoadButtonForMenu slButton;
    [SerializeField] QuestController questController;
    public SelectDifficulty selectDifficulty;
    public GameObject Music;

    private void Awake()
    {
        if (questController == null)
        {
            questController = FindObjectOfType<QuestController>();
        }

        if (selectDifficulty == null)
        {
            selectDifficulty = FindObjectOfType<SelectDifficulty>();
        }
    }

    private void Start()
    {
        if (Music == null)
        {
            Music = GameObject.Find("Music");
        }
    }
    public void StartGame() 
    {
        SceneManager.LoadScene("GameSelectPage");
    }

    //This will be changed once the start of the game is updated
    public void GrassLandNew()
    {
        NewGame();
        SceneManager.LoadScene("Player House");
        Destroy(Music);
    }

    public void ContinueGame()
    {
        Destroy(Music);
        QuestInfo QIdata = SaveSystem.LoadQuestInfo();
        QuestTracker.questInProgress = QIdata.questInProgressS;
        QuestTracker.mainQuestCount = QIdata.mainQuestCountS;
        QuestTracker.questType = QIdata.questTypeS;
        QuestTracker.beginDesertQ3 = QIdata.beginDesertQ3S;
        QuestTracker.allTotemsCollected = QIdata.allTotemsCollectedS;
        QuestTracker.allObjCompleted = QIdata.allObjCompletedS;
        QuestTracker.triggerOnce = QIdata.triggerOnceS;
        QuestTracker.triggerOnce2 = QIdata.triggerOnce2S;
        QuestTracker.fQ2_Item1 = QIdata.fQ2_Item1S;
        QuestTracker.fQ2_Item2 = QIdata.fQ2_Item2S;
        QuestTracker.fQ2_Item3 = QIdata.fQ2_Item3S;

        if (QuestTracker.questInProgress)
        {
            questController.ContinueQuest(QuestTracker.mainQuestCount, QuestTracker.questType);
        }

        InfoGameData GIdata = SaveSystem.LoadGameInfo();
        GameSavingInformation.differenceNumber = GIdata.differenceNumberS;
        GameSavingInformation.whereAmI = GIdata.whereAmIS;
        GameSavingInformation.whereWasI = GIdata.whereWasIS;
        GameSavingInformation.bonusHealth = GIdata.bonusHealthS;
        SceneManager.LoadScene(GameSavingInformation.whereAmI);
    }

    
    void NewGame()
    {
        QuestTracker.questInProgress = false;
        QuestTracker.bossKilled = false;
        QuestTracker.isKillQuest = false;
        QuestTracker.isItemQuest = false;
        QuestTracker.escortComplete = false;
        QuestTracker.talkToComplete = false;
        QuestTracker.beginDesertQ3 = false;
        QuestTracker.allTotemsCollected = false;
        QuestTracker.allObjCompleted = true;
        QuestTracker.triggerOnce = true;
        QuestTracker.triggerOnce2 = true;

        QuestTracker.killCount = 0;
        QuestTracker.itemCount = 0;
        GameSavingInformation.differenceNumber = Random.Range(1, 7);
        QuestTracker.fQ2_Item1 = true;
        QuestTracker.fQ2_Item2 = true;
        QuestTracker.fQ2_Item3 = true;

        QuestTracker.mainQuestCount = 0;
        QuestTracker.questType = "";
        QuestTracker.grasslandsQuestCount = 0;
        QuestTracker.desertQuestCount = 0;
        QuestTracker.forestQuestCount = 0;
        QuestTracker.snowMountainQuestCount = 0;
        QuestTracker.volcanoQuestCount = 0;

        GameSavingInformation.isNewGame = true;
        GameSavingInformation.playerX = 0f;
        GameSavingInformation.playerY = 8f;
        GameSavingInformation.whereAmI = "Player House";
        GameSavingInformation.whereWasI = "";
        GameSavingInformation.healthMulti = selectDifficulty.statBoost;
        GameSavingInformation.bonusHealth = 100 * GameSavingInformation.healthMulti;
        GameSavingInformation.crystalsCount = 0;
        GameSavingInformation.minCurrency = 3;
        GameSavingInformation.maxCurrency = 7;

        GameSavingInformation.ruby1Collected = false;
        GameSavingInformation.ruby1Collected = false;
        GameSavingInformation.ruby3Collected = false;
        GameSavingInformation.ruby4Collected = false;
        GameSavingInformation.ruby5Collected = false;
        GameSavingInformation.ruby6Collected = false;
        GameSavingInformation.ruby7Collected = false;
        GameSavingInformation.ruby8Collected = false;
        GameSavingInformation.ruby9Collected = false;
        GameSavingInformation.ruby10Collected = false;

        GameSavingInformation.sapphire1Collected = false;
        GameSavingInformation.sapphire2Collected = false;
        GameSavingInformation.sapphire3Collected = false;
        GameSavingInformation.sapphire4Collected = false;
        GameSavingInformation.sapphire5Collected = false;

        GameSavingInformation.dropChanceModifier = 0;
        GameSavingInformation.grassBossDefeated = false;
        GameSavingInformation.forestBossDefeated = false;
        GameSavingInformation.desertBossDefeated = false;
        GameSavingInformation.snowBossDefeated = false;
        GameSavingInformation.fireBossDefeated = false;
        GameSavingInformation.finalBossDefeated = false;

        //Grasslands Quests
        GameSavingInformation.grassQuest1Complete = false;
        GameSavingInformation.grassQuest2Complete = false;
        GameSavingInformation.grassQuest3Complete = false;
        GameSavingInformation.grassQuest4Complete = false;
        GameSavingInformation.grassQuest5Complete = false;
        GameSavingInformation.grassQuest6Complete = false;
        GameSavingInformation.grassQuest7Complete = false;


        //Forest Quests
        GameSavingInformation.forestQuest1Complete = false;
        GameSavingInformation.forestQuest2Complete = false;
        GameSavingInformation.forestQuest3Complete = false;
        GameSavingInformation.forestQuest4Complete = false;
        GameSavingInformation.forestQuest5Complete = false;

        //Desert Quests
        GameSavingInformation.desertMazeComplete = false;
        GameSavingInformation.desertQuest1Complete = false;
        GameSavingInformation.desertQuest2Complete = false;
        GameSavingInformation.desertQuest3Complete = false;
        GameSavingInformation.desertQuest4Complete = false;
        GameSavingInformation.desertQuest5Complete = false;
        GameSavingInformation.desertQuest6Complete = false;

        //Snow Mountain Quests
        GameSavingInformation.snowQuest1Complete = false;
        GameSavingInformation.snowQuest2Complete = false;
        GameSavingInformation.snowQuest3Complete = false;
  
        //Volcano Quests
        GameSavingInformation.volcanoQuest1Complete = false;
        GameSavingInformation.volcanoQuest2Complete = false;
        GameSavingInformation.volcanoQuest3Complete = false;
        GameSavingInformation.volcanoQuest4Complete = false;
        GameSavingInformation.volcanoQuest5Complete = false;


        SaveSystem.SaveGameInfo();
        SaveSystem.SaveQuestInfo();
    }
}
