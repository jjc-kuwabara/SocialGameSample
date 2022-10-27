using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserDataManager : MonoBehaviour
{
    // ユーザデータを取得.PHPを介して、JJCのLAMPサーバー上のデータベースにアクセスしている.
    public void CallUserData(int userId)
    {
        string url = "http://35.79.36.5/PHPFolder/Jugyo/GetUserDataFromUserId.php?userId=" + userId;

        StartCoroutine(GetUserData(url));
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

    IEnumerator GetUserData(string url)
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

            UserDataRenderer userDataRenderer = GameObject.Find("UserDataRenderer").GetComponent<UserDataRenderer>();
            userDataRenderer.Refresh(m_userId, m_name, m_pass, m_point);
        }
    }

    IEnumerator UrlAccess(string url)
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
        }
    }

    // UserDataManagerクラスのメンバ変数の宣言.
    string m_userId;
    string m_name;
    string m_pass;
    string m_point;
}
