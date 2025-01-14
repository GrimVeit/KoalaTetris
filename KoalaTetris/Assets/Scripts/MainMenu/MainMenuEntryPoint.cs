using System;
using UnityEngine;

public class MainMenuEntryPoint : MonoBehaviour
{
    [SerializeField] private Sounds sounds;
    [SerializeField] private GameTypes gameTypes;
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
    private BonusPresenter bonusPresenter;

    private TriggerZonesPresenter triggerZonesPresenter;
    private ScaleEffectPresenter scaleEffectPresenter;

    private GameTypePresenter gameTypePresenter;
    private DesignPresenter designPresenter;

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

        itemCatalogPresenter = new ItemCatalogPresenter(new ItemCatalogModel(), viewContainer.GetView<ItemCatalogView>());

        itemSpawnerPresenter = new ItemSpawnerPresenter(new ItemSpawnerModel(), viewContainer.GetView<ItemSpawnerView>());

        itemsPresenter = new ItemsPresenter(new ItemsModel(12, particleEffectPresenter, soundPresenter));
        itemsPresenter.Initialize();

        scorePresenter = new ScorePresenter(new ScoreModel(soundPresenter), viewContainer.GetView<ScoreView>());
        scorePresenter.Initialize();

        bonusPresenter = new BonusPresenter(new BonusModel(soundPresenter), viewContainer.GetView<BonusView>());
        bonusPresenter.Initialize();

        triggerZonesPresenter = new TriggerZonesPresenter(new TriggerZonesModel(), viewContainer.GetView<TriggerZonesView>());
        triggerZonesPresenter.Initialize();

        scaleEffectPresenter = new ScaleEffectPresenter(new ScaleEffectModel(), viewContainer.GetView<ScaleEffectView>());
        scaleEffectPresenter.Initialize();

        gameTypePresenter = new GameTypePresenter(new GameTypeModel(gameTypes), viewContainer.GetView<GameTypesView>());

        designPresenter = new DesignPresenter(new DesignModel(), viewContainer.GetView<DesignView>());
        designPresenter.Initialize();

        sceneRoot.SetSoundProvider(soundPresenter);
        sceneRoot.SetParticleEffectProvider(particleEffectPresenter);
        sceneRoot.Initialize();

        machineState = new GlobalMachineState(
            sceneRoot, 
            soundPresenter, 
            triggerZonesPresenter, 
            fakeItemMovePresenter, 
            itemCatalogPresenter, 
            itemSpawnerPresenter, 
            itemsPresenter, 
            scorePresenter, 
            gameTypePresenter, 
            bonusPresenter);
        machineState.Initialize();

        adaptiveScreenPresenter = new AdaptiveScreenPresenter(new AdaptiveScreenModel());

        ActivateGlobalEvents();

        gameTypePresenter.Initialize();
        itemSpawnerPresenter.Initialize();
        itemCatalogPresenter.Initialize();
        adaptiveScreenPresenter.Initialize();

        sceneRoot.Activate();
    }

    private void ActivateGlobalEvents()
    {
        adaptiveScreenPresenter.OnChangeScreenFactor += itemSpawnerPresenter.SetScaleFactor;
        adaptiveScreenPresenter.OnChangeScreenFactor += fakeItemMovePresenter.SetScaleFactor;

        gameTypePresenter.OnChooseGameType_Value += itemCatalogPresenter.SetItemDatas;
        gameTypePresenter.OnChooseGameType_Value += itemSpawnerPresenter.SetItems;
        gameTypePresenter.OnChooseGameType_Value += designPresenter.SetDesign;

        bonusPresenter.OnUnlockGame_ID += gameTypePresenter.UnlockGame;
        bonusPresenter.OnScoreMultiplier_Size += scorePresenter.SetMultiplier;
    }

    private void DeactivateGlobalEvents()
    {
        adaptiveScreenPresenter.OnChangeScreenFactor -= itemSpawnerPresenter.SetScaleFactor;
        adaptiveScreenPresenter.OnChangeScreenFactor -= fakeItemMovePresenter.SetScaleFactor;

        gameTypePresenter.OnChooseGameType_Value -= itemCatalogPresenter.SetItemDatas;
        gameTypePresenter.OnChooseGameType_Value -= itemSpawnerPresenter.SetItems;
        gameTypePresenter.OnChooseGameType_Value -= designPresenter.SetDesign;

        bonusPresenter.OnUnlockGame_ID -= gameTypePresenter.UnlockGame;
        bonusPresenter.OnScoreMultiplier_Size -= scorePresenter.SetMultiplier;
    }

    private void Dispose()
    {
        DeactivateGlobalEvents();
        sceneRoot.Deactivate();

        sceneRoot?.Dispose();
        fakeItemMovePresenter?.Dispose();
        itemCatalogPresenter?.Dispose();
        itemSpawnerPresenter?.Dispose();
        itemsPresenter?.Dispose();
        scorePresenter?.Dispose();
        bonusPresenter?.Dispose();

        triggerZonesPresenter?.Dispose();
        scaleEffectPresenter?.Dispose();
        gameTypePresenter?.Dispose();
        adaptiveScreenPresenter?.Dispose();
        designPresenter?.Dispose();
        machineState?.Dispose();
    }

    private void OnDestroy()
    {
        Dispose();
    }
}
