using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordController : MonoBehaviour
{
    public CharCube[] CharCubes;

    void Update(){
        if (Input.GetKeyDown(KeyCode.Space))
        {
            for (int i = 0; i < CharCubes.Length; i++){
                CharCubes[i].Open();
                
            }
        }
    }
}
