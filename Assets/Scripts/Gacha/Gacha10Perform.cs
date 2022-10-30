using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gacha10Perform : GachaPerformBase
{
    // Start is called before the first frame update
    void Awake()
    {
        m_bgRenderer = this.transform.Find("BG").gameObject;
        m_gridRenderer = this.transform.Find("GridRenderer").gameObject;

        m_gridRenderer.SetActive(false);
    }

    override public void OnFinishPlayGacha(){
        m_gridRenderer.SetActive(true);
        m_isFinish = true;

        UserDataManager userDataManager = GameObject.Find("UserDataManager").GetComponent<UserDataManager>();
        string currentGachaResult = userDataManager.GetCurrentGachaResult();
        string[] arrayGachaResult = currentGachaResult.Split(",");

        for(int i = 0; i < 10; i++){
            m_gridRenderer.transform.Find("HLayout/CharaCell" + i).GetComponent<CharaCell>().RefreshCharaImage(int.Parse(arrayGachaResult[i]), false);
        }
    }

    GameObject m_bgRenderer;
    GameObject m_gridRenderer;
}
