using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Collision : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _winPanel;
    [SerializeField] private GameObject _lostPanel;
    [SerializeField] private GameObject _gameBar;
    [SerializeField] private int _chunkPoolSize;    

    public Image _fillAmount;    

    private Animator _animator;    

    void Start()
    {
        _animator = GetComponent<Animator>();        
    }
    void Update()
    {
        GameBar();
    }
    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            _player.GetComponent<CapsuleCollider>().enabled = false;
            _player.GetComponent<Animator>().enabled = false;
            _player.GetComponent<Player>().enabled = false;
            Lost();
        }

        if (collision.gameObject.tag == "WinTarget")
        {
            int winNumber = Random.Range(0, 1);

            if (winNumber == 0)
            {
                _animator.SetBool("win1", true);
                _player.GetComponent<Player>().enabled = false;
                Win();
            }
            if (winNumber == 1)
            {
                _animator.SetBool("win2", true);
                _player.GetComponent<Player>().enabled = false;
                Win();
            }
        }
    }
    private void Win()
    {
        _winPanel.SetActive(true);
        _gameBar.SetActive(false);
    }

    private void Lost()
    {
        _lostPanel.SetActive(true);
        _gameBar.SetActive(false);
    }

    private void GameBar()
    {
        _fillAmount.fillAmount = (float) _player.transform.position.z / (10 * _chunkPoolSize);
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
        _winPanel.SetActive(false);
        _lostPanel.SetActive(false);
        _gameBar.SetActive(true);
    }
}
