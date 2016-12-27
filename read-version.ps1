Write-Host "branch: $env:BUILD_SOURCEBRANCH"
Write-Host "commit: $env:BUILD_SOURCEVERSION"
if($env:BUILD_SOURCEBRANCH -match "[0-9]+\.[0-9]+\.[0-9]+") {
  $version = $env:BUILD_SOURCEBRANCH
} else {
  $version = iex "git describe ${env:BUILD_SOURCEVERSION} --abbrev=0"
}

$env:APP_VERSION = $version.Trim()
Write-Host "app version: $env:APP_VERSION"