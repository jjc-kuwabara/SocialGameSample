using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LobbyUserDataRenderer : MonoBehaviour
{
    void Awake()
    {
        m_userNameText = this.transform.Find("HLayout/NameText").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RefreshUserData(string name){
        m_userNameText.text = name;
    }

    Text m_userNameText = null;
}
