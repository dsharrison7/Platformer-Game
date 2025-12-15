
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class NextLevelButton : MonoBehaviour
{
    [Header("Level Info")]
    public int levelNumber = 1;       
    public string nextSceneName = ""; 

    [Header("UI")]
    public TextMeshProUGUI messageText;  
    public float waitSeconds = 3f;       

    private bool _triggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (_triggered) return;
        if (!other.CompareTag("Player")) return;

        _triggered = true;

        
        if (messageText != null)
        {
            messageText.gameObject.SetActive(true);
            messageText.text = $"Level {levelNumber} completed";
        }

        
        Collider col = GetComponent<Collider>();
        if (col) col.enabled = false;

        
        StartCoroutine(WaitAndLoadNext());
    }

    private System.Collections.IEnumerator WaitAndLoadNext()
    {
        yield return new WaitForSeconds(waitSeconds);

        if (!string.IsNullOrEmpty(nextSceneName))
        {
            SceneManager.LoadScene(nextSceneName);
        }
        else
        {
            int nextIndex = SceneManager.GetActiveScene().buildIndex + 1;
            SceneManager.LoadScene(nextIndex);
        }
    }
}
