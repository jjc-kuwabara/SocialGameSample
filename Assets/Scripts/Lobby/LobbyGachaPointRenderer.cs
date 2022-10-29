using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LobbyGachaPointRenderer : MonoBehaviour
{
    void Awake()
    {
        m_gachaPointText = this.transform.Find("HLayout/PointNumText").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RefreshGachaPoint(string point){
        m_gachaPointText.text = point;
    }

    Text m_gachaPointText = null;
}
