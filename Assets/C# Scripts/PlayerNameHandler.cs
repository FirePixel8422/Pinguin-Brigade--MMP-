using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerNameHandler : MonoBehaviour
{
    public static PlayerNameHandler Instance;
    private void Awake()
    {
        Instance = this;
    }



    public TMP_InputField playerNameField;
    public string playerName = "New Player";


    private void Start()
    {
        LoadPlayerName();
    }


    public async void LoadPlayerName()
    {
        (bool loadSucces, FixedString32Bytes name) = await FileManager.LoadInfo<FixedString32Bytes>("PlayerName");

        if (loadSucces)
        {
            playerName = name.ToString();
            playerNameField.text = playerName;

            string lobbyName = playerName.Length < 8 ? playerName : playerName[..4] + "...";

            LobbyRelay.Instance.lobbyNameField.text = lobbyName + "'s Lobby";
        }
    }

    public async void OnChangeName(string newName)
    {
        playerName = newName;

        string lobbyName = playerName.Length < 8 ? playerName : playerName[..4] + "...";

        LobbyRelay.Instance.lobbyNameField.text = lobbyName + "'s Lobby";

        await FileManager.SaveInfo(new FixedString32Bytes(newName), "PlayerName.json");
    }
}
