using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor.SceneManagement;
using TMPro;

public class GameplayUIController : MonoBehaviour, ObserverOfRepository
{
    public TextMeshProUGUI pointsText;
    public TextMeshProUGUI remainedLifeText;
    public TextMeshProUGUI squareCollectedText;
    public TextMeshProUGUI capsuleCollectedText;
    public TextMeshProUGUI diamondCollectedText;
    public TextMeshProUGUI bombCollectedText;
    public GameObject gameplayBackground;
    public GameObject gameoverBackground;

    private int points = 0;
    private int remainedLife = 5;
    private int squareCollected = 0;
    private int capsuleCollected = 0;
    private int diamondCollected = 0;
    private int bombCollected = 0;
    private bool quickSaved = false;

    // singleton pattern only have one static instance, initiated at the beginning in ReplayManagerController.cs,
    // write this line for updating the variables inside
    SingletonPatternUnity instance;

    // Start is called before the first frame update
    void Start()
    {
        gameplayBackground.SetActive(true);
        gameoverBackground.SetActive(false);
        Time.timeScale = 1;

        PlayerPrefs.DeleteAll();

        foreach (RepositoryController dict in FindObjectsOfType<RepositoryController>())
        {
            dict.AddObserverOfRepository(this);
        }

        pointsText.text = points.ToString() + " Points";
        remainedLifeText.text = "Remained Life: " + remainedLife.ToString();
        squareCollectedText.text = "Square: " + squareCollected.ToString();
        capsuleCollectedText.text = "Capsule: " + capsuleCollected.ToString();
        diamondCollectedText.text = "Diamond: " + diamondCollected.ToString();
        bombCollectedText.text = "Bomb: " + bombCollected.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (remainedLife <= 0)
        {
            Time.timeScale = 0;
            gameplayBackground.SetActive(false);
            gameoverBackground.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            quickSaved = true;
            Debug.Log("UI Information Quick Saved");
            instance = SingletonPatternUnity.Instance;
            instance.UpdateSavedRemainedLife(this.remainedLife);
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            if (quickSaved == true)
            {
                Debug.Log("UI Information Quick Loaded");
                instance.TestSingleton();

                this.remainedLife = instance.ReturnSavedRemainedLife();
                Debug.Log("remained life now: " + this.remainedLife);

                pointsText.text = points.ToString() + " Points";
                remainedLifeText.text = "Remained Life: " + remainedLife.ToString();
                squareCollectedText.text = "Square: " + squareCollected.ToString();
                capsuleCollectedText.text = "Capsule: " + capsuleCollected.ToString();
                diamondCollectedText.text = "Diamond: " + diamondCollected.ToString();
                bombCollectedText.text = "Bomb: " + bombCollected.ToString();
            }
            else
            {
                Debug.Log("Error. You don't have a quick save data.");
            }
        }
    }

    public void ReturnButton()
    {
        Debug.Log("Return Button Pressed");
        EditorSceneManager.LoadScene(0);
    }

    public void NewTryButton()
    {
        Debug.Log("New Try Button Pressed");
        EditorSceneManager.LoadScene(1);
    }

    public void MainMenuButton()
    {
        Debug.Log("Main Menu Button Pressed");
        EditorSceneManager.LoadScene(0);
    }

    public void OnNotify(RepositoryController repository, BlocksType blocksType)
    {
        List<BlocksClass> list;

        if (blocksType == BlocksType.SquareBlock)
        {
            string key = "SquareBlock";
            repository.returnRepository().TryGetValue(key, out list);
            squareCollectedText.text = "Square: " + list.Count.ToString();

            points += 3;
        }

        if (blocksType == BlocksType.CapsuleBlock)
        {
            string key = "CapsuleBlock";
            repository.returnRepository().TryGetValue(key, out list);
            capsuleCollectedText.text = "Capsule: " + list.Count.ToString();

            points += 2;
        }

        if (blocksType == BlocksType.DiamondBlock)
        {
            string key = "DiamondBlock";
            repository.returnRepository().TryGetValue(key, out list);
            diamondCollectedText.text = "Diamond: " + list.Count.ToString();

            points += 4;
        }

        if (blocksType == BlocksType.BombBlock)
        {
            string key = "BombBlock";
            repository.returnRepository().TryGetValue(key, out list);
            bombCollectedText.text = "Bomb: " + list.Count.ToString();

            remainedLife -= 1;
        }

        pointsText.text = points.ToString() + " Points";
        remainedLifeText.text = "Remained Life: " + remainedLife.ToString();
    }
}
