$version = '0.7.0-preview1'

$app =  (Get-Item -Path "./" -Verbose).FullName + "\Nuget.exe"

$p1 = (Get-Item -Path "../").FullName + "\Abp.Samples.Blog.Core\Abp.Samples.Blog.Core.csproj"
$p2 = (Get-Item -Path "../").FullName + "\Abp.Samples.Blog.EntityFramework\Abp.Samples.Blog.EntityFramework.csproj"
$p3 = (Get-Item -Path "../").FullName + "\Abp.Samples.Blog.Application\Abp.Samples.Blog.Application.csproj"
$p4 = (Get-Item -Path "../").FullName + "\Abp.Samples.Blog.Web\Abp.Samples.Blog.Web.csproj"

write-host "`nSTARTED TO PACKING`n"
& $app pack $p1 -Version $version
write-host $p1 "successfully packed `n"
& $app pack $p2 -Version $version
write-host $p2 "successfully packed `n"
& $app pack $p3 -Version $version
write-host $p3 "successfully packed `n"
& $app pack $p4 -Version $version
write-host $p4 "successfully packed `n"
write-host "`nALL PACKED"