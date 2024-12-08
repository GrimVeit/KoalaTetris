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

        //particleEffectPresenter = new ParticleEffectPresenter
        //    (new ParticleEffectModel(),
        //    viewContainer.GetView<ParticleEffectView>());
        //particleEffectPresenter.Initialize();

        //bankPresenter = new BankPresenter(new BankModel(), viewContainer.GetView<BankView>());
        //bankPresenter.Initialize();

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

        ActivateEvents();

        sceneRoot.Activate();

        itemCatalogPresenter.SelectSecondItemData();
    }

    private void ActivateEvents()
    {
        itemCatalogPresenter.OnSelectCurrentItem_Value += fakeItemMovePresenter.SetData;
        itemCatalogPresenter.OnSelectCurrentItem_Value += itemSpawnerPresenter.SetData;

        itemCatalogPresenter.OnSelectCurrentItem += fakeItemMovePresenter.Activate;

        fakeItemMovePresenter.OnEndMove_Position += itemSpawnerPresenter.Spawn;
        fakeItemMovePresenter.OnEndMove += itemCatalogPresenter.SelectSecondItemData;

        itemsPresenter.OnAddNewItem += itemSpawnerPresenter.Spawn;
        itemsPresenter.OnAddScore += scorePresenter.AddScore;
        itemSpawnerPresenter.OnItemSpawned += itemsPresenter.AddItem;
    }

    private void DeactivateEvents()
    {
        itemCatalogPresenter.OnSelectCurrentItem_Value -= fakeItemMovePresenter.SetData;
        itemCatalogPresenter.OnSelectCurrentItem_Value -= itemSpawnerPresenter.SetData;

        itemCatalogPresenter.OnSelectCurrentItem -= fakeItemMovePresenter.Activate;

        fakeItemMovePresenter.OnEndMove_Position -= itemSpawnerPresenter.Spawn;
        fakeItemMovePresenter.OnEndMove -= itemCatalogPresenter.SelectSecondItemData;

        itemsPresenter.OnAddNewItem -= itemSpawnerPresenter.Spawn;
        itemsPresenter.OnAddScore -= scorePresenter.AddScore;
        itemSpawnerPresenter.OnItemSpawned -= itemsPresenter.AddItem;
    }

    private void Dispose()
    {
        DeactivateEvents();
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
            itemCatalogPresenter.SelectSecondItemData();
        }
    }
}
