using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "GameSettings", menuName = "ScriptableObjects/GameSettings", order = 1)]
public class ScriptableSettings : ScriptableObject{
    [SerializeField] TextAsset _txtFile;
    [SerializeField] int _minWordLength;

    public List<string> GetWords(){
        string[] allWords = _txtFile.text.Split(new char[] {',',';','-',' ','.','?','!','`','\'','\"','*','`', ':' , '(', ')', '\r', '\n'});
        List<string> output = new List<string>();
        for (int i = 0; i < allWords.Length; i++){
            if(allWords[i].Length > _minWordLength){
                if(output.Contains(allWords[i].ToUpper()) == false)
                    output.Add(allWords[i].ToUpper());
            }
        }
        return output;
    }
}
