using System;
using UnityEngine;

public class MainMenuEntryPoint : MonoBehaviour
{
    [SerializeField] private Sounds sounds;
    [SerializeField] private ItemDatas itemDatas;
    [SerializeField] private Items items;
    //[SerializeField] private UIMainMenuRoot menuRootPrefab;
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

    private GlobalMachineState machineState;

    public void Start()
    {
        //sceneRoot = Instantiate(menuRootPrefab);
 
        //uIRootView.AttachSceneUI(sceneRoot.gameObject, Camera.main);

        viewContainer = sceneRoot.GetComponent<ViewContainer>();
        viewContainer.Initialize();

        soundPresenter = new SoundPresenter
                    (new SoundModel(sounds.sounds, PlayerPrefsKeys.IS_MUTE_SOUNDS),
                    viewContainer.GetView<SoundView>());
        soundPresenter.Initialize();

        fakeItemMovePresenter = new FakeItemMovePresenter(new FakeItemMoveModel(), viewContainer.GetView<FakeItemMoveView>());
        fakeItemMovePresenter.Initialize();

        itemCatalogPresenter = new ItemCatalogPresenter(new ItemCatalogModel(itemDatas), viewContainer.GetView<ItemCatalogView>());
        itemCatalogPresenter.Initialize();

        itemSpawnerPresenter = new ItemSpawnerPresenter(new ItemSpawnerModel(items), viewContainer.GetView<ItemSpawnerView>());
        itemSpawnerPresenter.Initialize();

        itemsPresenter = new ItemsPresenter(new ItemsModel(12));
        itemsPresenter.Initialize();

        scorePresenter = new ScorePresenter(new ScoreModel(soundPresenter), viewContainer.GetView<ScoreView>());
        scorePresenter.Initialize();

        sceneRoot.SetSoundProvider(soundPresenter);
        sceneRoot.SetParticleEffectProvider(particleEffectPresenter);
        sceneRoot.Initialize();

        machineState = new GlobalMachineState(sceneRoot, fakeItemMovePresenter, itemCatalogPresenter, itemSpawnerPresenter, itemsPresenter, scorePresenter);
        machineState.Initialize();

        sceneRoot.Activate();
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

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            machineState.SetState(machineState.GetState<PauseState>());
        }
    }
}
