using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;
using System.Text;

namespace PokedexAnalyzer
{
    [DiagnosticAnalyzer(LanguageNames.CSharp)]
    public class PokedexAnalyzerAnalyzer : DiagnosticAnalyzer
    {
        public const string DiagnosticId = "Pokeball";

        // You can change these strings in the Resources.resx file. If you do not want your analyzer to be localize-able, you can use regular strings for Title and MessageFormat.
        // See https://github.com/dotnet/roslyn/blob/master/docs/analyzers/Localizing%20Analyzers.md for more on localization
        private static readonly LocalizableString Title = "Pokemon Caught";
        private static readonly LocalizableString MessageFormat = "Gotcha! {0} was caught!";
        private static readonly LocalizableString Description = "You have just caught a Pokemon, Check your pokedex for more information";
        private const string Category = "Naming";

        private static DiagnosticDescriptor Rule = new DiagnosticDescriptor(DiagnosticId, Title, MessageFormat, Category, DiagnosticSeverity.Warning, isEnabledByDefault: true, description: Description);

        public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics { get { return ImmutableArray.Create(Rule); } }

        public override void Initialize(AnalysisContext context)
        {
            // TODO: Consider registering other actions that act on syntax instead of or in addition to symbols
            // See https://github.com/dotnet/roslyn/blob/master/docs/analyzers/Analyzer%20Actions%20Semantics.md for more information
            context.RegisterSyntaxNodeAction(AnalyzeNode, SyntaxKind.CatchDeclaration);
            //context.register
        }

        private static void AnalyzeNode(SyntaxNodeAnalysisContext context)
        {
            var declarationIdentifier = (CatchDeclarationSyntax)context.Node;
            var typeIdenfitier = (IdentifierNameSyntax)declarationIdentifier.Type;
            if(typeIdenfitier.Identifier.ValueText == "Pokemon")
            {
                var name = PokemonNameNormaliser(declarationIdentifier.Identifier.ValueText);
                // Pokemon caught
                var diagnostic = Diagnostic.Create(Rule, declarationIdentifier.GetLocation(), name);

                CaughtArray.AmmendList(name);

                context.ReportDiagnostic(diagnostic);
            }
        }

        private static string PokemonNameNormaliser(string name)
        {
            StringBuilder sb = new StringBuilder();
            var firstCap = false;
            if (name != null)
            {
                foreach (var cha in name)
                {
                    if (!firstCap)
                    {
                        sb.Append(cha.ToString().ToUpper());
                        firstCap = true;
                    }
                    else
                    {
                        sb.Append(cha.ToString().ToLower());
                    }
                }
            }

            return sb.ToString();
        }
        
    }
}
