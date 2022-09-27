using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour, ObserverOfBlocks
{
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.DeleteAll();

        audioSource = GetComponent<AudioSource>();

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
            audioSource.Play();
        }

        if (blocksType == BlocksType.CapsuleBlock)
        {
            Debug.Log("A Capsule Block Caught");
            audioSource.Play();
        }

        if (blocksType == BlocksType.DiamondBlock)
        {
            Debug.Log("A Diamond Block Caught");
            audioSource.Play();
        }

        if (blocksType == BlocksType.BombBlock)
        {
            Debug.Log("A Bomb Block Caught");
            audioSource.Play();
        }
    }
}
