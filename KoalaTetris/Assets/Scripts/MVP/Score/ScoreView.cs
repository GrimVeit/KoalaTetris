using DG.Tweening;
using TMPro;
using UnityEngine;

public class ScoreView : View
{
    [SerializeField] private TextMeshProUGUI textCurrentRecord;
    [SerializeField] private TextMeshProUGUI textRecord;
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
        textRecord.text = coins.ToString();
    }

    public void DisplayCurrentRecord(int coins)
    {
        textCurrentRecord.text = coins.ToString();

        displayCurrentRecord.transform.DOScale(new Vector3(1.1f, 1.1f, 1.1f), 0.1f).
                    OnComplete(() => displayCurrentRecord.transform.DOScale(defaultDisplay10Size, 0.2f));
    }
}
