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
            Menu(std::vector<std::string> options, std::vector<std::string> values);      // constructor
            void takeinput();
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
        private:
            int selected_index;
            std::vector<std::string> options;
            std::vector<std::string> values;
            void moveup();
            void movedown();
            std::string select();
    };
}

#endif // _MENU_