using System.ComponentModel.DataAnnotations;

public class Vm_RequestLcF
{

    public int Id { get; set; }
    
    public string TarikhR { get; set; }
    public int? Tonazh { get; set; }
    
        public int? MablaghR { get; set; }

        public int SherkatId { get; set; }

        public string NameSherkat { get; set; }
        public string Vaste { get; set; }

        public string? Tozih { get; set; }
        
        public string? ImageName { get; set; }

    public IFormFile img { get; set; }

}