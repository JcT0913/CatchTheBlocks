using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareBlockObserved : BlocksClass
{
    public override void ReturnLog()
    {
        Debug.Log("Square Block Observed");
    }

    public override string ReturnClassName()
    {
        // return "SquareBlock";
        return this.className;
    }

    public override int ReturnScore()
    {
        return this.score;
    }

    public override int ReturnCostInLife()
    {
        return this.costInLife;
    }

    // Start is called before the first frame update
    void Start()
    {
        this.className = "SquareBlock";
        this.score = 3;
        this.costInLife = 0;
    }

    // Update is called once per frame
    void Update()
    {
        this.FallingDown();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Notify(this, BlocksType.SquareBlock);
            
            //this.gameObject.SetActive(false);
            this.ToNewPosition();
        }
    }
}
