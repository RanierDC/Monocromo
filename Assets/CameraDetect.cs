using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraDetect : MonoBehaviour
{
    [SerializeField]private Transform CameraPos;
    private InimigoFov _fov;
    [SerializeField] Light _light;
    [SerializeField] Color _colorActivated;
    [SerializeField] Color _colorDeactivated;
    private bool isRotating;
    // Start is called before the first frame update
    void Start()
    {
        _fov = GetComponent<InimigoFov>();
        isRotating = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(_fov.canSeePlayer){
            _light.DOColor(_colorActivated,.5f);
            isRotating = true;
        }
        else{
            _light.DOColor(_colorDeactivated,.5f);
            
            if(isRotating){
                isRotating = false;
                CameraPos.DORotate(new Vector3(0,-50f,0),8f).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutBack);
            }
        }
    }
}
