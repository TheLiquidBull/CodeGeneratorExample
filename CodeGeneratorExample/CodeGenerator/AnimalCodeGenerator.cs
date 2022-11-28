using System.Collections.Generic;
using Microsoft.CodeAnalysis;

namespace CodeGenerator
{
    [Generator]
	public class AnimalCodeGenerator : ISourceGenerator
    {
        private readonly IEnumerable<AnimalConfiguration> animals = new List<AnimalConfiguration>
        {
            new AnimalConfiguration
            {
                Name = "Dog",
                Action = "Bark",
                Sound = "Woof",
            },
        };

        public void Execute(GeneratorExecutionContext context)
        {
            foreach (var animal in animals)
            {
                string code = $@"
using System;

namespace Animal
{{
    public class {animal.Name}
    {{
        public void {animal.Action}()
        {{
            Console.WriteLine(""{animal.Sound}"");
        }}
    }}
}}";

                context.AddSource($"{animal.Name}.g.cs", code);
            }
        }

        public void Initialize(GeneratorInitializationContext context)
        {
            // No initialization required for this one
        }
    }
}
