using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(WordController))]
public class WordSpawner : MonoBehaviour{
    [SerializeField] CharCube _charCubePrefab;
    WordController _wordController;

    CharCube[] _charCubes;

    void Awake(){
        _wordController = GetComponent<WordController>();
    }


    public void SpawnWord(string word){
        List<CharCube> cubes = new List<CharCube>();

        int startxPos = -(word.Length-1);
        for (int i = 0; i < word.Length; i++){
            CharCube cube = Instantiate(_charCubePrefab, Vector3.zero, Quaternion.identity, transform);
            cube.transform.localPosition = new Vector3(startxPos + i * 2, 0, 0);
            cube.Character = word[i];
            cubes.Add(cube);
        }

        if(word.Length > 10){
            float scale = 10f/word.Length;
            transform.localScale = new Vector3(scale,scale,scale);
            transform.position = new Vector3(0,5,10.1f);
        }
        _wordController.CharCubes = cubes.ToArray();
        _charCubes = cubes.ToArray();
    }

    public void DestroyWord(){
        foreach(CharCube i in _charCubes){
            Destroy(i.gameObject);
        }
        _charCubes = new CharCube[0];
    }
}
