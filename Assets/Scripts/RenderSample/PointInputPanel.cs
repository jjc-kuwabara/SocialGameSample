using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointInputPanel : MonoBehaviour
{
    // ポイント加算ボタン押下時の処理.
    public void OnClickPointAddButton()
    {
        UserIdInputPanel userIdInputPanel = GameObject.Find("UserIdInputPanel").GetComponent<UserIdInputPanel>();
        int currentId = userIdInputPanel.GetCurrentUserId();

        UserDataManager userDataManager = GameObject.Find("UserDataManager").GetComponent<UserDataManager>();
        userDataManager.CallAddPoint(currentId);
    }

    // ポイント減算ボタン押下時の処理.
    public void OnClickPointSubButton()
    {
        UserIdInputPanel userIdInputPanel = GameObject.Find("UserIdInputPanel").GetComponent<UserIdInputPanel>();
        int currentId = userIdInputPanel.GetCurrentUserId();

        UserDataManager userDataManager = GameObject.Find("UserDataManager").GetComponent<UserDataManager>();
        userDataManager.CallSubPoint(currentId);
    }
}
