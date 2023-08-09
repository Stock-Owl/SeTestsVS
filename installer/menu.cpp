#include <iostream>
#include <string>
#include <conio.h>
#include <vector>
#include "menu.h"

using namespace Installer;

Menu::Menu(std::vector<std::string> options, std::vector<std::string> values)
{
    for (int idx = 0; idx < options.size(); ++idx)
    {
       this -> options.push_back(options[idx]);
    }
    for (int idx = 0; idx < values.size(); ++idx)
    {
        this->values.push_back(values[idx]);
    }
    this -> selected_index = 0;
    while (true)
    {
        Menu::takeinput();
    }
}

void Menu::takeinput()
{
    int got = _getch();
    std::cout << "got: " << got << std::endl;
}
