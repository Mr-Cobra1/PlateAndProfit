using UnityEngine;

public class ClearCounter : BaseCounter
{

    [SerializeField] private KitchenObjectSO kitchenObjectSO;


    public override void Interact(Player player)
    {
        // If player has a kitchen object, and counter has no kitchen object, give it to the counter
        if (!HasKitchenObject() && player.HasKitchenObject())
        {
            player.GetKitchenObject().SetKitchenObjectParent(this);
        }
        // If player has no kitchen object, and counter has a kitchen object, give it to the player
        else if (HasKitchenObject() && !player.HasKitchenObject())
        {
            GetKitchenObject().SetKitchenObjectParent(player);
        }
        else if (HasKitchenObject() && player.HasKitchenObject())
        {
            if (player.GetKitchenObject().TryGetPlate(out PlateKitchenObject plateKitchenObject))
            {
                // Try to add the ingredient to the plate (ONLY 1 OF EACH KIND), if it fails, do nothing
                if (plateKitchenObject.TryAddIngredient(GetKitchenObject().GetKitchenObjectSO()))
                {
                    GetKitchenObject().DestroySelf();
                }
            }
            else
            {
                //Player is not holding a plate, but something else
                if (GetKitchenObject().TryGetPlate(out plateKitchenObject))
                {
                    //counter is holding a plate, but player is not, try to add the ingredient to the plate (ONLY 1 OF EACH KIND), if it fails, do nothing
                    if (plateKitchenObject.TryAddIngredient(player.GetKitchenObject().GetKitchenObjectSO()))
                    {
                        player.GetKitchenObject().DestroySelf();
                    }
                }
            }
        }
    }

}
