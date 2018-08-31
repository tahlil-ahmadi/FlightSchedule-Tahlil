#tool "nuget:?package=xunit.runner.console"
#tool "nuget:?package=JetBrains.dotCover.CommandLineTools"

var configuration = Argument("Configuration", "Release");
var publishPath = Argument("PublishPath", @"C:\Publish\FlightSchedule");
var backupPath = Argument("BackupPath", @"C:\Publish\Backup\");

Task("Clean")
    .Does(()=> {
        CleanDirectories("../**/bin/" + configuration);
        CleanDirectories("../**/obj/" + configuration);
});

Task("Build")
    .Does(()=>{
        MSBuild("../FlightSchedule.sln", configurator =>
            configurator.SetConfiguration(configuration)
                .SetVerbosity(Verbosity.Minimal)
                .UseToolVersion(MSBuildToolVersion.VS2015)
                .SetMSBuildPlatform(MSBuildPlatform.x86)
                .SetPlatformTarget(PlatformTarget.MSIL));
});

Task("Run-Unit-Tests")
    .Does(()=>{
        var testAssemblies = GetFiles("../**/bin/"+ configuration +"/*.Tests.Unit.dll");
        XUnit2(testAssemblies);

        // DotCoverCover(tool => {
        // tool.XUnit2("./**/bin/"+ configuration +"/*.Tests.Unit.dll",
        //     new XUnit2Settings {
        //     ShadowCopy = false
        //     });
        // },
        // new FilePath("./TestResults/result.dcvr"),
        // new DotCoverCoverSettings());
});

Task("Backup-Website")
    .Does(()=>{
    Zip(publishPath, backupPath + "Backup-"+DateTime.Now.Ticks+".zip");
});

Task("Publish-Website")
    .Does(()=>{
        CleanDirectory(publishPath);

    MSBuild("../FlightSchedule.sln", new MSBuildSettings()
        .WithProperty("OutDir", publishPath)
        .WithProperty("DeployOnBuild", "true")
        .WithProperty("WebPublishMethod", "Package")
        .WithProperty("PackageAsSingleFile", "true")
        .WithProperty("SkipInvalidConfigurations", "true"));

        // "../FlightSchedule.Presentation/FlightSchedule.Presentation.csproj"
});


Task("Default")
    .IsDependentOn("Clean")
    .IsDependentOn("Build")
    .IsDependentOn("Run-Unit-Tests");
    //  .IsDependentOn("Backup-Website")
    //  .IsDependentOn("Publish-Website");

RunTarget("Default");