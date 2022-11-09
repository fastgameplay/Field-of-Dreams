using UnityEngine;
using UnityEngine.UI;
public class LivesManager : MonoBehaviour{
    [SerializeField] Text _livesText;
    [SerializeField] ScriptableSettings settings;
    GameController _gameController;
    public int Lives{
        get{
            return _lives;
        }
        set{
            _livesText.text = value.ToString();
            _lives = value;
        }
    }
    int _lives;

    void Awake(){
        ResetLives();
    }

    public void ResetLives(){
        Lives = settings.LivesPerRound;
    }
}
