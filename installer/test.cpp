#include <iostream>
#include <stdlib.h>
#include <string>
#include <vector>
#include <conio.h>
#include "prerequisites.h"
#include "menu.h"
// #include <direct.h>
using namespace Installer;

int main(int argc, char* argv[])
{
    std::vector<std::string> opts;
    std::vector<std::string> vals;
    for (int i = 1; i < 5; ++i)
    {
        // std::string option = "Options " + i;
        std::string opt = "Option " + i;
        std::string val = "Value " + i;
        opts.push_back(opt);
        vals.push_back(val);
    }
    Menu(opts, vals);
    return 0;
}