using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LivesManager))]
[RequireComponent(typeof(GameCycle))]
public class GameController : MonoBehaviour{
    GameCycle _gameCycle;

    LivesManager _livesManager;

    void Awake(){
        _livesManager = GetComponent<LivesManager>();
        _gameCycle = GetComponent<GameCycle>();
    }

    public void WrongButton(){
        _livesManager.Lives--;
        if(_livesManager.Lives <= 0){
            _gameCycle.EndGame();
        }
    }

    public void WinRound(){
        _gameCycle.RestartRound();
    }

}
