param($installPath, $toolsPath, $package, $project)
    # This is the MSBuild targets file to add
    $targetsFile = [System.IO.Path]::Combine($toolsPath, $package.Id + '.targets')
 
    # Need to load MSBuild assembly if it's not loaded yet.
    Add-Type -AssemblyName 'Microsoft.Build, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'

    # Grab the loaded MSBuild project for the project
    $msbuild = [Microsoft.Build.Evaluation.ProjectCollection]::GlobalProjectCollection.GetLoadedProjects([System.IO.Path]::GetFullPath($project.FullName)) | Select-Object -First 1

    # Grab the target framework version and identifier from the loaded MSBuild proect
    $targetFrameworkIdentifier = $msbuild.Xml.Properties | Where-Object { $_.Name.Equals("TargetFrameworkIdentifier") } | Select-Object -First 1
    $targetFrameworkVersion = $msbuild.Xml.Properties | Where-Object { $_.Name.Equals("TargetFrameworkVersion") } | Select-Object -First 1

    # Make the path to the targets file relative.
    $projectUri = new-object Uri($project.FullName, [System.UriKind]::Absolute)
    $targetUri = new-object Uri($targetsFile, [System.UriKind]::Absolute)
    $relativePath = [System.Uri]::UnescapeDataString($projectUri.MakeRelativeUri($targetUri).ToString()).Replace([System.IO.Path]::AltDirectorySeparatorChar, [System.IO.Path]::DirectorySeparatorChar)

    # Calculate the new Condition variable: SimplePackageName + "Imported"
    $dotIndex = $package.Id.LastIndexOf('.')
    if ($dotIndex -le 0) 
    { $conditionVarName = $package.Id + "Imported"} 
    else 
    { $conditionVarName = $package.Id.Substring($dotIndex+1) + "Imported" }

    # Add the import with a condition, to allow the project to load without the targets present.
    $import = $msbuild.Xml.AddImport($relativePath)
    $import.Condition = "Exists('$relativePath')"

    # Add a target to fail the build when our targets are not imported
    $target = $msbuild.Xml.AddTarget("Ensure" + $conditionVarName)
    $target.BeforeTargets = "BeforeBuild"
    $target.Condition = "'`$($conditionVarName)' == ''"

    # if the targets don't exist at the time the target runs, package restore didn't run
    $errorTask = $target.AddTask("Error")
    $errorTask.Condition = "!Exists('$relativePath')"
    $errorTask.SetParameter("Text", "This project references NuGet package(s) that are missing on this computer. Enable NuGet Package Restore to download them.  For more information, see http://go.microsoft.com/fwlink/?LinkID=317567.");
    $errorTask.SetParameter("HelpKeyword", "BCLBUILD2001");

    # if the targets exist at the time the target runs, package restore ran but the build didn't import the targets.
    $errorTask = $target.AddTask("Error")
    $errorTask.Condition = "Exists('$relativePath')"
    $errorTask.SetParameter("Text", "The build restored NuGet packages. Build the project again to include these packages in the build. For more information, see http://go.microsoft.com/fwlink/?LinkID=317567.");
    $errorTask.SetParameter("HelpKeyword", "BCLBUILD2002");

    $project.Save()
