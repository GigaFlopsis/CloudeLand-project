# CloudLand VR game for Daydream and Cardboard 

# [Download apk](https://github.com/GigaFlopsis/CloudeLand-project/raw/master/build/CloudeLand.apk)

[![Icon 512.jpg](https://lh3.googleusercontent.com/APMaR3W1KlMeakXlmFYDfIUHp3WHDYHInW6sdFZafkrsjjtIbpscDYFibWMEGuVZbjqGMMO2htd6BUHrA-ZeFL5K7AGZDbOI_FdvcxJRpc5d-vMOfFVXkLZTmUwthXC2K2IEF7L_AE5d8Jy8cLCXnEQtiYog5j9W9ilH9-WMy1HAiEBGdwysQY8OKOtzcKzD-Ild4GDjS0Xz33fRHscbzAuttHLH2lEub89cXcB8bgZAUNUeexCWO-PH5ecyNvO-3WHOEpeQfe5E3Iy3Np4FmsIBP0dRqUGmSQelK_P0sVPLRvpumUwjQTyGFRJRtjRZrbhSV592lOAR2Kika0s12iXy4WrHjAq99mmqloVSP-byGNqspHT393MdKx3XCQzW2DODa1frbwsbil_p6q0yfb944a9I5TKUTZslJk5y9YlJLVtdod41KIB5cSati1Do1uWyrU-SzIvGQsXW1cA9JG080DGscW7vU2_3L6tpNZOKyTXldz5RxNUE0ehk3ZiNuD-meoZcIOa0Pa7ucvmuWq71NXcJGKUiP9ueiz3WObcKqySoIeB1YxOL2l0=w3840-h1835)](https://postimg.org/image/e6u5uloqf/)

#### Game genre
    VR platformer
#### platform
    Android 5.. and leter

![](https://s24.postimg.org/gdq4te7vp/Screenshot_2016_12_28_00_17_38_749_com_devitt_Cl.png)
![](https://s24.postimg.org/yht5e15k5/Screenshot_2016_12_28_00_17_44_991_com_devitt_Cl.png)
![](https://s24.postimg.org/r33tlnjol/Screenshot_2016_12_28_00_17_53_196_com_devitt_Cl.png)
![](https://s24.postimg.org/ji0sq6oo5/Screenshot_2016_08_15_02_12_19_com_devitt_Jump_VR.png)
![](https://s30.postimg.org/6n1jbtx35/Screenshot_2016_12_28_00_19_42_220_com_devitt_Cl.png)
![](https://s24.postimg.org/o56uryc11/Screenshot_2016_08_15_02_12_32_com_devitt_Jump_VR.png)
![](https://s24.postimg.org/xi2uibqed/Screenshot_2016_12_28_00_20_09_360_com_devitt_Cl.png)
![](https://s24.postimg.org/7ax28miqt/Bz_RU8_IFb_Ix8.jpg)
![](https://s24.postimg.org/xyjgr0orp/Screenshot_2016_08_15_02_11_21_com_devitt_Jump_VR.png)
![](https://s24.postimg.org/mngt2nhwl/Screenshot_2016_08_15_02_11_55_com_devitt_Jump_VR.png)

[More screnshots](https://drive.google.com/drive/folders/0B3fRqSQk6ENBa1lBUldaS0E3R0E?usp=sharing)


## Description
Hello. My name is Dmitry. In my spare time I develop a simple and colorful game for google Cardboard.
In the game you have to collect strange glowing things, run on walls and jump on trampolines :)


Implemented in the game mechanics, physics, menu. For the test I created the first two levels: on earth and in space.
In the game, I tried to create a simple and dynamic control which can be achieved without a joystick.

#### Params for save game

To save the game function is used [PlayerPrefs()](https://docs.unity3d.com/ScriptReference/PlayerPrefs.html)

    "Level_n"         : (int)name level
    "Level_n_Stars"	  : (int)stars collected in the level
    "Level_n_Time" 	  : (int)the time for which the level is passed
    "VRMode" 	    	  : (int) 1 - enable vr mod, 0 - disable vr mod 
    "MotionBlur"  	  : (int) 1 - enable motionBlur
    "ContinueLevel"   : (int) the level from which you can continue the game if(level>0)
    "AvalibleLevels"  : (int) the number of levels available
    "AvalibleStars"   : (int) number of stars collected
    "AudioMute" 	  : (int) 1 - enable mute 
 
#### Copyright   
        author: Devitt Dmitry
        year: 28.12.2016
