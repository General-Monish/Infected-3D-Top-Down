using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    public event EventHandler OnKeysChanged;

    private List<KeyScript.KeyType> keyList;

    private void Awake()
    {
        keyList = new List<KeyScript.KeyType>();
    }

    public List<KeyScript.KeyType> GetKeyList()
    {
        return keyList;
    }

    public void AddKey(KeyScript.KeyType keyType)
    {
        Debug.Log("Added Key: " + keyType);
        keyList.Add(keyType);
        OnKeysChanged?.Invoke(this, EventArgs.Empty);
    }

    public void RemoveKey(KeyScript.KeyType keyType)
    {
        keyList.Remove(keyType);
        OnKeysChanged?.Invoke(this, EventArgs.Empty);
    }

    public bool ContainsKey(KeyScript.KeyType keyType)
    {
        return keyList.Contains(keyType);
    }


    private void OnTriggerEnter2D(Collider2D collider)
    {
        KeyScript key = collider.GetComponent<KeyScript>();
        if (key != null)
        {
            AddKey(key.GetKeyType());
            Destroy(key.gameObject);
        }

        KeyDoor keyDoor = collider.GetComponent<KeyDoor>();
        if (keyDoor != null)
        {
            if (ContainsKey(keyDoor.GetKeyType()))
            {
                // Currently holding Key to open this door
                RemoveKey(keyDoor.GetKeyType());
                Debug.Log("Door");
                SceneLoader.Load(SceneLoader.Scene.Game2);
                //keyDoor.OpenDoor();
            }
            else
            {
                keyDoor.PlayOpenFailAnim();
            }
        }
    }
}
