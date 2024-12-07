using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarsController : MonoBehaviour
{
    [SerializeField] private List<Car> cars = new List<Car>();

    private Car currentCar;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(currentCar != null)
            {
                currentCar.Move();
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            currentCar = cars[Random.Range(0, cars.Count)];
        }
    }
}
