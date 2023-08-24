public interface IStorageable{
    int DepositItem(int amount, int itemId);
    int CollectItem(int amount, int itemId);
    int ShowItems(int itemId);
    float GetX();
    float GetZ();
}