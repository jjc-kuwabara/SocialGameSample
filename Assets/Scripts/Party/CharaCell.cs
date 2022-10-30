using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharaCell : MonoBehaviour
{
    void Awake(){
        m_nameText = this.transform.Find("CharaName").GetComponent<Text>();
        m_charaImage = this.transform.Find("CharaImage").GetComponent<Image>();
        m_notHasCover = this.transform.Find("NotHasCover").GetComponent<Image>();
    }

    public void RefreshCharaImage(int charaId, bool isNotHave){
        m_nameText.text = "キャラ" + charaId;
        m_charaImage.sprite = Resources.Load<Sprite>("CharaImage/CharaSample");
        m_notHasCover.enabled = isNotHave;
    }

    public void HideCharaImage(){
        m_nameText.text = "";
        m_charaImage.sprite = Resources.Load<Sprite>("CharaImage/NoChara");
        m_notHasCover.enabled = false;

    }

    Text m_nameText;
    Image m_charaImage;
    Image m_notHasCover;
}
