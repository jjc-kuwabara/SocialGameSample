using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HasCharaFlagClearButton : MonoBehaviour
{
    // 更新ボタン押下時の処理.
    public void OnClick()
    {
        UserDataManager userDataManager = GameObject.Find("UserDataManager").GetComponent<UserDataManager>();
        string userId = userDataManager.GetCurrentUserId();
        userDataManager.CallHasCharaFlagReset(int.Parse(userId));
    }
}
