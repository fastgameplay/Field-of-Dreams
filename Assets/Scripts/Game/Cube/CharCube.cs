using UnityEngine;
[RequireComponent(typeof(GlowCube))]
public class CharCube : MonoBehaviour{
    public char Character{get;set;}
    public bool IsOpen{get; private set;}
    GlowCube glowCube;
    bool _rotationIsActive;
    void Awake(){
        glowCube = GetComponent<GlowCube>();
    }

    void Update(){
        Rotation();
    }

    void GlowRed(){

    }

    public void Open(){
        IsOpen = true;
        _rotationIsActive = true;
        glowCube.Glow(Color.green);
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
