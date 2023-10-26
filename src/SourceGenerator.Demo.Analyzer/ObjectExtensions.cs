using Microsoft.CodeAnalysis;

namespace SourceGenerator.Demo.Analyzer
{
    internal static class ObjectExtensions
    {
        internal static string GetStringifiedDefaultValue(this object? self, ITypeSymbol selfType)
        {
            if (selfType.TypeKind == TypeKind.Enum)
            {
                return $"{selfType.GetFullyQualifiedName()}.{selfType.GetMembers()[(int)self].Name}";
                //return $"({selfType.GetStringifiedFullyQualifiedName()})({self})";
            }
            else
            {
                return self switch
                {
                    string s => $"\"{s}\"",
                    bool b => $"{(b ? "true" : "false")}",
                    byte b => b.GetStringifiedByteDefaultValue(),
                    sbyte sb => sb.GetStringifiedSignedByteDefaultValue(),
                    char c => c.GetStringifiedCharDefaultValue(),
                    decimal d => d.GetStringifiedDecimalDefaultValue(),
                    double d => d.GetStringifiedDoubleDefaultValue(),
                    float f => f.GetStringifiedFloatDefaultValue(),
                    int i => i.GetStringifiedIntDefaultValue(),
                    uint ui => ui.GetStringifiedUnsignedIntDefaultValue(),
                    long l => l.GetStringifiedLongDefaultValue(),
                    ulong ul => ul.GetStringifiedUnsignedLongDefaultValue(),
                    short s => s.GetStringifiedShortDefaultValue(),
                    ushort us => us.GetStringifiedUnsignedShortDefaultValue(),
                    null => selfType.IsValueType ? "default" :
                        selfType.TypeKind == TypeKind.TypeParameter ? "default!" : "null",
                    _ => self.ToString() ?? string.Empty
                };
            }
        }

        private static string GetStringifiedByteDefaultValue(this byte self) =>
            self switch
            {
                byte.MaxValue => "byte.MaxValue",
                byte.MinValue => "byte.MinValue",
                _ => self.ToString()
            };

        private static string GetStringifiedSignedByteDefaultValue(this sbyte self) =>
            self switch
            {
                sbyte.MaxValue => "sbyte.MaxValue",
                sbyte.MinValue => "sbyte.MinValue",
                _ => self.ToString()
            };

        private static string GetStringifiedCharDefaultValue(this char self) =>
            self switch
            {
                char.MaxValue => "char.MaxValue",
                char.MinValue => "char.MinValue",
                _ => $"'{self}'"
            };

        private static string GetStringifiedDecimalDefaultValue(this decimal self) =>
            self switch
            {
                decimal.MaxValue => "decimal.MaxValue",
                decimal.MinusOne => "decimal.MinusOne",
                decimal.MinValue => "decimal.MinValue",
                decimal.One => "decimal.One",
                decimal.Zero => "decimal.Zero",
                _ => self.ToString()
            };

        private static string GetStringifiedDoubleDefaultValue(this double self) =>
            self switch
            {
                double.Epsilon => "double.Epsilon",
                double.MaxValue => "double.MaxValue",
                double.MinValue => "double.MinValue",
                double.NaN => "double.NaN",
                double.NegativeInfinity => "double.NegativeInfinity",
                double.PositiveInfinity => "double.PositiveInfinity",
                _ => self.ToString()
            };

        private static string GetStringifiedFloatDefaultValue(this float self) =>
            self switch
            {
                float.Epsilon => "float.Epsilon",
                float.MaxValue => "float.MaxValue",
                float.MinValue => "float.MinValue",
                float.NaN => "float.NaN",
                float.NegativeInfinity => "float.NegativeInfinity",
                float.PositiveInfinity => "float.PositiveInfinity",
                _ => self.ToString()
            };

        private static string GetStringifiedIntDefaultValue(this int self) =>
            self switch
            {
                int.MaxValue => "int.MaxValue",
                int.MinValue => "int.MinValue",
                _ => self.ToString()
            };

        private static string GetStringifiedUnsignedIntDefaultValue(this uint self) =>
            self switch
            {
                uint.MaxValue => "uint.MaxValue",
                uint.MinValue => "uint.MinValue",
                _ => self.ToString()
            };

        private static string GetStringifiedLongDefaultValue(this long self) =>
            self switch
            {
                long.MaxValue => "long.MaxValue",
                long.MinValue => "long.MinValue",
                _ => self.ToString()
            };

        private static string GetStringifiedUnsignedLongDefaultValue(this ulong self) =>
            self switch
            {
                ulong.MaxValue => "ulong.MaxValue",
                ulong.MinValue => "ulong.MinValue",
                _ => self.ToString()
            };

        private static string GetStringifiedShortDefaultValue(this short self) =>
            self switch
            {
                short.MaxValue => "short.MaxValue",
                short.MinValue => "short.MinValue",
                _ => self.ToString()
            };

        private static string GetStringifiedUnsignedShortDefaultValue(this ushort self) =>
            self switch
            {
                ushort.MaxValue => "ushort.MaxValue",
                ushort.MinValue => "ushort.MinValue",
                _ => self.ToString()
            };
    }
}
