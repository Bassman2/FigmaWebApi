namespace FigmaWebApi.Model;

[JsonSourceGenerationOptions(
    JsonSerializerDefaults.Web,
    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
    WriteIndented = true,
    AllowTrailingCommas = true
    //Converters = [ 
    //    //typeof(TextJsonConverter), 
    //    typeof(BooleanJsonConverter) ]
    )]

[JsonSerializable(typeof(UserModel))]

internal partial class SourceGenerationContext : JsonSerializerContext
{ }