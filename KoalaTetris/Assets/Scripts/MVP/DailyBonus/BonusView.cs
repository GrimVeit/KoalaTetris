using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BonusView : View
{
    public event Action<float> OnSpin;
    public event Action OnEndSpin;
    public event Action OnClickSpinButton;
    public event Action<Transform, Bonus> OnGetBonus;

    [SerializeField] private List<Bonus> bonuses = new List<Bonus>();

    [SerializeField] private TextMeshProUGUI textCoins;
    [SerializeField] private Button buttonDailyBonus;
    [SerializeField] private Vector3 spinVector;
    [SerializeField] private Transform spinTransform;
    [SerializeField] private Transform centerPoint;
    [SerializeField] private float minSpinSpeed;
    [SerializeField] private float maxSpinSpeed;
    [SerializeField] private float minDuration;
    [SerializeField] private float maxDuration;
    [SerializeField] private Transform transformCenter;

    private IEnumerator rotateSpin_Coroutine;

    public void Initialize()
    {
        buttonDailyBonus.onClick.AddListener(HandlerClickToSpinButton);
    }

    public void Dispose()
    {
        buttonDailyBonus.onClick.RemoveListener(HandlerClickToSpinButton);
    }

    public void DeactivateSpinButton() 
    {
        buttonDailyBonus.gameObject.SetActive(false);
    }

    public void ActivateSpinButton()
    {
        buttonDailyBonus.gameObject.SetActive(true);
    }

    public void ClearResult()
    {
        textCoins.text = "";
    }

    public void DisplayDescription(string description)
    {
        textCoins.text = description;
    }


    public void StartSpin()
    {
        if (rotateSpin_Coroutine != null)
            Coroutines.Stop(rotateSpin_Coroutine);

        rotateSpin_Coroutine = RotateSpin_Coroutine();
        Coroutines.Start(rotateSpin_Coroutine);
    }

    private IEnumerator RotateSpin_Coroutine()
    {
        float elapsedTime = 0f;
        float startSpeed = UnityEngine.Random.Range(minSpinSpeed, maxSpinSpeed);
        float duration = UnityEngine.Random.Range(minDuration, maxDuration);
        float endSpeed = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float currentSpeed = Mathf.Lerp(startSpeed, endSpeed, elapsedTime / duration);
            Debug.Log(currentSpeed);
            OnSpin?.Invoke(currentSpeed);

            //scrollRect.verticalNormalizedPosition += currentSpeed * Time.deltaTime;
            //scrollRect.verticalNormalizedPosition = scrollRect.verticalNormalizedPosition % 1; // Зацикливание

            spinTransform.Rotate(spinVector * currentSpeed * Time.deltaTime);

            yield return null;
        }

        Bonus bonus = GetClosestBonus();
        Debug.Log(bonus.Value);
        OnGetBonus?.Invoke(transformCenter, bonus);
        OnEndSpin?.Invoke();
    }

    private Bonus GetClosestBonus()
    {
        float minDistance = float.MaxValue;
        Bonus closestBonus = null;


        foreach (var bonus in bonuses)
        {
            float distance = Vector2.Distance(bonus.TransformBonus.position, centerPoint.position);

            if (distance < minDistance)
            {
                minDistance = distance;
                closestBonus = bonus;
            }
        }


        return closestBonus;
    }

    private void HandlerClickToSpinButton()
    {
        OnClickSpinButton?.Invoke();
    }
}
