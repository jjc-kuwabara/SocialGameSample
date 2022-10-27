using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserIdInputPanel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        m_currentId = 1;
        m_userIdText = this.transform.Find("IdRenderer/Text").GetComponent<Text>();
        RefreshIdRenderer();
    }

    // 加算ボタン押下時の処理.
    public void OnClickAddButton()
    {
        m_currentId++;
        RefreshIdRenderer();
    }

    // 減算ボタン押下時の処理.
    public void OnClickSubButton()
    {
        m_currentId--;
        RefreshIdRenderer();
    }

    // 更新ボタン押下時の処理.
    public void OnClickRefreshButton()
    {
        UserDataManager userDataManager = GameObject.Find("UserDataManager").GetComponent<UserDataManager>();
        userDataManager.CallUserData(m_currentId);
    }

    // ID表示部分の更新.
    private void RefreshIdRenderer()
    {
        m_userIdText.text = m_currentId.ToString();
    }

    public int GetCurrentUserId()
    {
        return m_currentId;
    }

    // UserIdInputPanelクラスのメンバ変数の宣言.
    int m_currentId;
    Text m_userIdText;
}
