using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsTester : MonoBehaviour{
    [SerializeField] ScriptableSettings settingsObj;
    [SerializeField] string[] words;
    void Start(){
        words = settingsObj.GetWordsArray();
    }
}
