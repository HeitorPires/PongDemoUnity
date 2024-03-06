using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveController : MonoBehaviour
{
    private string _savedWinnerKey = "SavedWinner";
    private static SaveController _instance;

    public Color colorPlayer = Color.white;
    public Color colorEnemy = Color.white;
    public string namePlayer;
    public string nameEnemy;
    public static SaveController Instance
    {
        get
        {
            if (_instance == null)
            {
                //Procura a instancia na cena
                _instance = FindObjectOfType<SaveController>();

                if(_instance == null )
                {
                    GameObject singletonObject = new GameObject(typeof(SaveController).Name);
                    _instance = singletonObject.AddComponent<SaveController>();
                }
            }
            return _instance;
        }
    }


    private void Awake()
    {
        if(_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        DontDestroyOnLoad(this.gameObject);
    }

    public string GetName(bool isPlayer)
    {
        return isPlayer ? namePlayer : nameEnemy;
    }

    public void SaveWinner(string winner)
    {
        PlayerPrefs.SetString(_savedWinnerKey, winner);
    }

    public string GetLastWinner()
    {
        return PlayerPrefs.GetString(_savedWinnerKey);
    }

    public void Reset()
    {
        colorPlayer = Color.white;
        colorEnemy = Color.white;
        namePlayer = "";
        nameEnemy = "";
    }

    public void ClearSave()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
