using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharCube : MonoBehaviour{
    public char Character{get{return _character;} set{ _character = value;} }
    public bool IsOpen{get; private set;}
    char _character;
    bool _rotationIsActive;

    void Update(){
        Rotation();
    }

    void GlowRed(){

    }
    void GlowGreen(){

    }

    public void Open(){
        IsOpen = true;
        _rotationIsActive = true;
        GlowGreen();
    }   

    void Rotation(){
        if(_rotationIsActive){
            transform.Rotate(0f, (180*Time.deltaTime)/2.5f, 0);
            if( transform.eulerAngles.y > 90){
                transform.rotation = Quaternion.Euler(new Vector3(0,180,0));
                _rotationIsActive = false;
            }
        }
    }


}
