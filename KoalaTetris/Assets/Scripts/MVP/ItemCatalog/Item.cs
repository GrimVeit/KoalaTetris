using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour, IIdentify
{
    public event Action<Item, Item, Vector3, Quaternion, Quaternion, int, int> OnGetPunch;
    public string GetID() => id;

    [SerializeField] private Image imageItem;
    [SerializeField] private Sprite spriteOpen;
    [SerializeField] private Sprite spriteClose;

    [SerializeField] private string id;
    [SerializeField] private int score;

    private IEnumerator animationCoroutine;

    private bool isActive = true;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isActive) return;

        if (collision != null)
        {
            if (collision.gameObject.TryGetComponent<Item>(out var item))
            {
                if (item.GetID() == id)
                {
                    DeactivateItem();
                    item.DeactivateItem();

                    Debug.Log("Punch, contacts -" + collision.contacts.Length);

                    OnGetPunch?.Invoke(this, item, collision.contacts[0].point, transform.rotation, item.transform.rotation, int.Parse(id), score);
                }
            }
        }
    }

    public void ActivateAnimationFailGame()
    {
        if (animationCoroutine != null)
            Coroutines.Stop(animationCoroutine);

        animationCoroutine = AnimationCoroutine(6);
        Coroutines.Start(animationCoroutine);
    }

    private IEnumerator AnimationCoroutine(int countLoops)
    {
        for (int i = 0; i < countLoops; i++)
        {
            imageItem.sprite = imageItem.sprite == spriteOpen ? spriteClose : spriteOpen;

            yield return new WaitForSeconds(0.3f);
        }

        imageItem.sprite = spriteClose;

    }



    public void DestroyItem()
    {
        Destroy(gameObject);
    }

    public void DeactivateItem()
    {
        isActive = false;
    }

    private void OnDestroy()
    {
        if(animationCoroutine != null)
            Coroutines.Stop(animationCoroutine);
    }
}
