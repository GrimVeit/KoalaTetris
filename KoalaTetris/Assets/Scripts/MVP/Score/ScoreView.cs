using DG.Tweening;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreView : View
{
    [SerializeField] private List<TextMeshProUGUI> textCurrentRecord;
    [SerializeField] private List<TextMeshProUGUI> textRecord;
    [SerializeField] private GameObject displayCurrentRecord;

    private Vector3 defaultDisplay10Size;

    public void Initialize()
    {
        defaultDisplay10Size = displayCurrentRecord.transform.localScale;
    }

    public void Dispose()
    {

    }

    public void DisplayRecord(int coins)
    {
        for (int i = 0; i < textRecord.Count; i++)
        {
            textRecord[i].text = coins.ToString();
        }
    }

    public void DisplayCurrentRecord(int coins)
    {
        for (int i = 0; i < textRecord.Count; i++)
        {
            textCurrentRecord[i].text = coins.ToString();
        }

        displayCurrentRecord.transform.DOScale(new Vector3(1.1f, 1.1f, 1.1f), 0.1f).
                    OnComplete(() => displayCurrentRecord.transform.DOScale(defaultDisplay10Size, 0.2f));
    }
}
