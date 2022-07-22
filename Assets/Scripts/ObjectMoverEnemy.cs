using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMoverEnemy : MonoBehaviour
{
    [SerializeField] private GameObject[] numbers;

    private float _speed = 7f;

    void Start()
    {
        numbers[Random.Range(0, numbers.Length)].SetActive(true);
        transform.Rotate(0, 180, 0);
    }
    void Update()
    {
        transform.Translate(Vector3.forward * (Time.deltaTime * _speed));
    }
}
