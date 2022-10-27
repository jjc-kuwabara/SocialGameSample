using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserDataRenderer : MonoBehaviour
{
    void Start()
    {
        // Textコンポーネントの取得と、メンバ変数への格納.
        m_userIdText = this.transform.Find("UserId/Text").GetComponent<Text>();
        m_nameText = this.transform.Find("Name/Text").GetComponent<Text>();
        m_passText = this.transform.Find("Pass/Text").GetComponent<Text>();
        m_pointText = this.transform.Find("Point/Text").GetComponent<Text>();

        // 初期値の代入.
        Refresh("999", "テスト", "1111", "999");
    }

    // 表示内容の更新.
    public void Refresh(string userId, string name, string pass, string point)
    {
        m_userIdText.text = userId;
        m_nameText.text = name;
        m_passText.text = pass;
        m_pointText.text = point;
    }

    // UserDataRendererクラスのメンバ変数の宣言.
    Text m_userIdText;
    Text m_nameText;
    Text m_passText;
    Text m_pointText;
}
