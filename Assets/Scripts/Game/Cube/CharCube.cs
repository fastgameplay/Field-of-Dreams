using UnityEngine;
[RequireComponent(typeof(GlowCube))]
[RequireComponent(typeof(TextCube))]
public class CharCube : MonoBehaviour{
    public char Character{
        set {
            _textCube.Character = _character = value; 
        }
        get{
            return _character;
        }
        
    }

    public bool IsOpen{get; private set;}
    
    char _character;
    GlowCube _glowCube;
    TextCube _textCube;
    bool _rotationIsActive;
    void Awake(){
        _glowCube = GetComponent<GlowCube>();
        _textCube = GetComponent<TextCube>();
    }

    void Update(){
        Rotation();
    }

    public void GlowRed(){
        _glowCube.Glow(Color.red);
    }
    public void GlowGreen(){
        _glowCube.Glow(Color.green);
    }
    public void Open(){
        IsOpen = true;
        _rotationIsActive = true;
        _textCube.Active = true;
        GlowGreen();
    }   

    void Rotation(){
        if(_rotationIsActive){
            transform.Rotate(0f, (180*Time.deltaTime)/2.5f, 0);
            if( transform.eulerAngles.y > 90){
                transform.rotation = Quaternion.Euler(new Vector3(0,90,0));
                _rotationIsActive = false;
            }
        }
    }


}
