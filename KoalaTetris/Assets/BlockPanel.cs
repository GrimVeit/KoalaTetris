using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockPanel : Panel
{
    public override void ActivatePanel()
    {
        base.ActivatePanel();

        panel.SetActive(true);
    }

    public override void DeactivatePanel()
    {
        panel.SetActive(false);
    }
}
