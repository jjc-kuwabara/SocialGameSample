using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using System;

public class UserDataManager : SingletonMonoBehaviour<UserDataManager>
{
    // ユーザデータを取得.PHPを介して、JJCのLAMPサーバー上のデータベースにアクセスしている.
    public void CallUserData_RendererSample(int userId)
    {
        string url = "http://35.79.36.5/PHPFolder/Jugyo/GetUserDataFromUserId.php?userId=" + userId;

        StartCoroutine(GetUserData(url, ()=>RefreshRendererSampleUI()));
    }

    public void CallUserData_LobbySystem(int userId)
    {
        string url = "http://35.79.36.5/PHPFolder/Jugyo/GetUserDataFromUserId.php?userId=" + userId;

        StartCoroutine(GetUserData(url, ()=>RefreshLobbySystemUI()));
        RefreshLobbySystemUI();
    }    

    public void CallAddPoint(int userId)
    {
        string url = "http://35.79.36.5/PHPFolder/Jugyo/AddPoint.php?userId=" + userId;

        StartCoroutine(UrlAccess(url));
    }

    public void CallSubPoint(int userId)
    {
        string url = "http://35.79.36.5/PHPFolder/Jugyo/SubPoint.php?userId=" + userId;

        StartCoroutine(UrlAccess(url));
    }

    public void CallGachaPointAdd(int userId)
    {
        string url = "http://35.79.36.5/PHPFolder/Jugyo/AddPoint.php?userId=" + userId;

        StartCoroutine(UrlAccess(url, ()=>CallUserData_LobbySystem(userId)));
    }

    public void CallGachaPointSub1(int userId)
    {
        string url = "http://35.79.36.5/PHPFolder/Jugyo/SubPoint_Gacha1.php?userId=" + userId;

        StartCoroutine(UrlAccess(url, ()=>CallUserData_LobbySystem(userId)));
    }

    public void CallGachaPointSub10(int userId)
    {
        string url = "http://35.79.36.5/PHPFolder/Jugyo/SubPoint_Gacha10.php?userId=" + userId;

        StartCoroutine(UrlAccess(url, ()=>CallUserData_LobbySystem(userId)));
    }

    public void CallHasCharaFlagReset(int userId){
        string url = "http://35.79.36.5/PHPFolder/Jugyo/ResetHasCharaFlag.php?userId=" + userId;

        StartCoroutine(UrlAccess(url));

    }

    // ユーザデータを取得してきて、メンバ変数に格納する.
    IEnumerator GetUserData(string url, UnityAction callbackFunc = null)
    {
        WWWForm form = new WWWForm();
        using (WWW www = new WWW(url, form))
        {
            yield return www;
            if (!string.IsNullOrEmpty(www.error))
            {
                Debug.Log("error:" + www.error);
                yield break;
            }
            Debug.Log("text:" + www.text);

            string resultText = www.text;
            string[] resultTextArray = resultText.Split(",");
            m_userId = resultTextArray[0];
            m_name = resultTextArray[1];
            m_pass = resultTextArray[2];
            m_point = resultTextArray[3];

            if(callbackFunc != null){
                callbackFunc();
            }
        }
    }

    private void RefreshRendererSampleUI(){
            UserDataRenderer userDataRenderer = GameObject.Find("UserDataRenderer").GetComponent<UserDataRenderer>();
            userDataRenderer.Refresh(m_userId, m_name, m_pass, m_point);
    }

    private void RefreshLobbySystemUI(){
        LobbyUserDataRenderer lobbyUserDataRenderer = GameObject.Find("LobbyUserDataRenderer").GetComponent<LobbyUserDataRenderer>();
        lobbyUserDataRenderer.RefreshUserData(m_name);
        LobbyGachaPointRenderer lobbyGachaPointRenderer = GameObject.Find("LobbyGachaPointRenderer").GetComponent<LobbyGachaPointRenderer>();
        lobbyGachaPointRenderer.RefreshGachaPoint(m_point);
    }

    // 単純に当該のURLにアクセスする.
    IEnumerator UrlAccess(string url, UnityAction callbackFunc = null)
    {
        WWWForm form = new WWWForm();
        using (WWW www = new WWW(url, form))
        {
            yield return www;
            if (!string.IsNullOrEmpty(www.error))
            {
                Debug.Log("error:" + www.error);
                yield break;
            }
            Debug.Log("text:" + www.text);

            if(callbackFunc != null){
                callbackFunc();
            }
        }
    }

    override protected void OnCreateInstance(){
        Debug.Log("UserDataManager OnCreateInstance SceneName:" + SceneManager.GetActiveScene().name );
        // インスタンス作成時のコールバック.
        if(SceneManager.GetActiveScene().name == "RenderSample"){
            CallUserData_RendererSample(1);
        }else{
            CallUserData_LobbySystem(1);
        }
    }

    public void OnStartLobbyStaticUIManager(){
        if(m_name != ""){
            RefreshLobbySystemUI();
        }
    }

    public string GetCurrentUserId(){
        return m_userId;
    }

    // UserDataManagerクラスのメンバ変数の宣言.
    string m_userId = "";
    string m_name = "";
    string m_pass = "";
    string m_point = "";
}
