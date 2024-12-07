using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCatalogPresenter
{
    private ItemCatalogModel catalogModel;
    private ItemCatalogView catalogView;

    public ItemCatalogPresenter(ItemCatalogModel catalogModel, ItemCatalogView catalogView)
    {
        this.catalogModel = catalogModel;
        this.catalogView = catalogView;
    }

    public void Initialize()
    {

    }

    public void Dispose()
    {

    }
}
