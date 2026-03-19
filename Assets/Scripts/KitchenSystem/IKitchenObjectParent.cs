using UnityEngine;

public interface IKitchenObjectParent
{
    public Transform GetKitchenOnjectFollowTransform();

    public void SetKitchenObject(kitchenObject kitchenObject);

    public kitchenObject GetKitchenObject();

    public void ClearKitchenObject();

    public bool HasKitchenObject();
}
