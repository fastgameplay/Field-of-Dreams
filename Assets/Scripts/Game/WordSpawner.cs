using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(WordController))]
public class WordSpawner : MonoBehaviour{
    [SerializeField] CharCube charCubePrefab;

    public void SpawnWord(string word){
        int startxPos = -(word.Length-1);
        for (int i = 0; i < word.Length; i++){
            CharCube cube = Instantiate(charCubePrefab, Vector3.zero, Quaternion.identity, transform);
            cube.transform.localPosition = new Vector3(startxPos + i * 2, 0, 0);
            cube.Character = word[i];
        }
        if(word.Length > 10){
            float scale = 10f/word.Length;
            transform.localScale = new Vector3(scale,scale,scale);
            transform.position = new Vector3(0,5,10.1f);
        }
    }
}
