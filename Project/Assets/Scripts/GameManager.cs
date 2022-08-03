using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }
    public int enemiesCount;

    [SerializeField] private GameObject enemies;
    [SerializeField] private GameObject WinPanel;


    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        enemiesCount = enemies.transform.childCount;
    }

    private void Update()
    {
        if(enemiesCount <= 0)
        {
            WinPanel.SetActive(true);
        }
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
