
using UnityEngine;

public class PickUpFlashlight : UnityEngine.MonoBehaviour
{


    public UnityEngine.GameObject KeysOnPlayer;

    void Start()
    {
        KeysOnPlayer.SetActive(false);

    }

    private void OnTriggerStay(UnityEngine.Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (Input.GetKey(KeyCode.R)) 
            {
                this.gameObject.SetActive(false);

                KeysOnPlayer.SetActive(true);

            }
        }

    }
}
