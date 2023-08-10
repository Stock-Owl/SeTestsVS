// header file to display an interactive selection menu
// v.1.0.0

#pragma once

#ifndef _MENU_
#define _MENU_

#include <iostream>
#include <string>
#include <conio.h>
#include <vector>

namespace Installer
{
    class Menu
    {
    public:
        // constructors
        Menu(std::vector<std::string> options, std::vector<std::string> values);
        Menu(std::string prompt, std::vector<std::string> options, std::vector<std::string> values);
        std::string take_input();
        int size;
    private:
        enum inputkeycodes
        {
            UP = 72,
            DOWN = 80,
            // LEFT = 75,
            // RIGHT = 77,
            ENTER = 13,
            ESC = 27,
            ARROW_KEY_PREFIX = 224
        };
        int selected_index;
        std::string prompt;
        std::vector<std::string> options;
        std::vector<std::string> values;
    };
}

#endif // _MENU_