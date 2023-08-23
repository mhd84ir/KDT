using System.ComponentModel.DataAnnotations;

public class Sherkat
{
    [Key]
    public int Id { get; set; }
    public string NameSherkat { get; set; }
    
    
    public string ShomareSabt { get; set; }
    public string ShenaseMeli { get; set; }
    public string Codeposti { get; set; }

    public string Neshani { get; set; }
    
}