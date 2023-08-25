#include <iostream>
#include <string>
#include <conio.h>
#include <cmath>
#include "menuoptions.h"

using namespace Installer;

int main(int argc, char* argv[])
{
    system("reg add HKCU\\Console /v VirtualTerminalLevel /t REG_DWORD /d 1 /f");
    // direct path to the settings.json file
    std::string settings_path = "./settings.json";
    Menu main_menu = Menuoptions::init_main();
    std::string return_string;
    while (true)
    {
        return_string = main_menu.take_input();
        if (return_string == "ins")
        {
            // install
            Menuoptions::Install(settings_path);
            // std::cout << "Install test" << std::endl;
        }
        else if (return_string == "up")
        {
            // update
            Menuoptions::Update(settings_path);
            // std::cout << "Update test" << std::endl;
        }
        else if (return_string == "chck_dep")
        {
            // check dependencies
            Menuoptions::Checkdep();
            // std::cout << "Check Dependency test" << std::endl;
        }
        else if (return_string == "up_dep")
        {
            // update dependencies
            Menuoptions::Updatedep();
            // std::cout << "Update Dependency test" << std::endl;
        }
        else if (return_string == "reins")
        {
            // reinstall
            Menuoptions::Reinstall(settings_path);
            // std::cout << "Reinstall test" << std::endl;
        }
        else if (return_string == "unins")
        {
            // uninstall
            Menuoptions::Uninstall(settings_path);
            // std::cout << "Uninstall test" << std::endl;
        }
        else if (return_string == "rep")
        {
            // report error
            Menuoptions::Report();
            // std::cout << "Error report test" << std::endl;
        }
        else if (return_string == "trouble")
        {
            // troubleshooting
            Menuoptions::Troubleshooting();
            // std::cout << "Troubleshooting test" << std::endl;
        }
        else if (return_string == "dep")
        {
            // dependencies
            Menuoptions::Dependencies();
            // std::cout << "Dependencies test" << std::endl;
        }
        else if (return_string == "abt")
        {
            // about
            Menuoptions::About(settings_path);
            // std::cout << "About test" << std::endl;
        }
        else if (return_string == "exit")
        {
            // exit
            break;
        }
    }
    return 0;
}