using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextCube : MonoBehaviour
{
    [SerializeField] TextMesh _text;
    public bool Active {set { _text.gameObject.SetActive(value);}}
    public char Character {set {_text.text = value.ToString();}}
}
