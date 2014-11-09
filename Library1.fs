namespace ScriptCs.Paket

open System
open ScriptCs
open ScriptCs.Hosting
open ScriptCs.Contracts
open Paket

type PaketInstallationProvider(fileSystem : IFileSystem) =
    let fs = fileSystem
    let dep = Dependencies.Locate(fs.CurrentDirectory)

    interface IInstallationProvider with
        member x.GetRepositorySources(path) =
            [fs.GetWorkingDirectory(path)] |> Seq.ofList

        member x.Initialize() =
            ()

        member x.InstallPackage(packageId, allowPreRelease) =
            dep.Add(packageId.PackageId, packageId.Version.ToString())
            dep.Install(false, false)

        member x.IsInstalled(packageId, allowPreRelease) =
            dep.FindReferencesFor(packageId.PackageId) |> Seq.exists (fun n -> n = packageId.PackageId)

type PaketAssemblyResolver =
    interface IAssemblyResolver with
        member x.GetAssemblyPaths(path, binariesOnly) =
            Seq.empty

[<Module("paket")>]
type FSharpModule () =
    interface IModule with
        member x.Initialize(builder) =
            builder.
                InstallationProvider<PaketInstallationProvider>().
                AssemblyResolver<PaketAssemblyResolver>() 
                |> ignore
                

