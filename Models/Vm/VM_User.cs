using System.ComponentModel.DataAnnotations;

public class VM_User
{
[Key]
  public int Id {get; set;}

  public string Name { get; set; }
 public string? UserName { get; set; }
  public string? Email { get; set; }
 public string Phone { get; set; }
 public string PassWord { get; set; }

  public bool NaghdiStatus { get; set; }
  public bool SaderatStatus { get; set; }
  public bool LcStatus { get; set; }
  public bool AdminStatus { get; set; }

  public string ImageName { get; set; }

  public IFormFile? img { get; set; }

}