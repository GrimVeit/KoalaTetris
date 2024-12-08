using System;
using UnityEngine;

public class Item : MonoBehaviour, IIdentify
{
    public event Action<Item, Item, Vector3, Quaternion, Quaternion, int> OnGetPunch;
    public string GetID() => id;

    [SerializeField] private string id;

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

                    OnGetPunch?.Invoke(this, item, collision.contacts[0].point, transform.rotation, item.transform.rotation, int.Parse(id));
                }
            }
        }
    }

    public void DestroyItem()
    {
        Destroy(gameObject);
    }

    public void DeactivateItem()
    {
        isActive = false;
    }
}
