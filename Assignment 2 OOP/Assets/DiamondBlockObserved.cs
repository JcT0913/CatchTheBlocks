using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamondBlockObserved : BlocksClass
{
    public override void ReturnLog()
    {
        Debug.Log("Diamond Block Observed");
    }

    public override string ReturnClassName()
    {
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
        this.className = "DiamondBlock";
        this.score = 4;
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
            Notify(this, BlocksType.DiamondBlock);

            //this.gameObject.SetActive(false);
            this.ToNewPosition();
        }
    }
}
