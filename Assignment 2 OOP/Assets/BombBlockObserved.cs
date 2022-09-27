using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombBlockObserved : BlocksClass
{
    public override void returnLog()
    {
        Debug.Log("Bomb Block Observed");
    }

    public override string returnClassName()
    {
        return this.className;
    }

    public override int returnScore()
    {
        return this.score;
    }

    public override int returnCostInLife()
    {
        return this.costInLife;
    }

    // Start is called before the first frame update
    void Start()
    {
        this.className = "BombBlock";
        this.score = 0;
        this.costInLife = -1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Notify(this, BlocksType.BombBlock);
            this.gameObject.SetActive(false);
        }
    }
}
