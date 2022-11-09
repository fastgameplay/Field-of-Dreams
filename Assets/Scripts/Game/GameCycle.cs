using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(LivesManager))]
[RequireComponent(typeof(ScoreManager))]

public class GameCycle : MonoBehaviour
{
    [SerializeField] Text _GameOverText;
    [SerializeField] WordManager _wordManager;
    [SerializeField] Keyboard _keyboard;
    ScoreManager _scoreManager;
    LivesManager _livesManager;

    void Awake(){
        _scoreManager = GetComponent<ScoreManager>();
        _livesManager = GetComponent<LivesManager>();
    }
    void Start(){
        _scoreManager.Score = 0;
        _wordManager.NextWord();
    }

    public void RestartRound(){
        if(_wordManager.WordsInBase == 0){
            _GameOverText.text = "YOU WON!!";
            EndGame();
            return;
        }
        StartCoroutine(IERestartRound());
    }
    public void EndGame(){
        StartCoroutine(IEEndGame());
    }
    IEnumerator IERestartRound(){
        _keyboard.Active = false;
        yield return new WaitForSeconds(3f);
        _keyboard.Active = true;
        _scoreManager.Score += _livesManager.Lives;
        _livesManager.ResetLives();
        _wordManager.NextWord();
    }

    IEnumerator IEEndGame(){
        _keyboard.Active = false;
        _GameOverText.gameObject.SetActive(true);
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(0);

    }


}
