#include <iostream>
#include <stdlib.h>
#include <string>
#include <vector>
#include <conio.h>
#include "prerequisites.hpp"
#include "menu.hpp"
// #include <direct.h>
using namespace Installer;

int main(int argc, char* argv[])
{
    std::vector<std::string> opts;
    std::vector<std::string> vals;
    for (int i = 1; i < 5; ++i)
    {
        // std::string option = "Options " + i;
        opts.push_back("Options " + i);
        vals.push_back("Value " + i);
    }
    Menu mymenu(opts, vals);
    int wait;
    std::cin >> wait;
    return 0;
}