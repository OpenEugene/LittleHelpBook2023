"..\..\oqtane.framework\oqtane.package\nuget.exe" pack OE.Theme.LHB.nuspec 
XCOPY "*.nupkg" "..\..\oqtane.framework\Oqtane.Server\wwwroot\Themes\" /Y
