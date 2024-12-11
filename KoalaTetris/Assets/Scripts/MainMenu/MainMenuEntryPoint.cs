using System;
using UnityEngine;

public class MainMenuEntryPoint : MonoBehaviour
{
    [SerializeField] private Sounds sounds;
    [SerializeField] private ItemDatas itemDatas;
    [SerializeField] private Items items;
    [SerializeField] private UIMainMenuRoot sceneRoot;
    private ViewContainer viewContainer;

    private ParticleEffectPresenter particleEffectPresenter;
    private SoundPresenter soundPresenter;
    private BankPresenter bankPresenter;

    private FakeItemMovePresenter fakeItemMovePresenter;
    private ItemCatalogPresenter itemCatalogPresenter;
    private ItemSpawnerPresenter itemSpawnerPresenter;

    private ItemsPresenter itemsPresenter;
    private ScorePresenter scorePresenter;

    private TriggerZonesPresenter triggerZonesPresenter;
    private ScaleEffectPresenter scaleEffectPresenter;

    private GlobalMachineState machineState;

    private AdaptiveScreenPresenter adaptiveScreenPresenter;

    public void Awake()
    {
        viewContainer = sceneRoot.GetComponent<ViewContainer>();
        viewContainer.Initialize();

        soundPresenter = new SoundPresenter
                    (new SoundModel(sounds.sounds, sounds.randomSounds, PlayerPrefsKeys.IS_MUTE_SOUNDS),
                    viewContainer.GetView<SoundView>());
        soundPresenter.Initialize();

        particleEffectPresenter = new ParticleEffectPresenter(new ParticleEffectModel(), viewContainer.GetView<ParticleEffectView>());
        particleEffectPresenter.Initialize();

        fakeItemMovePresenter = new FakeItemMovePresenter(new FakeItemMoveModel(soundPresenter), viewContainer.GetView<FakeItemMoveView>());
        fakeItemMovePresenter.Initialize();

        itemCatalogPresenter = new ItemCatalogPresenter(new ItemCatalogModel(itemDatas), viewContainer.GetView<ItemCatalogView>());
        itemCatalogPresenter.Initialize();

        itemSpawnerPresenter = new ItemSpawnerPresenter(new ItemSpawnerModel(items), viewContainer.GetView<ItemSpawnerView>());
        itemSpawnerPresenter.Initialize();

        itemsPresenter = new ItemsPresenter(new ItemsModel(12, particleEffectPresenter, soundPresenter));
        itemsPresenter.Initialize();

        scorePresenter = new ScorePresenter(new ScoreModel(soundPresenter), viewContainer.GetView<ScoreView>());
        scorePresenter.Initialize();

        triggerZonesPresenter = new TriggerZonesPresenter(new TriggerZonesModel(), viewContainer.GetView<TriggerZonesView>());
        triggerZonesPresenter.Initialize();

        scaleEffectPresenter = new ScaleEffectPresenter(new ScaleEffectModel(), viewContainer.GetView<ScaleEffectView>());
        scaleEffectPresenter.Initialize();

        sceneRoot.SetSoundProvider(soundPresenter);
        sceneRoot.SetParticleEffectProvider(particleEffectPresenter);
        sceneRoot.Initialize();

        machineState = new GlobalMachineState(sceneRoot, soundPresenter, triggerZonesPresenter, fakeItemMovePresenter, itemCatalogPresenter, itemSpawnerPresenter, itemsPresenter, scorePresenter);
        machineState.Initialize();

        adaptiveScreenPresenter = new AdaptiveScreenPresenter(new AdaptiveScreenModel());

        ActivateGlobalEvents();

        adaptiveScreenPresenter.Initialize();

        sceneRoot.Activate();
    }

    private void ActivateGlobalEvents()
    {
        adaptiveScreenPresenter.OnChangeScreenFactor += itemSpawnerPresenter.SetScaleFactor;
        adaptiveScreenPresenter.OnChangeScreenFactor += fakeItemMovePresenter.SetScaleFactor;
    }

    private void DeactivateGlobalEvents()
    {
        adaptiveScreenPresenter.OnChangeScreenFactor -= itemSpawnerPresenter.SetScaleFactor;
        adaptiveScreenPresenter.OnChangeScreenFactor -= fakeItemMovePresenter.SetScaleFactor;
    }

    private void Dispose()
    {
        sceneRoot.Deactivate();

        sceneRoot?.Dispose();
        fakeItemMovePresenter?.Dispose();
        itemCatalogPresenter?.Dispose();
        itemSpawnerPresenter?.Dispose();
        itemsPresenter?.Dispose();
        scorePresenter?.Dispose();
    }

    private void OnDestroy()
    {
        Dispose();
    }
}
