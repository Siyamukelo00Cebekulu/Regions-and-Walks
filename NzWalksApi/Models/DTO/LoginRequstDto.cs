using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Components;

namespace NzWalksApi.Models.DTO;

public class LoginRequstDto
{
    [Required]
    [DataType(DataType.EmailAddress)]
    public string Username { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }
}
