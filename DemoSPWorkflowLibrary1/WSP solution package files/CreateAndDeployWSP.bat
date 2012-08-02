
:: To customize this file, find and replace
:: a) "MyFeature" with your own feature name
:: b) "http://localhost" with the name of the site you wish to publish to

makecab /f wsp_structure.ddf

"%programfiles%\common files\microsoft shared\web server extensions\12\bin\stsadm.exe" -o retractsolution -name MyFeature.wsp -local
"%programfiles%\common files\microsoft shared\web server extensions\12\bin\stsadm.exe" -o deletesolution -name MyFeature.wsp

"%programfiles%\common files\microsoft shared\web server extensions\12\bin\stsadm.exe" -o addsolution -filename Package\MyFeature.wsp
"%programfiles%\common files\microsoft shared\web server extensions\12\bin\stsadm.exe" -o deploysolution -name MyFeature.wsp -local -allowGacDeployment -force

"%programfiles%\common files\microsoft shared\web server extensions\12\bin\stsadm.exe" -o deactivatefeature -filename MyFeature\feature.xml -url http://localhost/ -force
"%programfiles%\common files\microsoft shared\web server extensions\12\bin\stsadm.exe" -o uninstallfeature -filename MyFeature\feature.xml -force

"%programfiles%\common files\microsoft shared\web server extensions\12\bin\stsadm.exe" -o installfeature -filename MyFeature\feature.xml -force
"%programfiles%\common files\microsoft shared\web server extensions\12\bin\stsadm.exe" -o activatefeature -filename MyFeature\feature.xml -url http://localhost/ -force

iisreset