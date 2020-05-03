using System.Collections.Generic;
using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;

namespace ViewGenerator
{
  [Generator]
  public class ViewGenerator : ISourceGenerator
  {
    public void Execute(SourceGeneratorContext context)
    {
      // begin creating the source we'll inject into the users compilation
      StringBuilder sourceBuilder = new StringBuilder();

      // we need to somehow discover the views in a project automatically - for now they listed here
      var views = new List<string>();
      views.Add("MainPage");
      views.Add("SecondPage");

      foreach (var view in views)
      {
        sourceBuilder.Append($@"
        
        using Xamarin.Forms;
        namespace PrismExample.Views
        {{
          public partial class {view}
          {{
            public {view}()
            {{
              InitializeComponent();
            }}
          }}
        }}

        ");
      }


      // inject the created source into the users compilation
      context.AddSource("viewGenerated", SourceText.From(sourceBuilder.ToString(), Encoding.UTF8));
    }

    public void Initialize(InitializationContext context)
    {
      // No initialization required
    }
  }
}
