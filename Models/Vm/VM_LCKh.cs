using System.ComponentModel.DataAnnotations;

public class VM_LCKh
{

    public int Id { get; set; }
    public DateTime TarikhSabt { get; set; }
    public string Tarikhsodor { get; set; }
    public string? TarikhEtebar { get; set; }
    public int status { get; set; }
    public string MaghsadHaml { get; set; }
    public string NameSherkat { get; set; }
    public string? NameVasete { get; set; }
    public string NameMahsol { get; set; }
    public string? BankGoshayesh { get; set; }
    public int FiGhablArzeshAfzode { get; set; }
    public string MabdaHaml { get; set; }
    public int Takhfif { get; set; }
    public int ArzeshAfzode { get; set; }
    public int GheymatNahaei { get; set; }
    public string? ImageName { get; set; }
    public int Tonazh { get; set; }

    public int? MeghdarBargiri { get; set; }

    public string SherkatId { get; set; }
    public string? BankKargozari { get; set; }
    public int? KomisionVasete { get; set; }

    public int LCDay { get; set; }

    public string? Size { get; set; }

    public string? Tozih { get; set; }
    public string? Sepam { get; set; }

    public string? TarikhGoshayesh { get; set; }



    public string? ShomarePish { get; set; }

    public IFormFile Img { get; set; }

    public string TarikhR { get; set; }

    public int? TonazhR { get; set; }

        public int? MablaghR { get; set; }
        public int RId { get; set; }




}