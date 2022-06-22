using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContinueGame : MonoBehaviour
{

    public JsonHandler jsonHandler;
    public PlayerData playerData;
    public Button continueButton;

    private void Start()
    {
        ContinueCheck();
    }

    //checks if the player has saved before and by checking if playersaved is true
    public void ContinueCheck()
    {
        playerData = jsonHandler.ReadFromJson<PlayerData>("PlayerData");
        
        if (playerData.playerSaved == false || playerData == null)
        {
            continueButton.interactable = false;
        }
        else if(playerData.playerSaved == true) 
        {
            continueButton.interactable = true;
        }
    }

}


