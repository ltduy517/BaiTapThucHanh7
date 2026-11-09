public abstract class TaiKhoanNganHang
{
    public double SoDu { get; protected set; }

    public TaiKhoanNganHang(double soDu)
    {
        SoDu = soDu;
    }
    public abstract bool GuiTien(double soTien);
    public abstract bool RutTien(double soTien);
}
public class TaiKhoanThanhToan : TaiKhoanNganHang
{
    private const double Phi = 1000;

    public TaiKhoanThanhToan(double soDu) : base(soDu) { }

    public override bool GuiTien(double soTien)
    {
        if (soTien <= 0) return false;
        SoDu += soTien;
        return true;
    }
    public override bool RutTien(double soTien)
    {
        if (soTien <= 0 || soTien + Phi > SoDu) return false;
        SoDu -= soTien + Phi;
        return true;
    }
}
public class TaiKhoanTietKiem : TaiKhoanNganHang
{
    private const double SoDuToiThieu = 100000;

    public TaiKhoanTietKiem(double soDu) : base(soDu) { }

    public override bool GuiTien(double soTien)
    {
        if (soTien <= 0) return false;
        SoDu += soTien;
        return true;
    }
    public override bool RutTien(double soTien)
    {
        if (soTien <= 0 || SoDu - soTien < SoDuToiThieu) return false;
        SoDu -= soTien;
        return true;
    }
}

public class NganHangView
{
    public void HienThiKetQua(string thaoTac, double soTien, bool thanhCong, double soDu)
    {
        string kq = thanhCong ? "Thanh Cong" : "That Bai";
        Console.WriteLine($"{thaoTac} {soTien:N0}: {kq}  So du: {soDu:N0}");
    }

    public void HienThiTieuDe(string tieuDe)
    {
        Console.WriteLine($"--- {tieuDe} ---");
    }
}

public class NganHangController
{
    private NganHangView view = new NganHangView();

    public void Chay()
    {
        TaiKhoanNganHang tt = new TaiKhoanThanhToan(500000);
        TaiKhoanNganHang tk = new TaiKhoanTietKiem(1000000);

        view.HienThiTieuDe("Tai KHoang Thanh Toan");
        view.HienThiKetQua("Gui", 200000, tt.GuiTien(200000), tt.SoDu);
        view.HienThiKetQua("Rut", 300000, tt.RutTien(300000), tt.SoDu);
        view.HienThiKetQua("Rut", 900000, tt.RutTien(900000), tt.SoDu);

        view.HienThiTieuDe("Tai Khoang Tiet Kiem");
        view.HienThiKetQua("Gui", 500000, tk.GuiTien(500000), tk.SoDu);
        view.HienThiKetQua("Rut", 400000, tk.RutTien(400000), tk.SoDu);
        view.HienThiKetQua("Rut", 1100000, tk.RutTien(1100000), tk.SoDu);
    }
}
public class Program
{
    public static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        new NganHangController().Chay();
    }
}