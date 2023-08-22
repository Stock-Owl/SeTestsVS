#pragma once

#ifndef _MENU_OPTIONS_
#define _MENU_OPTIONS_

#include <fstream>
#include <iostream>
#include <string>
#include <conio.h>
#include <nlohmann/json.hpp>
#include "menu.h"
#include "prerequisites.h"

namespace Installer
{
    class Menuoptions
    {
        public:
            static Menu init_main(void);
            static int Install(std::string path);
            static int Update(std::string path);
            static int Checkdep(void);
            static int Updatedep(void);
            static int Reinstall(std::string path);
            static int Uninstall(std::string path);
            static int Report(void);
            static int Troubleshooting(void);
            static int Dependencies(void);
            static int About(std::string path);
        private:
            static Menu init_dependencies(void);
    };
}
#endif // _MENU_OPTIONS_
