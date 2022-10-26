using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReplayManagerController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // create the instance at the beginning of the game
        SingletonPatternUnity instance = SingletonPatternUnity.Instance;
        instance.TestSingleton();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
