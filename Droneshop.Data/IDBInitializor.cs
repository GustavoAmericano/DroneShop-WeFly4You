namespace Droneshop.Data
{
    public interface IDBInitializor
    {
        void SeedDB(DroneShopContext context);
    }
}