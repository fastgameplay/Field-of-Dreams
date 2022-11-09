using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordController : MonoBehaviour
{
    public CharCube[] CharCubes;
    [SerializeField] GameController _gameController; 
    int OpenCharacters {
        set{
            _openCharacters = value;
            WinCheck();
        }
        get{return _openCharacters;}
    }
    int _openCharacters;



    public void KeyPressed(char ch){
        int charInWord = 0;
        foreach (CharCube i in CharCubes){
            if (i.Character == ch){
                i.Open();
                charInWord++;
            }
        }
        if(charInWord == 0){
            WrongButton();
        }

        OpenCharacters += charInWord;
    }
    void WrongButton(){
        foreach (CharCube i in CharCubes) i.GlowRed();
        _gameController.WrongButton();
    }
    void WinCheck(){
        if(_openCharacters == CharCubes.Length){
            foreach (CharCube i in CharCubes) i.GlowGreen();
            _gameController.WinRound();
            _openCharacters = 0;
        }
    }
   
}
