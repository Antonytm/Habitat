module.exports = function () {
  var instanceRoot = "C:\\websites\\Habitat.dev.local";
  var config = {
    websiteRoot: instanceRoot + "\\Website",
    sitecoreLibraries: instanceRoot + "\\Website\\bin",
    licensePath: instanceRoot + "\\Data\\license.xml",
    solutionName: "Habitat",
    buildConfiguration: "Debug",
    buildPlatform: "Any CPU",
    publishPlatform: "AnyCpu",
    runCleanBuilds: false,
    projectsInWorkList: ["src\\Project\\Habitat\\code\\Sitecore.Habitat.Website.csproj",
                        "src\\Project\\Common\\code\\Sitecore.Common.Website.csproj"],
    unicornConfigurationsInWorkList: "Project.Habitat.Website^Sitecore.Common.Website"
  };
  return config;
}