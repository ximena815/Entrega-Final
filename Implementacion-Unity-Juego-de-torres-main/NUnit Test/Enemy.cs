public class Enemy
{
    private int poder;
    public int Poder { get => poder; set => poder = value; }
    
    public void GenerarPoder(int poderNuevo)
    {
        poder = poderNuevo;
    }
}
