using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour{
    [SerializeField] ScriptableSettings _settings;
    [SerializeField] WordSpawner wordSpawner;
    [SerializeField] Keyboard keyboard;
    List<string> _availableWords;
    void Start(){
        StartNewGame();
    }

    void StartNewGame(){
        _availableWords = _settings.GetWords();
        wordSpawner.SpawnWord(GetRandomWord());
    }

    public void RestartGame(){
        StartCoroutine(IERestartGame());
    }
    string GetRandomWord(){
        Debug.Log(_availableWords.Count);
        int index = Random.Range(0,_availableWords.Count);
        string str = _availableWords[index];
        _availableWords.RemoveAt(index);
        Debug.Log(_availableWords.Count);
        return str;
    }

    IEnumerator IERestartGame(){
        keyboard.Active = false;
        yield return new WaitForSeconds(3);
        wordSpawner.DestroyWord();
        keyboard.Active = true;
        wordSpawner.SpawnWord(GetRandomWord());
    }
}
