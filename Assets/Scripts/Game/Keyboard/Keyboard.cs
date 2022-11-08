using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keyboard : MonoBehaviour
{
    [SerializeField] GameObject[] buttons;
    public bool Active{set{setActive(value);} }
    void setActive(bool value){
        foreach (GameObject i in buttons){
            i.SetActive(value);
        }
    }
   
}
