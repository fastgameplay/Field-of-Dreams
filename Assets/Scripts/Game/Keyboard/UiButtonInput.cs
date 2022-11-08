using UnityEngine;
using UnityEngine.UI;

public class UiButtonInput : MonoBehaviour{
    [SerializeField] WordController _wordController;
    char _character;
    void Awake(){
        _character = gameObject.transform.GetChild(0).GetComponent<Text>().text[0];
    }

    public void Press(){
        _wordController.KeyPressed(_character);
        gameObject.SetActive(false);
    }

}
