
:: Before running this file, sign the assembly in Project properties
::
:: To customize this file, find and replace
:: a) "MyFeature" with your own feature name
:: b) "[IP_FORM_FILENAME]" with InfoPath form that needs to be uploaded (add additional lines for multiple forms)
:: c) "feature.xml" with the name of your feature.xml file
:: d) "workflow.xml" with the name of your workflow.xml file
:: e) "http://localhost" with the name of the site you wish to publish to

echo Copying the feature...
echo.
rd /s /q "%CommonProgramFiles%\Microsoft Shared\web server extensions\12\TEMPLATE\FEATURES\DemoSPWorkflowLibrary1"
mkdir "%CommonProgramFiles%\Microsoft Shared\web server extensions\12\TEMPLATE\FEATURES\DemoSPWorkflowLibrary1"

copy /Y feature.xml  "%CommonProgramFiles%\Microsoft Shared\web server extensions\12\TEMPLATE\FEATURES\DemoSPWorkflowLibrary1\"
copy /Y workflow.xml "%CommonProgramFiles%\Microsoft Shared\web server extensions\12\TEMPLATE\FEATURES\DemoSPWorkflowLibrary1\"
xcopy /s /Y *.xsn "%programfiles%\Common Files\Microsoft Shared\web server extensions\12\TEMPLATE\FEATURES\DemoSPWorkflowLibrary1\"


echo.
echo Adding assemblies to the GAC...
echo.
"%programfiles%\Microsoft Visual Studio 8\SDK\v2.0\Bin\gacutil.exe" -uf DemoSPWorkflowLibrary1
"%programfiles%\Microsoft Visual Studio 8\SDK\v2.0\Bin\gacutil.exe" -if bin\Debug\DemoSPWorkflowLibrary1.dll

:: Note: 64-bit alternative to lines above; uncomment these to install on a 64-bit machine
::"%programfiles% (x86)\Microsoft Visual Studio 8\SDK\v2.0\Bin\gacutil.exe" -uf DemoSPWorkflowLibrary1
::"%programfiles% (x86)\Microsoft Visual Studio 8\SDK\v2.0\Bin\gacutil.exe" -if bin\Debug\DemoSPWorkflowLibrary1.dll


echo.
echo Verifying InfoPath Forms...
echo.
::Note: Verify InfoPath forms; copy line for each form
::"%programfiles%\common files\microsoft shared\web server extensions\12\bin\stsadm" -o verifyformtemplate -filename [IP_FORM_FILENAME]


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
