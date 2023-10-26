using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace SourceGenerator.Demo.Analyzer
{
    // Taken from https://github.com/kant2002/SourceGeneratorsKit
    public class SyntaxReceiver : ISyntaxContextReceiver
    {
        public List<IMethodSymbol> Methods { get; } = new List<IMethodSymbol>();
        public List<IFieldSymbol> Fields { get; } = new List<IFieldSymbol>();
        public List<IPropertySymbol> Properties { get; } = new List<IPropertySymbol>();
        public List<INamedTypeSymbol> Classes { get; } = new List<INamedTypeSymbol>();

        public virtual bool CollectMethodSymbol { get; } = false;
        public virtual bool CollectFieldSymbol { get; } = false;
        public virtual bool CollectPropertySymbol { get; } = false;
        public virtual bool CollectClassSymbol { get; } = false;

        /// <inheritdoc/>
        public void OnVisitSyntaxNode(GeneratorSyntaxContext context)
        {
            switch (context.Node)
            {
                case MethodDeclarationSyntax methodDeclarationSyntax:
                    this.OnVisitMethodDeclaration(methodDeclarationSyntax, context.SemanticModel);
                    break;
                case PropertyDeclarationSyntax propertyDeclarationSyntax:
                    this.OnVisitPropertyDeclaration(propertyDeclarationSyntax, context.SemanticModel);
                    break;
                case FieldDeclarationSyntax fieldDeclarationSyntax:
                    this.OnVisitFieldDeclaration(fieldDeclarationSyntax, context.SemanticModel);
                    break;
                case ClassDeclarationSyntax classDeclarationSyntax:
                    this.OnVisitClassDeclaration(classDeclarationSyntax, context.SemanticModel);
                    break;
            };
        }

        protected virtual void OnVisitMethodDeclaration(MethodDeclarationSyntax methodDeclarationSyntax, SemanticModel model)
        {
            if (!this.CollectMethodSymbol)
            {
                return;
            }

            if (!this.ShouldCollectMethodDeclaration(methodDeclarationSyntax))
            {
                return;
            }

            var methodSymbol = model.GetDeclaredSymbol(methodDeclarationSyntax) as IMethodSymbol;
            if (methodSymbol is null)
            {
                return;
            }

            if (!this.ShouldCollectMethodSymbol(methodSymbol))
            {
                return;
            }

            this.Methods.Add(methodSymbol);
        }

        protected virtual bool ShouldCollectMethodDeclaration(MethodDeclarationSyntax methodDeclarationSyntax)
            => true;

        protected virtual bool ShouldCollectMethodSymbol(IMethodSymbol methodSymbol)
            => true;

        protected virtual void OnVisitFieldDeclaration(FieldDeclarationSyntax fieldDeclarationSyntax, SemanticModel model)
        {
            if (!this.CollectFieldSymbol)
            {
                return;
            }

            if (!this.ShouldCollectFieldDeclaration(fieldDeclarationSyntax))
            {
                return;
            }

            var fieldSymbol = model.GetDeclaredSymbol(fieldDeclarationSyntax) as IFieldSymbol;
            if (fieldSymbol == null)
            {
                return;
            }

            if (!this.ShouldCollectFieldSymbol(fieldSymbol))
            {
                return;
            }

            this.Fields.Add(fieldSymbol);
        }

        protected virtual bool ShouldCollectFieldDeclaration(FieldDeclarationSyntax fieldDeclarationSyntax)
            => true;

        protected virtual bool ShouldCollectFieldSymbol(IFieldSymbol fieldSymbol)
            => true;

        protected virtual void OnVisitPropertyDeclaration(PropertyDeclarationSyntax propertyDeclarationSyntax, SemanticModel model)
        {
            if (!this.CollectPropertySymbol)
            {
                return;
            }

            if (!this.ShouldCollectPropertyDeclaration(propertyDeclarationSyntax))
            {
                return;
            }

            var propertySymbol = model.GetDeclaredSymbol(propertyDeclarationSyntax) as IPropertySymbol;
            if (propertySymbol == null)
            {
                return;
            }

            if (!this.ShouldCollectPropertySymbol(propertySymbol))
            {
                return;
            }

            this.Properties.Add(propertySymbol);
        }

        protected virtual bool ShouldCollectPropertyDeclaration(PropertyDeclarationSyntax propertyDeclarationSyntax)
            => true;

        protected virtual bool ShouldCollectPropertySymbol(IPropertySymbol propertySymbol)
            => true;

        protected virtual void OnVisitClassDeclaration(ClassDeclarationSyntax classDeclarationSyntax, SemanticModel model)
        {
            if (!this.CollectClassSymbol)
            {
                return;
            }

            if (!this.ShouldCollectClassDeclaration(classDeclarationSyntax))
            {
                return;
            }

            var classSymbol = model.GetDeclaredSymbol(classDeclarationSyntax) as INamedTypeSymbol;
            if (classSymbol == null)
            {
                return;
            }

            if (!this.ShouldCollectClassSymbol(classSymbol))
            {
                return;
            }

            this.Classes.Add(classSymbol);
        }

        protected virtual bool ShouldCollectClassDeclaration(ClassDeclarationSyntax classDeclarationSyntax)
            => true;

        protected virtual bool ShouldCollectClassSymbol(INamedTypeSymbol classSymbol)
            => true;
    }
}
