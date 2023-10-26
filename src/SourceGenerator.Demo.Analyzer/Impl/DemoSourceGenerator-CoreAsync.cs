﻿using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;
using System.Text;
using System.Linq;

namespace SourceGenerator.Demo.Analyzer
{
    public partial class DemoSourceGenerator 
    {
        private void HandleCoreAsyncMethods(SyntaxReceiver receiver, GeneratorExecutionContext context)
        {
            // Declared methods
            var declaredLookup = receiver.Methods.Where(x => !x.IsExtensionMethod)
                .ToLookup(x => x.ContainingSymbol, x => x,
                SymbolEqualityComparer.Default);

            foreach (var lookupGroup in declaredLookup)
            {
                GenerateDeclaredSyncAsyncMethods(lookupGroup.Key as INamedTypeSymbol, lookupGroup.ToArray(), context);
            }

            // Extension methods
            var extensionsLookup = receiver.Methods.Where(x => x.IsExtensionMethod)
                .ToLookup(x => x.Parameters[0].Type, x => x,
                SymbolEqualityComparer.Default);

            foreach (var lookupGroup in extensionsLookup)
            {
                GenerateExtensionSyncAsyncMethods(lookupGroup.Key as INamedTypeSymbol, lookupGroup.ToArray(), context);
            }
        }

        private void GenerateDeclaredSyncAsyncMethods(INamedTypeSymbol classSymbol, IMethodSymbol[] methods, GeneratorExecutionContext context)
        {
            StringBuilder sb = new StringBuilder($@"// <auto-generated />

namespace {classSymbol.ContainingNamespace}
{{
    public partial class {classSymbol.Name}
    {{");
            foreach (var method in methods.Where(x => x.MethodKind == MethodKind.Ordinary))
            {
                var parameters = method.Parameters.Where(x => x.Name != "sync").ToList();
                var returnType = method.ReturnType as INamedTypeSymbol;
                var methodName = method.Name.Replace("CoreAsync", "");


                sb.Append($@"
        // {methodName}
        public {returnType.TypeArguments[0].GetFullyQualifiedName()} {methodName}{ConstructTypeParamsString(method)}({ConstructParamsString(parameters, true)}) {ConstructTypeParamConstraintsString(method, 12)}
            => {method.Name}{ConstructTypeParamsString(method)}({ConstructParamsAsArgsString(parameters,true)}, true).GetAwaiter().GetResult();
        public {returnType.GetFullyQualifiedName()} {methodName}Async{ConstructTypeParamsString(method)}({ConstructParamsString(parameters)}) {ConstructTypeParamConstraintsString(method, 12)}
            => {method.Name}{ConstructTypeParamsString(method)}({ConstructParamsAsArgsString(parameters)}, false);
");

            }

            sb.Append($@"
    }}
}}");

            // Code generation goes here
            context.AddSource($"{classSymbol.Name}-CoreAsync.generated.cs", SourceText.From(sb.ToString(), Encoding.UTF8));
        }

        private void GenerateExtensionSyncAsyncMethods(INamedTypeSymbol classSymbol, IMethodSymbol[] methods, GeneratorExecutionContext context)
        {
            StringBuilder sb = new StringBuilder($@"// <auto-generated />

namespace {classSymbol.ContainingNamespace}
{{
    public static partial class {classSymbol.Name}Extensions
    {{");
            foreach (var method in methods.Where(x => x.MethodKind == MethodKind.Ordinary))
            {
                // We skip the first param as we know this is an extension method.
                // We also trim any sync parameter
                var parameters = method.Parameters.Skip(1).Where(x => x.Name != "sync").ToList();
                var returnType = method.ReturnType as INamedTypeSymbol;
                var methodName = method.Name.Replace("CoreAsync", "");

                sb.Append($@"
        // {methodName}
        public static {returnType.TypeArguments[0].GetFullyQualifiedName()} {methodName}{ConstructTypeParamsString(method)}({ConstructParamsString($"this {returnType.TypeArguments[0].GetFullyQualifiedName()} entity", parameters, true)}) {ConstructTypeParamConstraintsString(method, 12)}
            => entity.{method.Name}{ConstructTypeParamsString(method)}({ConstructParamsAsArgsString(parameters, true)}, true).GetAwaiter().GetResult();
        public static {returnType.GetFullyQualifiedName()} {methodName}Async{ConstructTypeParamsString(method)}({ConstructParamsString($"this {returnType.TypeArguments[0].GetFullyQualifiedName()} entity", parameters)}) {ConstructTypeParamConstraintsString(method, 12)}
            => entity.{method.Name}{ConstructTypeParamsString(method)}({ConstructParamsAsArgsString(parameters)}, false);
");

            }

            sb.Append($@"
    }}
}}");

            // Code generation goes here
            context.AddSource($"{classSymbol.Name}Extensions-CoreAsync.generated.cs", SourceText.From(sb.ToString(), Encoding.UTF8));
        }
    }
}
