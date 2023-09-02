
using System.ComponentModel.DataAnnotations;

public class MahsolSa
{
    [Key]
    public int Id { get; set; }
    
    public string NameMahsol { get; set; }

    public string HSCode { get; set; }
    public char FirstOfName { get; set; }
    
    
    
}