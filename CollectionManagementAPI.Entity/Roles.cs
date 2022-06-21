using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Newtonsoft.Json.Converters;

namespace CollectionManagementAPI.Entity;

[JsonConverter(typeof(StringEnumConverter))]
public enum Roles
{
    [EnumMember(Value = "User")]
    User,
    [EnumMember(Value = "Admin")]
    Admin 
}