using System;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

using Modio.Models;

namespace Modio;

[JsonConverter(typeof(EditResultConverter))]
internal class EditResult<T> where T : class
{
    public T? Object { get; private set; }

    internal EditResult(T? @object)
    {
        Object = @object;
    }
}

class EditResultConverter : JsonConverterFactory
{
    public override bool CanConvert(Type typeToConvert)
    {
        return true;
    }

    public override JsonConverter CreateConverter(Type typeToConvert, JsonSerializerOptions options)
    {
        var entityType = typeToConvert.GetGenericArguments()[0];
        var converterType = typeof(EditResultConverterInner<>).MakeGenericType(new Type[] { entityType });
        var converter = (JsonConverter?)Activator.CreateInstance(
            converterType,
            BindingFlags.Instance | BindingFlags.Public,
            binder: null,
            args: new object[0],
            culture: null
        );
        return converter!;
    }

    class EditResultConverterInner<T> : JsonConverter<EditResult<T>>
        where T : class
    {
        public override EditResult<T> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var restore = reader;

            var msg = JsonSerializer.Deserialize<ApiMessage>(ref reader, options);
            if (msg!.Code != null && msg.Message != null)
            {
                return new EditResult<T>(null);
            }

            reader = restore;
            var entityType = typeToConvert.GetGenericArguments()[0];
            var entity = (T?)JsonSerializer.Deserialize(ref reader, entityType, options);
            return new EditResult<T>(entity);
        }

        public override void Write(Utf8JsonWriter writer, EditResult<T> value, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }
    }
}