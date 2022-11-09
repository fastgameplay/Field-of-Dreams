using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordController : MonoBehaviour
{
    public CharCube[] CharCubes;
    [SerializeField] GameController gameController; //:(
    int CharPressed {
        set{
            _charPressed = value;
            if(_charPressed == CharCubes.Length){
                foreach (CharCube i in CharCubes) i.GlowGreen();
                _charPressed = 0;
                gameController.WinRestartGame();
            }
        }
        get{return _charPressed;}
    }
    int _charPressed;
    void Update(){
        if (Input.GetKeyDown(KeyCode.Space))
        {
            for (int i = 0; i < CharCubes.Length; i++){
                CharCubes[i].Open();
                
            }
        }
    }

    public void KeyPressed(char key){
        int keyInWord = 0;
        foreach (CharCube i in CharCubes){
            if (i.Character == key){
                i.Open();
                keyInWord++;
            }
        }
        if(keyInWord == 0){
            foreach (CharCube i in CharCubes){
                i.GlowRed();
            } 
            gameController.WrongButton();
        }
        CharPressed += keyInWord;
    }

   
}
