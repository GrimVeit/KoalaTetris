using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CountryCheckerSceneEntryPoint : MonoBehaviour
{
    [SerializeField] private UICountryCheckerSceneRoot sceneRoot;
    private ViewContainer viewContainer;

    private GeoLocationPresenter geoLocationPresenter;
    private InternetPresenter internetPresenter;

    private ScaleEffectPresenter scaleEffectPresenter;

    public void Awake()
    {
        //sceneRoot = Instantiate(sceneRootPrefab);
        //uIRootView.AttachSceneUI(sceneRoot.gameObject, Camera.main);

        viewContainer = sceneRoot.GetComponent<ViewContainer>();
        viewContainer.Initialize();

        geoLocationPresenter = new GeoLocationPresenter(new GeoLocationModel());

        internetPresenter = new InternetPresenter(new InternetModel(), viewContainer.GetView<InternetView>());
        internetPresenter.Initialize();

        scaleEffectPresenter = new ScaleEffectPresenter(new ScaleEffectModel(), viewContainer.GetView<ScaleEffectView>());
        scaleEffectPresenter.Initialize();

        ActivateActions();

        internetPresenter.StartCkeckInternet();

    }

    public void Dispose()
    {
        DeactivateActions();

        internetPresenter?.Dispose();
        scaleEffectPresenter?.Dispose();
    }

    private void ActivateActions()
    {
        internetPresenter.OnInternetAvailable += geoLocationPresenter.GetUserCountry;
        internetPresenter.OnInternetUnavailable += TransitionToMainMenu;
        geoLocationPresenter.OnGetCountry += ActivateSceneInCountry;
    }

    private void DeactivateActions()
    {
        internetPresenter.OnInternetAvailable -= geoLocationPresenter.GetUserCountry;
        internetPresenter.OnInternetUnavailable -= TransitionToMainMenu;
        geoLocationPresenter.OnGetCountry -= ActivateSceneInCountry;
    }

    private void ActivateSceneInCountry(string country)
    {
        switch (country)
        {
            case "AU":
                TransitionToOther();
                break;
            default:
                TransitionToMainMenu();
                break;
        }
    }

    private void TransitionToMainMenu()
    {
        Dispose();

        SceneManager.LoadScene(2);
    }

    private void TransitionToOther()
    {
        Dispose();

        SceneManager.LoadScene(1);

        
    }
}
