param
(
    [string] $ProjectPath, # = "C:\Users\ksykora\Workspace\MvvmCrossApp\App.UI.Droid",
	[string] $NewVersion, # = "123",
	[string] $NewVersionNumber # = 2
)

process
{
    # Load the bootstrap file
    [xml] $xam = Get-Content -Path ($ProjectPath + "\Properties\AndroidManifest.xml")
    
    # Get the version from Android Manifest
    $version = Select-Xml -xml $xam  -Xpath "/manifest/@android:versionName" -namespace @{android="http://schemas.android.com/apk/res/android"}

	# Get the Number Version
	$numberVersion = Select-Xml -xml $xam  -Xpath "/manifest/@android:versionCode" -namespace @{android="http://schemas.android.com/apk/res/android"}
    
    # Increment the version
    $version.Node.Value = $NewVersion
	$numberVersion.Node.Value = $NewVersionNumber

    # Save the file
    $xam.Save($ProjectPath + "\Properties\AndroidManifest.xml")
}