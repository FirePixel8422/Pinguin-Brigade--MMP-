using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameModeSelecter : MonoBehaviour
{
    public GameMode selectedGameMode;

    [SerializeField] private Image[] gameModeButtons;

    [SerializeField] private Color[] selectionColors;



    private async void Start()
    {
        (bool succes, ValueWrapper<int> gameModeId) = await FileManager.LoadInfo<ValueWrapper<int>>("GameMode.json", false);

        if (succes)
        {
            selectedGameMode = (GameMode)gameModeId.value;

            print(gameModeId);
        }


        for (int i = 0; i < gameModeButtons.Length; i++)
        {
            gameModeButtons[i].color = selectionColors[0];
        }

        gameModeButtons[(int)selectedGameMode].color = selectionColors[1];
    }


    public enum GameMode
    {
        Deathmatch,
        TeamDeathmatch,
        KingOfTheHill,
        GunGame,
    }



    public async void SelectGameMode(int gameModeId)
    {
        gameModeButtons[(int)selectedGameMode].color = selectionColors[0];

        selectedGameMode = (GameMode)gameModeId;

        gameModeButtons[(int)selectedGameMode].color = selectionColors[1];

        await FileManager.SaveInfo(new ValueWrapper<int>(gameModeId), "GameMode.json", false);
    }
}
