using System;
using UnityEngine;

public class MainMenuEntryPoint : MonoBehaviour
{
    [SerializeField] private Sounds sounds;
    //[SerializeField] private UIMainMenuRoot menuRootPrefab;
    [SerializeField] private UIMainMenuRoot sceneRoot;
    private ViewContainer viewContainer;

    private ParticleEffectPresenter particleEffectPresenter;
    private SoundPresenter soundPresenter;
    private BankPresenter bankPresenter;

    private FakeItemMovePresenter fakeItemMovePresenter;

    public void Start()
    {
        //sceneRoot = Instantiate(menuRootPrefab);
 
        //uIRootView.AttachSceneUI(sceneRoot.gameObject, Camera.main);

        viewContainer = sceneRoot.GetComponent<ViewContainer>();
        viewContainer.Initialize();

        //soundPresenter = new SoundPresenter
        //            (new SoundModel(sounds.sounds, PlayerPrefsKeys.IS_MUTE_SOUNDS),
        //            viewContainer.GetView<SoundView>());
        //soundPresenter.Initialize();

        //particleEffectPresenter = new ParticleEffectPresenter
        //    (new ParticleEffectModel(),
        //    viewContainer.GetView<ParticleEffectView>());
        //particleEffectPresenter.Initialize();

        //bankPresenter = new BankPresenter(new BankModel(), viewContainer.GetView<BankView>());
        //bankPresenter.Initialize();

        fakeItemMovePresenter = new FakeItemMovePresenter(new FakeItemMoveModel(), viewContainer.GetView<FakeItemMoveView>());
        fakeItemMovePresenter.Initialize();

        sceneRoot.SetSoundProvider(soundPresenter);
        sceneRoot.SetParticleEffectProvider(particleEffectPresenter);
        sceneRoot.Initialize();

        ActivateTransitionsSceneEvents();
        ActivateEvents();

        sceneRoot.Activate();
        fakeItemMovePresenter.Activate();
    }

    private void ActivateTransitionsSceneEvents()
    {

    }

    private void DeactivateTransitionsSceneEvents()
    {

    }

    private void ActivateEvents()
    {

    }

    private void DeactivateEvents()
    {

    }

    private void Dispose()
    {
        DeactivateTransitionsSceneEvents();
        DeactivateEvents();
        sceneRoot.Deactivate();

        //sceneRoot?.Dispose();
        //particleEffectPresenter?.Dispose();
        //bankPresenter?.Dispose();
    }

    private void OnDestroy()
    {
        Dispose();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            fakeItemMovePresenter.Activate();
        }

        if (Input.GetKeyUp(KeyCode.X))
        {
            fakeItemMovePresenter.Deactivate();
        }
    }
}
