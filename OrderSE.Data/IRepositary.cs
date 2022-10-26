namespace OrderSE.Data
{
    public interface IRepositary
    {
        List<ClientEntity> Read(string path);
        string GetBase();
    }
}
