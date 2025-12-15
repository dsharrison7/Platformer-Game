
using UnityEngine;

public class CanvasSwitcher : MonoBehaviour
{
    [Header("Assign Canvases")]
    public GameObject currentCanvas;  
    public GameObject targetCanvas;   

    public void SwitchCanvas()
    {
        if (currentCanvas != null)
            currentCanvas.SetActive(false);

        if (targetCanvas != null)
            targetCanvas.SetActive(true);
    }
}
