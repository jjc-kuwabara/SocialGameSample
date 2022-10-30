using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GachaPerformManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CallGacha1(){
        GameObject prefab = Resources.Load<GameObject>("Prefab/Gacha/Gacha1Perform");
        GameObject instance = Instantiate(prefab);
        instance.transform.SetParent(this.transform);

        RectTransform rectTrans = instance.transform as RectTransform;
        rectTrans.anchoredPosition = new Vector2(0,0);

        m_gachaPerform = instance.GetComponent<Gacha1Perform>();
    }

    public void CallGacha10(){
        GameObject prefab = Resources.Load<GameObject>("Prefab/Gacha/Gacha10Perform");
        GameObject instance = Instantiate(prefab);
        instance.transform.SetParent(this.transform);

        RectTransform rectTrans = instance.transform as RectTransform;
        rectTrans.anchoredPosition = new Vector2(0,0);

        m_gachaPerform = instance.GetComponent<Gacha10Perform>();
    }    

    public void OnFinishPlayGacha(){
        if(m_gachaPerform != null){
            m_gachaPerform.OnFinishPlayGacha();
        }
    }

    GachaPerformBase m_gachaPerform;
}
