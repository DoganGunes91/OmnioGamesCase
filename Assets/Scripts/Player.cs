using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Player : MonoBehaviour
{
    [SerializeField] private Camera _camera;

    [SerializeField] private GameObject[] numbers;

    [SerializeField] private float _speed;

    private bool _isGameStarter;    

    void Start()
    {
        DOTween.Init();

        numbers[Random.Range(0, numbers.Length)].SetActive(true);

        _isGameStarter = false;
    }
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            _isGameStarter = true;

            if (_isGameStarter)
            {
                Movement();                
            }
        }
        else
        {
            _isGameStarter = false;
            ComeBack();            
        }
    }

    void Movement()
    {
        transform.Translate(Vector3.forward * _speed * 2f * Time.deltaTime);
        _camera.DOFieldOfView(80, 1);
        transform.DOMoveX(-1, 1);
    }

    void ComeBack()
    {
        transform.Translate(Vector3.forward * _speed * Time.deltaTime);
        transform.DOMoveX(1, 1);
        _camera.DOFieldOfView(60, 1);
    }    
}
