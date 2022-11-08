using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharCube : MonoBehaviour{
    public char Character{get{return _character;} set{ _character = value;} }

    char _character;
}
