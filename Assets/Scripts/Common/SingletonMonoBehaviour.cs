using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class SingletonMonoBehaviour<T> : MonoBehaviour where T : MonoBehaviour{

    private static T instance;
    public static T Instance
    {
        get{
            if (instance == null) {
                Type t = typeof(T);

                instance = (T)FindObjectOfType (t);
                if (instance == null) {
                    Debug.LogError (t + " をアタッチしているGameObjectはありません");
                }
            }

            return instance;
        }
    }

    virtual protected void Awake(){
        // 他のゲームオブジェクトにアタッチされているか調べる
        // アタッチされている場合は破棄する。
        CheckInstance();
    }

    virtual protected void Start(){
        if(m_isCallCreateInstanceCallback){
            OnCreateInstance();
        }
    }

    protected bool CheckInstance(){
        if (instance == null) {
            instance = this as T;
            m_isCallCreateInstanceCallback = true;
            DontDestroyOnLoad (gameObject);
            return true;
        } else if (Instance == this) {
            m_isCallCreateInstanceCallback = false;
            return true;
        }
        Destroy (this);
        return false;
    }

    virtual protected void OnCreateInstance(){
        // インスタンス作成時のコールバック.
        Type t = typeof(T);
        Debug.Log(t + "インスタンスを作成.");
    }

    private bool m_isCallCreateInstanceCallback = true;
}