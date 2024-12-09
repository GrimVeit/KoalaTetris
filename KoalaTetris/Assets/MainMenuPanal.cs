using UnityEngine;

public class MainMenuPanal : MovePanel
{
    [SerializeField] private ShakePanel shakePanel;

    public override void Initialize()
    {
        shakePanel.Initialize();
    }

    public override void Dispose()
    {
        shakePanel.Dispose();
    }
}
