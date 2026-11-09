public abstract class DongVat
{
    public abstract string Keu();
}
public class Cho : DongVat
{
    public override string Keu() => "Gau Gau";
}
public class Meo : DongVat
{
    public override string Keu() => "Meo Meo";
}
public class Chim : DongVat
{
    public override string Keu() => "Chip Chip";
}
public class DongVatView
{
    public void HienThi(DongVat dv)
    {
        Console.WriteLine($"{dv.GetType().Name} keu: {dv.Keu()}");
    }
}
public class DongVatController
{
    private List<DongVat> ds = new List<DongVat>
    {
        new Cho(),
        new Meo(),
        new Chim()
    };
    private DongVatView view = new DongVatView();

    public void Chay()
    {
        foreach (DongVat dv in ds)
        {
            view.HienThi(dv);
        }
    }
}
public class Program
{
    public static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        new DongVatController().Chay();
    }
}