using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FPSCounter : MonoBehaviour
{

    public string label = "";
    public float count;
    public Text fpsText;
    public GameObject fpsTextObject;
    public bool drawCounter;

    IEnumerator Start()
    {
        GUI.depth = 2;
        while (true)
        {
            if (Time.timeScale == 1)
            {
                yield return new WaitForSeconds(0.1f);
                count = (1 / Time.deltaTime);
                label = "FPS :" + (Mathf.Round(count));
            }
            else
            {
                label = "Pause";
            }
            yield return new WaitForSeconds(0.5f);
        }
    }

    void Update()
    {
        fpsText.text = count.ToString();

        if (drawCounter)
        {
            fpsTextObject.SetActive(true);
        } else if (!drawCounter)
        {
            fpsTextObject.SetActive(false);
        }

    }
}
