using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GachaButtonPanel : MonoBehaviour
{
    // ポイント加算ボタン押下時の処理.
    public void OnClickGachaPointAddButton()
    {
        UserDataManager userDataManager = GameObject.Find("UserDataManager").GetComponent<UserDataManager>();
        int currentUserId = int.Parse(userDataManager.GetCurrentUserId());
        userDataManager.CallGachaPointAdd(currentUserId);
    }

    // ポイント減算ボタン押下時の処理.
    public void OnClickGachaPointSub1Button()
    {
        UserDataManager userDataManager = GameObject.Find("UserDataManager").GetComponent<UserDataManager>();
        int currentUserId = int.Parse(userDataManager.GetCurrentUserId());
        userDataManager.CallGachaPointSub1(currentUserId);
    }
}
