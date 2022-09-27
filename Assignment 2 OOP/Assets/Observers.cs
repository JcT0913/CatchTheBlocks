using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ObserverOfBlocks
{
    void OnNotify(BlocksClass blocksClass, BlocksType blocksType);
}

public enum BlocksType
{
    SquareBlock,
    CapsuleBlock,
    DiamondBlock,
    BombBlock
}
