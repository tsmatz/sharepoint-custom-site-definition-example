echo.
echo Activating the feature...
echo.
pushd %programfiles%\common files\microsoft shared\web server extensions\12\bin

::Note: Uncomment these lines if you've modified your deployment xml files or IP forms 
::stsadm -o deactivatefeature -filename DemoSPWorkflowLibrary1\feature.xml -url http://kkdeveva01
::stsadm -o uninstallfeature -filename DemoSPWorkflowLibrary1\feature.xml

stsadm -o installfeature -filename DemoSPWorkflowLibrary1\feature.xml -force
stsadm -o activatefeature -filename DemoSPWorkflowLibrary1\feature.xml -url http://kkdeveva01


echo Doing an iisreset...
echo.
popd
iisreset
