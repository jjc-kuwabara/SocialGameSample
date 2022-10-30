using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GachaPerformBase : MonoBehaviour
{
    public virtual void OnFinishPlayGacha(){
    }

    public void OnClick(){
        if(m_isFinish){
            Destroy(this.gameObject);
        }
    }

    protected bool m_isFinish = false;
}
