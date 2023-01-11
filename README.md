# virtualSoftKey

Send WorkingTitle G1000 Nxi soft key presses (H:AS1000_PFD_SOFTKEYS_[0-9] / H:AS1000_MFD_SOFTKEYS[0-9]) to MSFS via FSUIPC WASM module.

Used to pop out a G1000 window on the touch screen display.

## Description

### Video Demo(with debug messages)

<iframe width="560" height="315" src="https://www.youtube.com/embed/TL5XNFdLN7E" title="YouTube video player" frameborder="0" allow="accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture; web-share" allowfullscreen></iframe>

### Descriptions

![Descriptions](img/descriptions.png)
## Getting Started

### Prerequisite

**1. The FSUIPC WASM Mudule is required**

Get the FSUIPC WASM Module from Additional Free Software Section of [Pete & John Dowson's Software](http://fsuipc.com) website and install the **fsuipc-lvar-module** to the MSFS Community folder.

(You do \*not* need install FSUIPC itself.)

<br />

**2. The \<aircraft title>.hvar file for the WASM Module is reqired.**

The file is stored here.

Commmunity\\fsuipc-lvar-module\\modules\\\<aircraft title>.hvar 

if it does not exist, just copy the **DA40-NG.hvar** file to **\<your aircaft title>.hvar**.

The aircraft title can be found in *<the aircraft folder\SimObject\Airplanes\aircraft.cfg>*.

Like this: **Title="xxxx"**

See [the forum posts](https://forum.simflight.com/topic/92031-wasm-module-client-api-for-msfs-fsuipc7-now-available/) for more information. 


### How to use 

Just run *vitualSoftKey.exe* and move it over the avobe G1000 pop-out panel.


## Help

* The error display says *connect failed*.

You need to install FSUIPC WASM Module.

* Nothing happens when I tap.

You need to store \<aircraft title>.hvar file to WASM Module folder.

## Author

ti360✍ https://twitter.com/ti360

## Version History

* 0.1
    * Initial Release

## License

This project is licensed under the MIT License - see the LICENSE.md file for details

