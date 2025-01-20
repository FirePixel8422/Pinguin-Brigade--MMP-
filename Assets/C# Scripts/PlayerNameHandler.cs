using TMPro;
using Unity.Collections;
using UnityEngine;


public class PlayerNameHandler : MonoBehaviour
{
    public static PlayerNameHandler Instance;
    private void Awake()
    {
        Instance = this;

        LoadPlayerName();
    }



    [SerializeField] private GameObject selectNameUI;

    [SerializeField] private TMP_InputField playerNameField;
    public string PlayerName { get; private set; }




    public async void LoadPlayerName()
    {
        (bool loadSucces, FixedString32Bytes name) = await FileManager.LoadInfo<FixedString32Bytes>("PlayerName");

        if (loadSucces)
        {
            PlayerName = name.ToString();
            playerNameField.text = name.ToString();
        }
        else
        {
            selectNameUI.SetActive(true);

            playerNameField.Select();
        }
    }

    public void OnChangeName(string newName)
    {
        PlayerName = newName;
    }

    public async void SaveName()
    {
        await FileManager.SaveInfo(new FixedString32Bytes(PlayerName), "PlayerName");
    }
}
