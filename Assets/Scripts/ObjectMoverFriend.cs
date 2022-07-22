using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMoverFriend : MonoBehaviour
{
    [SerializeField] private GameObject[] numbers;

    float _speed = 7f;

    void Start()
    {
        numbers[Random.Range(0, numbers.Length)].SetActive(true);
    }
    void Update()
    {
        transform.Translate(Vector3.forward * (Time.deltaTime * _speed));
    }
}
