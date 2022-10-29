using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyStaticUIManager : MonoBehaviour
{
    void Start()
    {
        UserDataManager userDataManager = GameObject.Find("UserDataManager").GetComponent<UserDataManager>();
        userDataManager.OnStartLobbyStaticUIManager();
    }
}
