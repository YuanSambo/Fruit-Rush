
using System;
using System.Collections;
using ScriptableObjectArchitecture;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private bool _isStarted;
    
    private GameObject _transition;
    private Animator _transitionAnimator;
    private int currentScene;


    #region FruitTimer

    [Header("FruityBar")] public FloatVariable FruityBar;
    public float FruitBarTime;
    public bool Reset;

    #endregion
    
    #region Respawn
    private Player _player;

    

    #endregion
  
    
    private void Awake()
    {
        currentScene = SceneManager.GetActiveScene().buildIndex;
        _transition = GameObject.Find("Transition");
        _transitionAnimator = _transition.GetComponent<Animator>();
        _player = GameObject.Find("Player").GetComponent<Player>();
        if (Instance == null)
        {
            Instance = this;
        }

        if (Reset)
        {
            FruityBar.Value = FruitBarTime;
        }

    }


    private void Start()
    {
        StartCoroutine(StartGame());
        SoundManager.Instance.Play("Background");
    }

    private void Update()
    {
       
        if (_isStarted)
        {
            if (FruityBar.Value <= 0 && _player != null)
            {
                _player.Death();
                _player = null;

            }
            else if ( _player != null)
            {
                FruityBar.Value -= Time.deltaTime;
            }
        }
       
    }
    
    private IEnumerator StartGame()
    {
        _transitionAnimator.SetTrigger("Ease In");
        yield return new WaitForSeconds(1f);
        _isStarted = true;
    }

    public IEnumerator ChangeScene()
    {    
        _transitionAnimator.SetTrigger("Ease Out");
        yield return new WaitForSeconds(0.9f);
        SceneManager.LoadScene(currentScene+1);    
    }

    public IEnumerator PlayAgain()
    {
        _transitionAnimator.SetTrigger("Ease Out");
        yield return new WaitForSeconds(0.9f);
        SceneManager.LoadScene(1);    
    }

    public IEnumerator MainMenu()
    {
        _transitionAnimator.SetTrigger("Ease Out");
        yield return new WaitForSeconds(0.9f);
        SceneManager.LoadScene(0);    

    }
    
    
    public void PauseTimer()
    {
        _isStarted = false;
    }
}