using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour, ObserverOfBlocks
{
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
            Debug.Log("A Square Block Caught");
        }
    }
}
