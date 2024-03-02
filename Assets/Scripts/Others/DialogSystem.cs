using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogSystem : MonoBehaviour
{
    [Header("UI组件")]
    public Image FaceImage;
    public Text TextLabel;
    [Header("文本组件")]
    public TextAsset TextFile;
    public int Index;

    List<string> TextList = new List<string>();
    void Awake()
    {
        GetTextFromFile(TextFile);
    }
    private void OnEnable()
    {
        TextLabel.text = TextList[Index];
        Index++;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && Index == TextList.Count)
        {
            gameObject.SetActive(false);
            Index = 0;
            Time.timeScale = 1;
            return;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            TextLabel.text = TextList[Index];
            Index++;
            if (Index == TextList.Count)
            {
                Index = 0;
            }
        }
    }
    void GetTextFromFile(TextAsset File)
    {
        TextList.Clear();
        Index = 0;


        var LineData = File.text.Split('\n');
        foreach (var line in LineData)
        {
            TextList.Add(line);
        }
    }
}
