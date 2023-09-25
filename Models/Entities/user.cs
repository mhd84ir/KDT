using System.ComponentModel.DataAnnotations;

public class user
{
[Key]
  public Guid IdUser {get; set;}

  public string Name { get; set; }
  public string Family { get; set; }

 public string UserName { get; set; }
  public string UserRole { get; set; }

  public string UserPassword { get; set; }

}