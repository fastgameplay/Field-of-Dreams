using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(WordSpawner))]
public class WordManager : MonoBehaviour{
    [SerializeField] ScriptableSettings _settings;
    WordSpawner _wordSpawner;

    List<string> _availableWords;
    int randomWordIndex{get{return Random.Range(0,_availableWords.Count);}}

    void Awake(){
        ResetWords();
        _wordSpawner = GetComponent<WordSpawner>();

    }

    public void NextWord(){
        _wordSpawner.DestroyWord();
        _wordSpawner.SpawnWord( GetWord(randomWordIndex) );
    }
    
    void ResetWords(){
        _availableWords = _settings.GetWords();
    }

    string GetWord(int index){
        string str = _availableWords[index];
        _availableWords.RemoveAt(index);
        return str;
    }
    
}
