using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartyCharaGridRenderer : MonoBehaviour
{
    void Awake(){
        m_mouseHold = false;

        m_gridMenuRectTrans = this.transform.Find("RectMask/VLayout").transform as RectTransform;
        m_currentGridPosition = m_gridMenuRectTrans.anchoredPosition;


    }
    // Start is called before the first frame update
    void Start()
    {
        RefreshGrid();
    }

    // Update is called once per frame
    void Update()
    {
        if(m_mouseHold){
            Vector2 currentMousePosition = Input.mousePosition;
            Vector2 diffPosition = currentMousePosition - m_holdStartMousePosition;

            float yPosition = m_currentGridPosition.y + diffPosition.y;

            if(yPosition < MIN_Y_POSITION){
                yPosition = MIN_Y_POSITION;
            }
            if(yPosition > MAX_Y_POSITION){
                yPosition = MAX_Y_POSITION;
            }

            m_gridMenuRectTrans.anchoredPosition = new Vector2(m_currentGridPosition.x, yPosition);
        }
    }

    public void OnMouseButtonDown(){
        m_mouseHold = true;
        m_holdStartMousePosition = Input.mousePosition;
    }

    public void OnMouseButtonUp(){
        m_mouseHold = false;

        m_currentGridPosition = m_gridMenuRectTrans.anchoredPosition;
    }

    public void RefreshGrid(){
        GameObject obj = GameObject.Find("UserDataManager");
        string strHasCharaFlag = "0";
        uint hasCharaFlag = 0;
        if(obj != null){
            UserDataManager userDataManager = obj.GetComponent<UserDataManager>();
            strHasCharaFlag = userDataManager.GetCurrentHasCharaFlag();
        }
        hasCharaFlag = uint.Parse(strHasCharaFlag);

        Debug.Log("hasCharaFlag:" + hasCharaFlag.ToString());

        for(int charaId = MIN_CHARA_ID; charaId <= MAX_CHARA_ID; charaId++){
            Transform trans = this.transform.Find("RectMask/VLayout/HLayout/CharaCell" + charaId.ToString());
            CharaCell charaCell = trans.GetComponent<CharaCell>();

            bool isNotHaveChara = false;
            if( (hasCharaFlag & (1 << charaId)) == 0 ){
                isNotHaveChara = true;
            }
            charaCell.RefreshCharaImage(charaId, isNotHaveChara);
        }

        {
            CharaCell charaCell = this.transform.Find("RectMask/VLayout/HLayout/CharaCell32").GetComponent<CharaCell>();
            charaCell.HideCharaImage();
        }
    }

    bool m_mouseHold;
    Vector2 m_holdStartMousePosition;
    Vector2 m_currentGridPosition;
    RectTransform m_gridMenuRectTrans;

    const int CELL_SIZE = 100;

    const int MIN_Y_POSITION = -400;
    const int MAX_Y_POSITION = 400;

    const int MIN_CHARA_ID = 0;
    const int MAX_CHARA_ID = 31;
}
