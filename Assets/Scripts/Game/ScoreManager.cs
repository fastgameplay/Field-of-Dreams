using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour{
    [SerializeField] Text _scoreText;
    public int Score{
        get{
            return _score;
        }
        set{
            _scoreText.text = value.ToString();
            _score = value;
        }
    }
    int _score;
}
