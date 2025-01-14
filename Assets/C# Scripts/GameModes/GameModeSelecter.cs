using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameModeSelecter : MonoBehaviour
{
    public static GameModeSelecter Instance;
    private void Awake()
    {
        Instance = this;
    }



    private int selectedGameModeId;
    public GameMode SelectedGameMode => gameModes[selectedGameModeId];


    [SerializeField] private GameMode[] gameModes;

    [SerializeField] private Image[] gameModeButtons;

    [SerializeField] private Color selectedColor, unSelectedColor;



    private async void Start()
    {
        (bool succes, ValueWrapper<int> gameModeId) = await FileManager.LoadInfo<ValueWrapper<int>>("GameMode.json", false);

        if (succes)
        {
            selectedGameModeId = gameModeId.value;
        }


        for (int i = 0; i < gameModeButtons.Length; i++)
        {
            gameModeButtons[i].color = unSelectedColor;
        }

        gameModeButtons[selectedGameModeId].color = selectedColor;
    }



    public async void SelectGameMode(int gameModeId)
    {
        gameModeButtons[selectedGameModeId].color = unSelectedColor;

        selectedGameModeId = gameModeId;

        gameModeButtons[selectedGameModeId].color = selectedColor;

        await FileManager.SaveInfo(new ValueWrapper<int>(gameModeId), "GameMode.json", false);
    }
}
