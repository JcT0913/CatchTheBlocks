using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BlocksClass : MonoBehaviour
{
    protected string className;
    protected int score;
    protected int costInLife;
    protected float fallSpeed = 1f;

    private List<ObserverOfBlocks> _observerOfBlocks = new List<ObserverOfBlocks>();

    public abstract void ReturnLog();
    public abstract string ReturnClassName();
    public abstract int ReturnScore();
    public abstract int ReturnCostInLife();

    public void FallingDown()
    {
        // this.fallSpeed += Time.deltaTime / 400;
        //transform.position = new Vector3(transform.position.x, transform.position.y - fallSpeed / 75, transform.position.z);

        //if (this.transform.position.y <= -6.5f)
        //{
        //    this.ToNewPosition();
        //}
    }

    public void ToNewPosition()
    {
        float posX = Random.Range(-8.4f, 8.4f);
        float posY = Random.Range(6.5f, 20f);
        transform.position = new Vector3(posX, posY, transform.position.z);
    }

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
