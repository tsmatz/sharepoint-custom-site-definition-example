pushd %programfiles%\common files\microsoft shared\web server extensions\12\bin
stsadm -o deactivatefeature -filename DemoSPWorkflowLibrary1\feature.xml -url http://kkdeveva01
stsadm -o uninstallfeature -filename DemoSPWorkflowLibrary1\feature.xml -force
"%programfiles%\Microsoft Visual Studio 8\SDK\v2.0\Bin\gacutil.exe" -uf DemoSPWorkflowLibrary1
popd
iisreset
