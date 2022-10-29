using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LobbySceneChangePanel : MonoBehaviour
{
    public void OnClickLobbyButton(){
        ChangeScene("Lobby_Main");
    }
    public void OnClickGachaButton(){
        ChangeScene("Lobby_Gacha");
    }
    public void OnClickPartyButton(){
        ChangeScene("Lobby_Party");
    }
    public void OnClickBattleButton(){
        ChangeScene("Lobby_Battle");
    }
    public void OnClickSystemButton(){
        ChangeScene("Lobby_System");
    }
    private void ChangeScene(string sceneName){
        SceneManager.LoadScene(sceneName);
    }
}
