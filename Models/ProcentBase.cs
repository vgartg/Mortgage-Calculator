using System.ComponentModel.DataAnnotations;

namespace FirstWebProject.Models;

public class ProcentBase
{
    public int Id { get; set; }
    public string? bank_name { get; set; }
    public string? program_name { get; set; }
    public float procent { get; set; }
}