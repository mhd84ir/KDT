using System.ComponentModel.DataAnnotations;

public class LcRequest 
{
    [Key]
    public int Id { get; set; }
    
    public string TarikhR { get; set; }
    public int? Tonazh { get; set; }
    
        public int? MablaghR { get; set; }

        public int SherkatId { get; set; }

        public int Status { get; set; }

        public string NameSherkat { get; set; }
        public string Vaste { get; set; }

        public string? Tozih { get; set; }
        
        public string? ImageName { get; set; }
        
        
        
        
        
}