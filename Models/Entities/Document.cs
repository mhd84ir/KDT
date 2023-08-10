using System.ComponentModel.DataAnnotations;

public class Document
{
    [Key]
    public int Id { get; set; }
    public DateTime TarikhSabt { get; set; }
    public DateTime Tarikhsodor { get; set; }
    public DateTime TarikhEtebar { get; set; }
    public int status { get; set; }
    public string NoeForosh { get; set; }
    public string NameSherkat { get; set; }
    public string NameVasete { get; set; }
    public string NameMahsol { get; set; }
    public int Tedad { get; set; }
    public int FiGhablArzeshAfzode { get; set; }
    public string MabdaHaml { get; set; }
    public int Takhfif { get; set; }
    public int ArzeshAfzode { get; set; }
    public int GheymatNahaei { get; set; }
    public int MablaghDaryafti { get; set; }
    public string MojavezBargiri { get; set; }
    public int MeghdarBargiri { get; set; }
    public int St { get; set; }
    public string ImageName { get; set; }
    

    
    
    
    
}