using System.Collections;
using UnityEngine;

public class GlowCube : MonoBehaviour{
    [SerializeField] Color _standartColor;
    [SerializeField] float _smoothness;
    [SerializeField] float _glowDuration;

    private Color _color{ get{return GetComponent<Renderer>().material.color;} set{GetComponent<Renderer>().material.color = value;} }

    
    void Start(){
        _color = _standartColor;
    }


    public void Glow(Color color){
        StopAllCoroutines();

        StartCoroutine(LerpColor(color));
    }
    void GlowOut(){
        StopAllCoroutines();
        StartCoroutine(LerpColor(_standartColor));
    }
    IEnumerator LerpColor(Color inputColor)
    {
        Color currentColor = _color;
        float progress = 0;
        float increment = _smoothness/_glowDuration;
        while(progress < 1)
        {
            _color = Color.Lerp(currentColor, inputColor, progress);
            progress += increment;
            yield return new WaitForSeconds(_smoothness);
        }
        GlowOut();
    }
}
