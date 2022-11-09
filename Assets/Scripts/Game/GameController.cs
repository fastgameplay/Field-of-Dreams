using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(LivesManager))]
[RequireComponent(typeof(ScoreManager))]
public class GameController : MonoBehaviour{
    [SerializeField] ScriptableSettings _settings;
    [SerializeField] WordSpawner wordSpawner;
    [SerializeField] Keyboard keyboard;


    [SerializeField] GameObject _gameOverText;

    List<string> _availableWords;


    ScoreManager _scoreManager;
    LivesManager _livesManager;

    void Awake(){
        _scoreManager = GetComponent<ScoreManager>();
        _livesManager = GetComponent<LivesManager>();
    }
    void Start(){
        StartNewGame();
        _scoreManager.Score = 0;
    }


    public void WrongButton(){
        _livesManager.Lives--;
        if(_livesManager.Lives <= 0){
        StartCoroutine(IEEndGame());
        }
    }

    public void WinRestartGame(){
        StartCoroutine(IERestartGame());
    }
    IEnumerator IERestartGame(){
        keyboard.Active = false;
        yield return new WaitForSeconds(3);
        _scoreManager.Score += _livesManager.Lives;
        _livesManager.ResetLives();
        wordSpawner.DestroyWord();
        keyboard.Active = true;

        wordSpawner.SpawnWord(GetRandomWord());
    }
     IEnumerator IEEndGame(){
        _gameOverText.SetActive(true);
        keyboard.Active = false;

        yield return new WaitForSeconds(3);
    
        SceneManager.LoadScene(0);

    }
    void StartNewGame(){
        _availableWords = _settings.GetWords();
        wordSpawner.SpawnWord(GetRandomWord());
    }
    
    string GetRandomWord(){
        Debug.Log(_availableWords.Count);
        int index = Random.Range(0,_availableWords.Count);
        string str = _availableWords[index];
        _availableWords.RemoveAt(index);
        Debug.Log(_availableWords.Count);
        return str;
    }

}
