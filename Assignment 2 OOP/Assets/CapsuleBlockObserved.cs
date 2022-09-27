using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleBlockObserved : BlocksClass
{
    public override void returnLog()
    {
        Debug.Log("Capsule Block Observed");
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
        this.className = "CapsuleBlock";
        this.score = 2;
        this.costInLife = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Notify(this, BlocksType.CapsuleBlock);
            this.gameObject.SetActive(false);
        }
    }
}
