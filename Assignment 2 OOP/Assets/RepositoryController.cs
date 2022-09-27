using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepositoryController : MonoBehaviour, ObserverOfBlocks
{
    private Dictionary<string, List<BlocksClass>> repository = new Dictionary<string, List<BlocksClass>>();

    public void AddElement(string key, BlocksClass block)
    {
        List<BlocksClass> list;
        if (repository.ContainsKey(key))
        {
            repository.TryGetValue(key, out list);
            list.Add(block);
            repository.Remove(key);
            repository.Add(key, list);
        }
        else
        {
            list = new List<BlocksClass>();
            list.Add(block);
            repository.Add(key, list);
        }
    }

    public void RemoveElement(string key, BlocksClass block)
    {
        List<BlocksClass> list;
        if (repository.ContainsKey(key))
        {
            repository.TryGetValue(key, out list);
            list.Remove(block);
            repository.Add(key, list);
        }
        else
        {
            Debug.Log("Don't contain this key");
        }
    } 

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.DeleteAll();

        foreach (BlocksClass block in FindObjectsOfType<BlocksClass>())
        {
            block.AddObserverOfBlocks(this);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void OnNotify(BlocksClass blocksClass, BlocksType blocksType)
    {
        if (blocksType == BlocksType.SquareBlock)
        {
            //Debug.Log("className: " + blocksClass.returnClassName());
            //Debug.Log("Score: " + blocksClass.returnScore().ToString());
            //Debug.Log("costInLife: " + blocksClass.returnCostInLife().ToString());

            AddElement(blocksClass.returnClassName(), blocksClass);

            //List<BlocksClass> list;
            //string key = blocksClass.returnClassName();
            //repository.TryGetValue(key, out list);
            //Debug.Log("key-value pairs: " + repository.Count.ToString());
            //Debug.Log("length of key " + key + " 's list: " + list.Count.ToString());
        }

        if (blocksType == BlocksType.CapsuleBlock)
        {
            AddElement(blocksClass.returnClassName(), blocksClass);

            //List<BlocksClass> list;
            //string key = blocksClass.returnClassName();
            //repository.TryGetValue(key, out list);
            //Debug.Log("key-value pairs: " + repository.Count.ToString());
            //Debug.Log("length of key " + key + " 's list: " + list.Count.ToString());
        }

        if (blocksType == BlocksType.DiamondBlock)
        {
            AddElement(blocksClass.returnClassName(), blocksClass);

            //List<BlocksClass> list;
            //string key = blocksClass.returnClassName();
            //repository.TryGetValue(key, out list);
            //Debug.Log("key-value pairs: " + repository.Count.ToString());
            //Debug.Log("length of key " + key + " 's list: " + list.Count.ToString());
        }

        if (blocksType == BlocksType.BombBlock)
        {
            AddElement(blocksClass.returnClassName(), blocksClass);

            //List<BlocksClass> list;
            //string key = blocksClass.returnClassName();
            //repository.TryGetValue(key, out list);
            //Debug.Log("key-value pairs: " + repository.Count.ToString());
            //Debug.Log("length of key " + key + " 's list: " + list.Count.ToString());
        }
    }
}
