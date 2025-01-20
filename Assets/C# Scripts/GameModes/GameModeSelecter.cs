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



    [SerializeField] private int selectedGameModeId;
    public GameMode SelectedGameMode => gameModes[selectedGameModeId];


    [SerializeField] private GameMode[] gameModes;


    public void SelectGameMode(int gameModeId)
    {
        selectedGameModeId = gameModeId;
    }
}
