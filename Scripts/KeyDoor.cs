using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyDoor : MonoBehaviour
{
    [SerializeField] private KeyScript.KeyType keyType;

    //private DoorAnims doorAnims;

    private void Awake()
    {
        //doorAnims = GetComponent<DoorAnims>();
    }

    public KeyScript.KeyType GetKeyType()
    {
        return keyType;
    }

    public void OpenDoor()
    {
        //doorAnims.OpenDoor();
    }

    public void PlayOpenFailAnim()
    {
        //doorAnims.PlayOpenFailAnim();
    }
}
