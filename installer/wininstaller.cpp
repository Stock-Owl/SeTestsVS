#include <iostream>
#include <stdlib.h>
#include <string>

int main(int argc, char* argv[])
{
    //prompts the directory for installation
    std::string path_;
    while (1)
    {
        std::cout << "Select a path for the program to be installed in" << std::endl;
        std::getline(std::cin, path_);
        std::string proceed;
        confirmpath:
        std::cout << "The selected path is: " << path_ << " Proceed? [Y/N][exit to exit the installer]: ";
        std::cin >> proceed;
        if (proceed == "Y" || proceed == "y")
        {
            break;
        }
        else if (proceed == "N" || proceed == "n")
        {
            continue;
        }
        else if (proceed == "exit")
        {
            return 1;
        }
        else
        {
            std::cout << "Answer has to be either y or n"  << std::endl;
            goto confirmpath;
        }
    }

    char* pyversion = "3.11";

    // installs python 3.11
    int pyinstalled = system("winget install -e --id Python.Python.3.11");
    if ((bool)pyinstalled)
    {
        std::cout << "Python "<< pyversion << " successfully installed" << std::endl;
    }
    else
    {
        std::cout << "Python " << pyversion << " could not be automatically installed" << std::endl
        << "To install Python" << pyversion << "manually, visit https://www.python.org/downloads/release/python-3114/" << std::endl;
    }
    
    //checks if pip is installed, if not, tries to install it
    int pipversion = system("pip --version");
    if (!(bool)pipversion)
    {
        int getpip = system("python get-pip.py");
        if (!(bool)getpip)
        {
            std::cout << "pip could not be installed" << std::endl
            << "Try running the commands:" << std::endl
            << "\tcurl https://bootstrap.pypa.io/get-pip.py -o get-pip.py" << std::endl
            << "\tpython get-pip.py" << std::endl;
            return 1;
        }
    }
    
    //git install: 'winget install --id Git.Git -e --source winget'
    //install selenium using pip
    int getselenium = system("pip install selenium");
    if (!(bool)getselenium)
    {
        std::cout << "Python package 'selenium' could not be automatically installed" << std::endl
        << "To install it manually, visit https://www.selenium.dev/documentation/webdriver/getting_started/install_library/" << std::endl;
        return 1;
    }
    else
    {
        std::cout << "Python package 'selenium' succesfully installed" << std::endl;
    }


    //install git
    int getgit = system("winget install --id Git.Git -e --source winget");
    if (!(bool)getgit)
    {
        std::cout << "Git could not be automatically installed" << std::endl
        << "To install Git manually, visit https://git-scm.com/download/win" << std::endl;
        return 1;
    }

    //install the files needed using git at the specified path
    std::string cmd = "cd " + path_ + " && git clone -b chrome https://github.com/Stock-Owl/SeTestsVS.git";
    int getfiles = system(cmd.c_str());
    if (!(bool)getfiles)
    {
        std::cout << "Could not clone github repository automatically" << std::endl
        << "To clone it manually run the following command:" << std::endl
        << " git clone -b chrome https://github.com/Stock-Owl/SeTestsVS.git" << std::endl
        << "or" << std::endl
        << "visit https://github.com/Stock-Owl/SeTestsVS/tree/chrome and clone the 'core' branch" << std::endl;
        return 1;
    }
    return 0;
}