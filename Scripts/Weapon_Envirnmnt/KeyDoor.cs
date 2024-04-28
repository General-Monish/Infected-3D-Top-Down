using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyDoor : MonoBehaviour
{
    [SerializeField] private KeyScript.KeyType keyType;

    //private DoorAnims doorAnims;
    private Animator anim;

    private void Awake()
    {
        //doorAnims = GetComponent<DoorAnims>();
        anim = GetComponent<Animator>();
    }

    public KeyScript.KeyType GetKeyType()
    {
        return keyType;
    }

    public void OpenDoor()
    {
        //doorAnims.OpenDoor();
        anim.SetTrigger("OPEN");

    }

    public void PlayOpenFailAnim()
    {
        //doorAnims.PlayOpenFailAnim();
    }
}
