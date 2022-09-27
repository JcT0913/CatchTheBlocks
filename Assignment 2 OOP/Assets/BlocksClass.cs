using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BlocksClass : MonoBehaviour
{
    protected string className;
    public int score;
    public int costInLife;

    private List<ObserverOfBlocks> _observerOfBlocks = new List<ObserverOfBlocks>();

    public abstract void returnLog();
    public abstract string returnClassName();

    public void AddObserverOfBlocks(ObserverOfBlocks observer)
    {
        _observerOfBlocks.Add(observer);
    }

    public void RemoveObserverOfBlocks(ObserverOfBlocks observer)
    {
        _observerOfBlocks.Remove(observer);
    }

    public void Notify(BlocksClass blocksClass, BlocksType blocksType)
    {
        foreach (ObserverOfBlocks observer in _observerOfBlocks)
        {
            observer.OnNotify(blocksClass, blocksType);
        }
    }

    /*
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    */
}
