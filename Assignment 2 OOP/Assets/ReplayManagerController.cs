using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReplayManagerController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //TestSingleton();

        // create the instance at the beginning of the game
        SingletonPatternUnity instance = SingletonPatternUnity.Instance;
        instance.TestSingleton();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void TestSingleton()
    {
        SingletonPatternUnity instance1 = SingletonPatternUnity.Instance;
        instance1.TestSingleton();

        SingletonPatternUnity instance2 = SingletonPatternUnity.Instance;
        instance2.TestSingleton();

        SingletonPatternUnity instance3 = SingletonPatternUnity.Instance;
        instance3.TestSingleton();
    }
}
