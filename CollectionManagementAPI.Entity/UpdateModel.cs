using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Newtonsoft.Json.Converters;

namespace CollectionManagementAPI.Entity;

public class UpdateModel
{
    public int Id { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string? Name { get; set; }
    public string? Surname { get; set; }

    public bool IsBlock { get; set; }
    
    [EnumDataType(typeof(Roles))]
    [JsonConverter(typeof(StringEnumConverter))]
    public Roles Role { get; set; }
}