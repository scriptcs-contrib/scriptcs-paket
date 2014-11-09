namespace System
open System.Reflection

[<assembly: AssemblyTitleAttribute("ScriptCs.Paket")>]
[<assembly: AssemblyProductAttribute("ScriptCs.Paket")>]
[<assembly: AssemblyDescriptionAttribute("A module allowing you to use Paket with scriptcs (instead of Nuget)")>]
[<assembly: AssemblyVersionAttribute("0.1.0")>]
[<assembly: AssemblyFileVersionAttribute("0.1.0")>]
do ()

module internal AssemblyVersionInformation =
    let [<Literal>] Version = "0.1.0"
