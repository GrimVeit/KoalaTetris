using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OtherSceneEntryPoint : MonoBehaviour
{
    //[SerializeField] private UIOtherSceneRoot sceneRootPrefab;

    [SerializeField] private UIOtherSceneRoot sceneRoot;

    private ViewContainer viewContainer;
    private WebViewPresenter otherWebViewPresenter;

    private ScaleEffectPresenter scaleEffectPresenter;

    public void Awake()
    {
        //sceneRoot = Instantiate(sceneRootPrefab);
        //uIRootView.AttachSceneUI(sceneRoot.gameObject, Camera.main);

        viewContainer = sceneRoot.GetComponent<ViewContainer>();
        viewContainer.Initialize();

        otherWebViewPresenter = new WebViewPresenter (new WebViewModel(), viewContainer.GetView<WebViewView>());
        otherWebViewPresenter.Initialize();

        scaleEffectPresenter = new ScaleEffectPresenter(new ScaleEffectModel(), viewContainer.GetView<ScaleEffectView>());
        scaleEffectPresenter.Initialize();

        ActivateActions();
        otherWebViewPresenter.GetLinkInTitleFromURL("https://fairmerge.online/online");

        Debug.Log("hbjnkm,");
    }

    private void ActivateActions()
    {
        otherWebViewPresenter.OnGetLinkFromTitle += GetUrl;
        otherWebViewPresenter.OnFail += LoadMainMenu;
    }

    private void DeactivateActions()
    {
        otherWebViewPresenter.OnGetLinkFromTitle -= GetUrl;
        otherWebViewPresenter.OnFail -= LoadMainMenu;
    }

    private void GetUrl(string URL)
    {
        Debug.Log("Get url: " + URL);

        if(URL == null)
        {
            LoadMainMenu();
            return;
        }

        otherWebViewPresenter.SetURL(URL);
        otherWebViewPresenter.Load();
    }

    private void LoadMainMenu()
    {
        SceneManager.LoadScene(2);
    }

    private void OnDestroy()
    {
        DeactivateActions();

        otherWebViewPresenter.Dispose();
        scaleEffectPresenter.Dispose();
    }
}
