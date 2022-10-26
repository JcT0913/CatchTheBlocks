using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float playerSpeed = 10;

    private CharacterController characterController;
    private bool quickSaved = false;

    // singleton pattern only have one static instance, initiated at the beginning in ReplayManagerController.cs,
    // write this line for updating the variables inside
    SingletonPatternUnity instance;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        // Vector3 move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        characterController.Move(move * Time.deltaTime * playerSpeed);

        if (Input.GetKeyDown(KeyCode.O))
        {
            quickSaved = true;
            Debug.Log("Player Information Quick Saved");
            instance = SingletonPatternUnity.Instance;
            instance.UpdateSavedPlayerPosition(this.transform.position);
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            if (quickSaved == true)
            {
                Debug.Log("Player Information Quick Loaded");
                instance.TestSingleton();

                // CharacterController seems override transform.position
                // using disabled > set > enabled to avoid delay in changing position
                characterController.enabled = false;
                this.transform.position = instance.ReturnSavedPlayerPosition();
                characterController.enabled = true;
            }
            else
            {
                Debug.Log("Error. You don't have a quick save data.");
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        /*
        if (other.gameObject.tag == "Block")
        {
            Debug.Log("Block caught");
            other.gameObject.SetActive(false);
        }
        */
    }
}
