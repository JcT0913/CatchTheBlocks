using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SingletonPatternUnity : MonoBehaviour
{
    private static SingletonPatternUnity instance = null;
    private float randomNumber;

    private Vector3 savedPlayerPosition;
    private int savedRemainedLife;
    private int savedSquareCollected;
    private int savedCapsuleCollected;
    private int savedDiamondCollected;
    private int savedBombCollected;

    public static SingletonPatternUnity Instance
    {
        get
        {
            if (instance == null)
            {
                var instance = GameObject.FindObjectOfType<SingletonPatternUnity>();

                if (instance == null)
                {
                    GameObject obj = new GameObject("Unity Singleton");
                    instance = obj.AddComponent<SingletonPatternUnity>();

                    instance.FakeConstructor();

                    DontDestroyOnLoad(obj);
                }
            }
            return instance;
        }
    }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;

            instance.FakeConstructor();

            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    //Because this script inherits from MonoBehaviour, we cant use a constructor, so we have to invent our own
    private void FakeConstructor()
    {
        this.randomNumber = Random.Range(0f, 1f);
        this.savedPlayerPosition = new Vector3(0, -4, 0);
        
    }

    //For testing
    public void TestSingleton()
    {
        Debug.Log($"Hello this is Singleton, my random number is: {randomNumber}");
    }

    public void UpdateSavedPlayerPosition(Vector3 newPlayerPosition)
    {
        this.savedPlayerPosition = newPlayerPosition;
    }

    public void UpdateSavedRemainedLife(int newRemainedLife)
    {
        this.savedRemainedLife = newRemainedLife;
    }

    public Vector3 ReturnSavedPlayerPosition()
    {
        Debug.Log("saved player position: " + this.savedPlayerPosition.ToString());
        return this.savedPlayerPosition;
    }

    public int ReturnSavedRemainedLife()
    {
        Debug.Log("saved remained life: " + this.savedRemainedLife.ToString());
        return this.savedRemainedLife;
    }

    public int ReturnSavedSquareCollected()
    {
        Debug.Log("saved squares: " + this.savedSquareCollected.ToString());
        return this.savedSquareCollected;
    }

    public int ReturnSavedCapsuleCollected()
    {
        Debug.Log("saved capsules: " + this.savedCapsuleCollected.ToString());
        return this.savedCapsuleCollected;
    }

    public int ReturnSavedDiamondCollected()
    {
        Debug.Log("saved diamonds: " + this.savedDiamondCollected.ToString());
        return this.savedDiamondCollected;
    }

    public int ReturnSavedBombCollected()
    {
        Debug.Log("saved bombs: " + this.savedBombCollected.ToString());
        return this.savedBombCollected;
    }
}

