"..\..\oqtane.framework\oqtane.package\nuget.exe" pack OE.LHBTheme.nuspec 
XCOPY "*.nupkg" "..\..\oqtane.framework\Oqtane.Server\wwwroot\Themes\" /Y
