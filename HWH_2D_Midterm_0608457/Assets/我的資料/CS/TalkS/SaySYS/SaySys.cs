using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SaySys : MonoBehaviour
{
    [Header("打字聲音")]
    public AudioSource wordSound;
    [Header("文字框")]
    public TextMeshProUGUI textlabel;
    [Header("圖片位置")]
    public Image faceImage1Pos;
    public Image faceImage2Pos;
    [Header("圖片")]
    public Sprite face01;
    public Sprite face02;
    [Header("文本")]
    public TextAsset textfile;
    [Header("下一個對話框")] 
    public GameObject Next;
    [Header("觀察用變數")] 
    public int index;
    public float textSpeed;
    public bool textFinished;

    List<string> textList = new List<string>();

    private void Awake()
    {
        
        GetTextFormFile(textfile);
        
    }
    private void OnEnable()
    {

        StartCoroutine(SetTestUI());
        textFinished = true; 
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z) && index == textList.Count)//最後一句
        {
            gameObject.SetActive(false);
            Next.SetActive(true);
            index = 0;
            return;
        }
        if (Input.GetKeyDown(KeyCode.Z ) && textFinished)//句子結束
        {

            StartCoroutine(SetTestUI());
        }
    }
    void GetTextFormFile(TextAsset file)
    {
        textList.Clear();
        index = 0;
        var linedata = file.text.Split('\n');
        foreach (var line in linedata)
        {
            textList.Add(line);
        }
    }

    IEnumerator SetTestUI()
    {
        textFinished = false;
        textlabel.text = "";
        if (textList[index].Contains("A"))//Image1
        {

            faceImage1Pos.sprite = face01;

            index++;
        }
        else if (textList[index].Contains("B"))//Image2
        {

            faceImage2Pos.sprite = face02;

            index++;
        }
        else if (textList[index].Contains("C"))//同時顯示兩張圖片
        {

            faceImage2Pos.sprite = face02;
            faceImage1Pos.sprite = face01;
            index++;
        }

        for (int i = 0; i < textList[index].Length; i++)
        {
            if (textList[index][i].ToString() != " ")
            {
                wordSound.Play();
            }
  
            textlabel.text += textList[index][i];
  
            if (textList[index][i].ToString() == "n")
            {
                
                print("ok");
                textlabel.text.Replace("/n"," ");
                index++;
                i = 0;
                textlabel.text += textList[index][i];
            }

            yield return new WaitForSeconds(textSpeed);
        }
        textFinished = true;
        index++;

    }

    IEnumerator dontStopinEnd()
    {
        
        yield break;
    }
}
