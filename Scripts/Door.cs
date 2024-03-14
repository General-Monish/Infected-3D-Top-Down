/*using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    public string sceneToLoad;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && collision.GetComponent<P>().HasKey)
        {
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
*/